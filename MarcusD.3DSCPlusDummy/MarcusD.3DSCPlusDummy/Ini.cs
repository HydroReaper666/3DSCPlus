using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;


namespace MarcusD.Util
{
    public class Ini
    {
        public String path;
        protected Dictionary<String, IniSection> container;

        public Ini(String path)
        {
            this.path = Path.GetFullPath(path);
            if (!File.Exists(this.path)) File.WriteAllText(this.path, "");
            this.container = initial();
        }

        public class IniSection
        {
            protected String section;
            protected Ini ini;

            public IniSection(Ini ini, String section)
            {
                this.ini = ini;
                this.section = section;
            }

            public int Write(String k, String v)
            {
                int shit = WritePrivateProfileString(this.section, k, v, this.ini.path);
                if (Marshal.GetLastWin32Error() != 0) throw new Win32Exception(Marshal.GetLastWin32Error());
                return shit;
            }

            public String Read(String k, String def = "", int maxsize = 255)
            {
                StringBuilder sb = new StringBuilder(maxsize);
                GetPrivateProfileString(this.section, k, def, sb, maxsize, this.ini.path);
                //if (Marshal.GetLastWin32Error() != 0) throw new Win32Exception(Marshal.GetLastWin32Error());
                return sb.ToString();
            }

            public int ReadInt(String k, int def = 0)
            {
                return GetPrivateProfileInt(this.section, k, def, this.ini.path);
            }

            public int WriteStruct<T>(String k, object v) where T : struct
            {
                int sizeofv = Marshal.SizeOf(v);
                IntPtr pointer = Marshal.AllocCoTaskMem(sizeofv);
                Marshal.StructureToPtr(v, pointer, false);
                int toret = WritePrivateProfileStruct(this.section, k, pointer, sizeofv, this.ini.path);
                if (Marshal.GetLastWin32Error() != 0) throw new Win32Exception(Marshal.GetLastWin32Error());
                Marshal.FreeCoTaskMem(pointer);
                return toret;
            }

            public Nullable<T> ReadStruct<T>(String k) where T : struct
            {
                Type type = typeof(T);
                int sizeofv = Marshal.SizeOf(type);
                IntPtr pointer = Marshal.AllocCoTaskMem(sizeofv);
                int toret = GetPrivateProfileStruct(this.section, k, pointer, sizeofv, this.ini.path);
                object shit = (toret == 0 ? null : Marshal.PtrToStructure(pointer, type));
                Marshal.FreeCoTaskMem(pointer);
                return (T)shit;
            }

            public IEnumerable<String> EnumKeys
            {
                get
                {
                    int size = UInt16.MaxValue;
                    String str = new String('\0', size);
                    IntPtr ptr = Marshal.StringToHGlobalAnsi(str);
                    GetPrivateProfileSection(this.section, ptr, size, this.ini.path);
                    str = Marshal.PtrToStringAnsi(ptr, size);
                    Marshal.FreeHGlobal(ptr);
                    StringBuilder sb = new StringBuilder();
                    Boolean zero = true;
                    Boolean skip = false;
                    foreach (char ch in str)
                    {
                        if (ch == '\0')
                        {
                            if (zero) break;

                            zero = true;
                            yield return sb.ToString();
                            sb = new StringBuilder();
                            skip = false;
                        }
                        else if (skip) continue;
                        else
                        {
                            zero = false;
                            if (ch == '=') skip = true;
                            else sb.Append(ch);
                        }
                    }
                }
            }

            public IEnumerable<KeyValuePair<String, String>> EnumValues
            {
                get
                {
                    int size = UInt16.MaxValue;
                    String str = new String('\0', size);
                    IntPtr ptr = Marshal.StringToHGlobalAnsi(str);
                    GetPrivateProfileSection(this.section, ptr, size, this.ini.path);
                    str = Marshal.PtrToStringAnsi(ptr, size);
                    Marshal.FreeHGlobal(ptr);
                    StringBuilder sb = new StringBuilder();
                    Boolean zero = true;
                    Boolean skip = false;
                    String key = null;
                    foreach (char ch in str)
                    {
                        if (ch == '\0')
                        {
                            if (zero) break;

                            zero = true;
                            if(key != null) yield return new KeyValuePair<String, String>(key, sb.ToString());
                            key = null;
                            sb = new StringBuilder();
                            skip = false;
                        }
                        else if (skip) sb.Append(ch);
                        else
                        {
                            zero = false;
                            if (ch == '=')
                            {
                                skip = true;
                                key = sb.ToString();
                                sb = new StringBuilder();
                            }
                            else sb.Append(ch);
                        }
                    }
                }
            }

            public String this[string section]
            {
                get
                {
                    return Read(section);
                }
                set
                {
                    Write(section, value);
                }
            }

        }

        protected Dictionary<String, IniSection> initial()
        {
            Dictionary<String, IniSection> inisec = new Dictionary<String, IniSection>();
            foreach(String str in EnumSections)
            {
                inisec.Add(str, new IniSection(this, str));
            }
            return inisec;
        }

        public IniSection GetSection(string name)
        {
            IniSection dummy;
            if (!container.TryGetValue(name, out dummy))
            {
                dummy = new IniSection(this, name);
                container.Add(name, dummy);
            }
            return dummy;
        }

        public IEnumerable<String> EnumSections
        {
            get
            {
                int size = UInt16.MaxValue;
                String str = new String('\0', size);
                IntPtr ptr = Marshal.StringToHGlobalAnsi(str);
                GetPrivateProfileSectionNames(ptr, size, this.path);
                str = Marshal.PtrToStringAnsi(ptr, size);
                Marshal.FreeHGlobal(ptr);
                StringBuilder sb = new StringBuilder();
                Boolean zero = true;
                foreach (char ch in str)
                {
                    if (ch == '\0')
                        if (zero) break;
                        else
                        {
                            zero = true;
                            yield return sb.ToString();
                            sb = new StringBuilder();
                        }
                    else
                    {
                        zero = false;
                        sb.Append(ch);
                    }
                }
            }
        }

        public IniSection this[string section]
        {
            get
            {
                return this.GetSection(section);
            }
        }

        [DllImport("KERNEL32", SetLastError = true)]
        protected static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder sbpointer, int maxsize, string inifile);
        [DllImport("KERNEL32")]
        protected static extern int GetPrivateProfileInt(string section, string key, int def, string inifile);
        [DllImport("KERNEL32")]
        protected static extern int GetPrivateProfileSection(string section, IntPtr sb, int size, string inifile);
        [DllImport("KERNEL32")]
        protected static extern int GetPrivateProfileSectionNames(IntPtr sb, int size, string inifile);
        [DllImport("KERNEL32", SetLastError = true)]
        protected static extern int WritePrivateProfileString(string section, string key, string val, string inifile);
        [DllImport("KERNEL32")]
        protected static extern int GetPrivateProfileStruct(string section, string key, IntPtr pstruct, int size, string inifile);
        [DllImport("KERNEL32", SetLastError = true)]
        protected static extern int WritePrivateProfileStruct(string section, string key, IntPtr pstruct, int size, string inifile);

        protected static IEnumerable<String> fastsplit(String str, char ch, int limit = Int32.MaxValue)
        {
            StringBuilder sb = new StringBuilder();

            foreach(char chr in str)
            {
                if(limit > 0 && ch == chr)
                {
                    yield return sb.ToString();
                    limit--;
                    sb = new StringBuilder();
                }
                else
                {
                    sb.Append(chr);
                }
            }

            if(sb.Length > 0) yield return sb.ToString();
        }
    }
}
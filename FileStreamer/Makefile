#---------------------------------------------------------------------------------
.SUFFIXES:
#---------------------------------------------------------------------------------

TOPDIR ?= $(CURDIR)

PLPREFIX?=
export PLPREFIX

CC	:=	$(PLPREFIX)gcc
CXX	:=	$(PLPREFIX)g++
AS	:=	$(PLPREFIX)as
AR	:=	$(PLPREFIX)gcc-ar
OBJCOPY	:=	$(PLPREFIX)objcopy
STRIP	:=	$(PLPREFIX)strip
NM	:=	$(PLPREFIX)gcc-nm
RANLIB	:=	$(PLPREFIX)gcc-ranlib
LZZ ?= lzz

TARGET		    :=	$(notdir $(CURDIR))
BUILD		    :=	build_PC_$(OS)
SOURCES		    :=	soos platform
DATA		    :=	data
INCLUDES	    :=	inc/$(OS)

#---------------------------------------------------------------------------------
# options for code generation
#---------------------------------------------------------------------------------

export DT := $(shell date +"%Y/%m/%d")

CFLAGS	:=	-g -Wall -O0 \
                    -Wno-format -Wno-write-strings -Wno-unused-variable -Wno-unused-value 

ifeq ($(OS),Windows_NT)
CFLAGS	+= 
POSTFIX := exe
else
POSTFIX := elf
endif

CFLAGS	+=	$(INCLUDE) -D_PC -DBUILDTIME=\"$(DT)\"
CXXFLAGS	:= $(CFLAGS) -Wno-reorder -fno-rtti -std=gnu++11

LDFLAGS	=   -g

LIBS	:= -ltheora -logg -lm

ifeq ($(OS),Windows_NT)
LIBS	+= -lgdi32 -lws2_32 -lwsock32 -lmingw32 -mconsole -mwindows -static-libgcc -static-libstdc++
endif


#---------------------------------------------------------------------------------
# no real need to edit anything past this point unless you need to add additional
# rules for different file extensions
#---------------------------------------------------------------------------------
ifneq ($(BUILD),$(notdir $(CURDIR)))
#---------------------------------------------------------------------------------

export OUTPUT	:=	$(CURDIR)/out/$(TARGET)
export TOPDIR	:=	$(CURDIR)

export VPATH	:=	$(foreach dir,$(SOURCES) _lzz_temp,$(CURDIR)/$(dir)) \
			$(foreach dir,$(DATA),$(CURDIR)/$(dir))

export DEPSDIR	:=	$(CURDIR)/$(BUILD)

CFILES		:=  $(shell find $(SOURCES) -name '*.c' -printf "%P\n")
CPPFILES	:=  $(shell find $(SOURCES) -name '*.cpp' -printf "%P\n")
LPPFILES	:=  $(shell find $(SOURCES) -name '*.lpp' -printf "%P\n")
SFILES		:=  $(shell find $(SOURCES) -name '*.s' -printf "%P\n")
BINFILES	:=	$(foreach dir,$(DATA),$(notdir $(wildcard $(dir)/*.*)))

LPPSOOS     :=   $(foreach fil,$(LPPFILES),$(patsubst %.lpp,%.cpp,$(fil)))
CPPFILES 	+=   $(foreach fil,$(LPPSOOS),$(fil:.lpp=.cpp))

#---------------------------------------------------------------------------------
# use CXX for linking C++ projects, CC for standard C
#---------------------------------------------------------------------------------
ifeq ($(strip $(CPPFILES)),)
#---------------------------------------------------------------------------------
	export LD	:=	$(CC)
#---------------------------------------------------------------------------------
else
#---------------------------------------------------------------------------------
	export LD	:=	$(CXX)
#---------------------------------------------------------------------------------
endif
#---------------------------------------------------------------------------------

export OFILES	:=	$(addsuffix .o,$(BINFILES)) \
			$(CPPFILES:.cpp=.o) $(CFILES:.c=.o) $(SFILES:.s=.o)

export INCLUDE	:=	$(foreach dir,$(INCLUDES),-I$(CURDIR)/$(dir)/include) \
			$(foreach dir,$(LIBDIRS),-I$(dir)/include) \
			$(foreach dir,$(SOURCES) _lzz_temp,-I$(CURDIR)/$(dir)) \
			-I$(CURDIR)/$(BUILD)

export LIBPATHS	:=	$(foreach dir,$(LIBDIRS),-L$(dir)/lib) \
					$(foreach dir,$(INCLUDES),-L$(CURDIR)/$(dir)/lib)


.PHONY: $(BUILD) clean all

#---------------------------------------------------------------------------------
all: $(BUILD)

$(LPPSOOS): $(LPPFILES)
	@mkdir -p _lzz_temp/$(shell dirname $@)
	@echo [L+] $(notdir $@)
	@$(LZZ) -hx hpp -hd -sd -c -D_PC -o _lzz_temp/$(shell dirname $@) $(CURDIR)/soos/$(patsubst %.cpp,%.lpp,$@)

$(BUILD): $(LPPSOOS)
	@[ -d $@ ] || mkdir -p $@
	@[ -d $(CURDIR)/out ] || mkdir -p $(CURDIR)/out
	@find $(SOURCES) -type d -printf "%P\0" | xargs -0 -I {} mkdir -p $(BUILD)/{}
	@[ ! -d _lzz_temp ] || find _lzz_temp -type d -printf "%P\0" | xargs -0 -I {} mkdir -p $(BUILD)/{}
	@+$(MAKE) --no-print-directory -C $(BUILD) -f $(CURDIR)/Makefile

#---------------------------------------------------------------------------------
clean:
	@echo 'Cleaning PC build artifacts...'
	@rm -rf $(BUILD) _lzz_temp $(CURDIR)/out

#---------------------------------------------------------------------------------
else

DEPENDS	:=	$(OFILES:.o=.d)

#---------------------------------------------------------------------------------
# main targets
#---------------------------------------------------------------------------------
all	:	$(OUTPUT).$(POSTFIX)

$(OUTPUT).$(POSTFIX): $(OFILES)

%.o: %.cpp
	@echo [CX] $(notdir $<)
	@$(CXX) $(CXXFLAGS) -c $< -o $@

%.o: %.c
	@echo [CC] $(notdir $<)
	@$(CC) $(CFLAGS) -c $< -o $@

%.$(POSTFIX):
	@echo [LD] $(notdir $@)
	@$(LD) $(LDFLAGS) $(OFILES) $(LIBPATHS) $(LIBS) -o $@

#---------------------------------------------------------------------------------
# you need a rule like this for each extension you use as binary data
#---------------------------------------------------------------------------------
%.png.o	:	%.png
#---------------------------------------------------------------------------------
%.png.o	:	%.png
	@echo $(notdir $<)
ifeq ($(OS),Windows_NT)
	cd $(dir $<) && $(PLPREFIX)ld -r -b binary -o $(CURDIR)/$(@) $(notdir $<) && cd $(CURDIR)
else
	@bin2s $< | $(AS) -o $(@)
endif
	@echo "extern const u8" `(echo $(<F) | sed -e 's/^\([0-9]\)/_\1/' | tr . _)`"_end[];" > `(echo $(<F) | tr . _)`.h
	@echo "extern const u8" `(echo $(<F) | sed -e 's/^\([0-9]\)/_\1/' | tr . _)`"[];" >> `(echo $(<F) | tr . _)`.h
	@echo "extern const u32" `(echo $(<F) | sed -e 's/^\([0-9]\)/_\1/' | tr . _)`_size";" >> `(echo $(<F) | tr . _)`.h

-include $(DEPENDS)

#---------------------------------------------------------------------------------------
endif
#---------------------------------------------------------------------------------------

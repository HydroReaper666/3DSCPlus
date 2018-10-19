#---------------------------------------------------------------------------------
.SUFFIXES:
#---------------------------------------------------------------------------------

ifeq ($(strip $(DEVKITARM)),)
$(error "Please set DEVKITARM in your environment. export DEVKITARM=<path to>devkitARM")
endif

TOPDIR ?= $(CURDIR)
include $(DEVKITARM)/3ds_rules

#---------------------------------------------------------------------------------
TARGET		:= $(notdir $(TOPDIR))
BUILD		:= build
SOURCES		:= soos
DATA		:= data
INCLUDES	:= inc
ROMFS		:= $(TOPDIR)/assets/ROMFS
ifeq ($(strip $(OSUC)),)
APP_TITLE       :=  3DSController+
APP_DESCRIPTION :=  3DSController Plus
APP_AUTHOR      :=  MarcusD
APP_PRODUCT_CODE:=  CTR-P-AGIA
APP_UNIQUE_ID   :=  0x56
ICON            :=  assets/logo.png
else
TARGET		:=  $(notdir $(TOPDIR))_min
BUILD		:=  build_min
APP_TITLE       :=  osu!Controller
APP_DESCRIPTION :=  osu!Controller
APP_AUTHOR      :=  MarcusD
APP_PRODUCT_CODE:=  CTR-P-AOSA
APP_UNIQUE_ID   :=  0x57
ICON            :=  assets/logo_osu.png
endif

APP_TITLE	:= $(shell echo "$(APP_TITLE)" | cut -c1-128)
APP_DESCRIPTION	:= $(shell echo "$(APP_DESCRIPTION)" | cut -c1-256)
APP_AUTHOR	:= $(shell echo "$(APP_AUTHOR)" | cut -c1-128)
APP_PRODUCT_CODE:= $(shell echo $(APP_PRODUCT_CODE) | cut -c1-16)
APP_UNIQUE_ID	:= $(shell echo $(APP_UNIQUE_ID) | cut -c1-7)

#---------------------------------------------------------------------------------
# options for code generation
#---------------------------------------------------------------------------------
ARCH	:=	-march=armv6k -mtune=mpcore -mfloat-abi=hard

CFLAGS	:=	-g -Wall -O0 -mword-relocations \
			-ffast-math \
			$(ARCH) \
			-Wno-format -Wno-write-strings -Wno-unused-variable -Wno-unused-value\
			-Wno-deprecated-declarations -Wno-pointer-arith -Wno-sign-compare\
			-Wno-unused-but-set-variable

CFLAGS	+=	$(INCLUDE) -DARM11 -D_3DS

ifneq ($(strip $(OSUC)),)
CFLAGS	+=	-DOSUC
endif

CXXFLAGS:=	$(CFLAGS) -Wno-reorder -fno-rtti -std=gnu++11

ASFLAGS	:=	-g $(ARCH)
LDFLAGS	=	-specs=3dsx.specs -g $(ARCH) -Wl,-Map,$(notdir $*.map)

ifeq ($(strip $(OSUC)),)
LIBS	:= -ltheoradec -logg -lctru -lm
else
LIBS	:= -lctru -lm
endif

#---------------------------------------------------------------------------------
# list of directories containing libraries, this must be the top level containing
# include and lib
#---------------------------------------------------------------------------------
LIBDIRS	:=	$(CTRULIB) $(DEVKITPRO)/portlibs/armv6k


#---------------------------------------------------------------------------------
# no real need to edit anything past this point unless you need to add additional
# rules for different file extensions
#---------------------------------------------------------------------------------
ifneq ($(BUILD),$(notdir $(CURDIR)))
#---------------------------------------------------------------------------------

export OUTPUT	:=	$(CURDIR)/out/$(TARGET)

export TOPDIR	:=	$(CURDIR)

export VPATH	:=	$(foreach dir,$(SOURCES) $(BUILD)/_lzz_temp,$(CURDIR)/$(dir)) \
			$(foreach dir,$(DATA),$(CURDIR)/$(dir))

export DEPSDIR	:=	$(CURDIR)/$(BUILD)

CFILES		:=	$(shell find $(SOURCES) -name '*.c' -printf "%P\n")
CPPFILES	:=	$(shell find $(SOURCES) -name '*.cpp' -printf "%P\n")
LPPFILES	:=	$(shell find $(SOURCES) -name '*.lpp' -printf "%P\n")
SFILES		:=	$(shell find $(SOURCES) -name '*.s' -printf "%P\n")
BINFILES	:=	$(foreach dir,$(DATA),$(notdir $(wildcard $(dir)/*.*)))

LPPSOOS		:=	$(foreach fil,$(LPPFILES),$(patsubst %.lpp,%.cpp,$(fil)))
CPPFILES	+=	$(LPPSOOS)
LPPTARGET	:=	$(foreach fil,$(LPPFILES),$(patsubst %.lpp,$(TOPDIR)/$(BUILD)/_lzz_temp/%.cpp,$(fil)))

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
			$(foreach dir,$(SOURCES) $(BUILD)/_lzz_temp,-I$(CURDIR)/$(dir)) \
			-I$(CURDIR)/$(BUILD)

export LIBPATHS	:=	$(foreach dir,$(LIBDIRS),-L$(dir)/lib) \
			$(foreach dir,$(INCLUDES),-L$(CURDIR)/$(dir)/lib)

ifeq ($(strip $(ICON)),)
	icons := $(wildcard *.png)
	ifneq (,$(findstring $(TARGET).png,$(icons)))
		export APP_ICON := $(TOPDIR)/$(TARGET).png
	else
		ifneq (,$(findstring icon.png,$(icons)))
			export APP_ICON := $(TOPDIR)/icon.png
		endif
	endif
else
	export APP_ICON := $(TOPDIR)/$(ICON)
endif


export _3DSXFLAGS += --smdh=$(TOPDIR)/$(BUILD)/_smdh.bin

ifneq ($(strip $(ROMFS)),)
	export _3DSXFLAGS += --romfs=$(ROMFS)
endif

.PHONY: $(BUILD) clean all

#---------------------------------------------------------------------------------
all: $(BUILD)

$(TOPDIR)/$(BUILD)/_lzz_temp/%.cpp : %.lpp
	@mkdir -p $(shell dirname $@)
	@echo [LZZ] $(patsubst $(TOPDIR)/$(BUILD)/_lzz_temp/%.cpp,%.lpp,$@)
	@lzz -hx hpp -hd -sd -c -o $(shell dirname $@) $<

$(BUILD): $(LPPTARGET)
	@[ -d $@ ] || mkdir -p $@
	@[ -d out ] || mkdir -p out
	@find $(SOURCES) -type d -printf "%P\0" | xargs -0 -I {} mkdir -p $(BUILD)/{}
	@[ ! -d $(BUILD)/_lzz_temp ] || find $(BUILD)/_lzz_temp -type d -printf "%P\0" | xargs -0 -I {} mkdir -p $(BUILD)/{}
	@make --no-print-directory -C $(BUILD) -f $(CURDIR)/Makefile

#---------------------------------------------------------------------------------
clean:
	@echo clean ...
	@rm -rf $(BUILD) $(TARGET).elf out/


#---------------------------------------------------------------------------------
else

DEPENDS	:=	$(OFILES:.o=.d)

#---------------------------------------------------------------------------------
# main targets
#---------------------------------------------------------------------------------
.PHONY: all
ifeq ($(strip $(OSUC)),)
all: $(OUTPUT).cia $(OUTPUT).3dsx
else
all: $(OUTPUT).cia

$(OUTPUT).3dsx: $(OUTPUT).elf $(CURDIR)/_smdh.bin
endif

$(OUTPUT).elf: $(OFILES)

$(CURDIR)/_banner.bin: $(TOPDIR)/assets/banner.png $(TOPDIR)/assets/banner.wav
	@bannertool makebanner -i $(TOPDIR)/assets/banner.png -a $(TOPDIR)/assets/banner.wav -o $(CURDIR)/_banner.bin

$(CURDIR)/_smdh.bin: $(TOPDIR)/$(ICON)
	@bannertool makesmdh -s "$(APP_TITLE)" -l "$(APP_DESCRIPTION)" -p "$(APP_AUTHOR)" -i $(TOPDIR)/$(ICON) -o $(CURDIR)/_smdh.bin


$(CURDIR)/_strip.elf: $(OUTPUT).elf
	@cp $(OUTPUT).elf $(CURDIR)/_strip.elf
	@$(PREFIX)strip $(CURDIR)/_strip.elf

$(OUTPUT).cia: $(CURDIR)/_strip.elf $(CURDIR)/_banner.bin $(CURDIR)/_smdh.bin
	@makerom -f cia -o $(OUTPUT).cia -rsf $(TOPDIR)/assets/cia.rsf -target t -exefslogo -elf $(CURDIR)/_strip.elf -icon $(CURDIR)/_smdh.bin -banner $(CURDIR)/_banner.bin -DAPP_TITLE="$(APP_TITLE)" -DAPP_PRODUCT_CODE="$(APP_PRODUCT_CODE)" -DAPP_UNIQUE_ID="$(APP_UNIQUE_ID)" -DAPP_ROMFS="$(ROMFS)"
	@echo "built ... $(notdir $@)"

#---------------------------------------------------------------------------------
# you need a rule like this for each extension you use as binary data
#---------------------------------------------------------------------------------
%.bin.o: %.bin
#---------------------------------------------------------------------------------
	@echo $(notdir $<)
	@$(bin2o)


#---------------------------------------------------------------------------------------
-include $(DEPENDS)
#---------------------------------------------------------------------------------------
endif
#---------------------------------------------------------------------------------------

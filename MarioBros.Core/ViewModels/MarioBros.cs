using LcdGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MarioBros.ViewModels
{
    public class MarioBrosPin
    {
        public static readonly string[] Names = {
		"LF0"
		,
		"LF1"
		,
		"LF2"
		,
		"L2"
		,
		"L2L"
		,
		"L2R"
		,
		"L1"
		,
		"L1L"
		,
		"L1R"
		,
		"L0"
		,
		"L0L"
		,
		"L0R"
		,
		"M2"
		,
		"M2L"
		,
		"M2R"
		,
		"M1"
		,
		"M1L"
		,
		"M1R"
		,
		"M0"
		,
		"M0L"
		,
		"M0R"
		,
		"P0"
		,
		"P1"
		,
		"P2"
		,
		"P3"
		,
		"P4"
		,
		"P5"
		,
		"P5P6"
		,
		"P6"
		,
		"P7"
		,
		"P8"
		,
		"P9"
		,
		"P10"
		,
		"P11"
		,
		"P12"
		,
		"P13"
		,
		"P13P14"
		,
		"P14"
		,
		"P15"
		,
		"P16"
		,
		"P17"
		,
		"P18"
		,
		"P19"
		,
		"P20"
		,
		"P21"
		,
		"P21P22"
		,
		"P22"
		,
		"P23"
		,
		"P24"
		,
		"P25"
		,
		"P26"
		,
		"P27"
		,
		"P28"
		,
		"P29"
		,
		"P29P30"
		,
		"P30"
		,
		"P31"
		,
		"P32"
		,
		"P33"
		,
		"P34"
		,
		"P35"
		,
		"P36"
		,
		"P37"
		,
		"P37P38"
		,
		"P38"
		,
		"P39"
		,
		"P40"
		,
		"P41"
		,
		"PT0"
		,
		"PT1"
		,
		"PT2"
		,
		"PT3"
		,
		"PT4"
		,
		"PT5"
		,
		"PT6"
		,
		"PT7"
		,
		"PT8"
		,
		"PT9"
		,
		"T0"
		,
		"T1"
		,
		"T2"
		,
		"T3"
		,
		"T4"
		,
		"T5"
		,
		"PC0"
		,
		"PC1"
		,
		"PC2"
		,
		"MFR"
		,
		"MFL"
		,
		"LFR"
		,
		"LFL"
		,
		"MER"
		,
		"MEL"
		,
		"LER"
		,
		"LEL"
		,
		"AM"
		,
		"PM"
		,
		"PS"
		,
		"MT"
		};

		        public static readonly LcdGamePin LF0 = new LcdGamePin(0);
        public static readonly LcdGamePin LF1 = new LcdGamePin(1);
        public static readonly LcdGamePin LF2 = new LcdGamePin(2);
        public static readonly LcdGamePin L2 = new LcdGamePin(3);
        public static readonly LcdGamePin L2L = new LcdGamePin(4);
        public static readonly LcdGamePin L2R = new LcdGamePin(5);
        public static readonly LcdGamePin L1 = new LcdGamePin(6);
        public static readonly LcdGamePin L1L = new LcdGamePin(7);
        public static readonly LcdGamePin L1R = new LcdGamePin(8);
        public static readonly LcdGamePin L0 = new LcdGamePin(9);
        public static readonly LcdGamePin L0L = new LcdGamePin(10);
        public static readonly LcdGamePin L0R = new LcdGamePin(11);
        public static readonly LcdGamePin M2 = new LcdGamePin(12);
        public static readonly LcdGamePin M2L = new LcdGamePin(13);
        public static readonly LcdGamePin M2R = new LcdGamePin(14);
        public static readonly LcdGamePin M1 = new LcdGamePin(15);
        public static readonly LcdGamePin M1L = new LcdGamePin(16);
        public static readonly LcdGamePin M1R = new LcdGamePin(17);
        public static readonly LcdGamePin M0 = new LcdGamePin(18);
        public static readonly LcdGamePin M0L = new LcdGamePin(19);
        public static readonly LcdGamePin M0R = new LcdGamePin(20);
        public static readonly LcdGamePin P0 = new LcdGamePin(21);
        public static readonly LcdGamePin P1 = new LcdGamePin(22);
        public static readonly LcdGamePin P2 = new LcdGamePin(23);
        public static readonly LcdGamePin P3 = new LcdGamePin(24);
        public static readonly LcdGamePin P4 = new LcdGamePin(25);
        public static readonly LcdGamePin P5 = new LcdGamePin(26);
        public static readonly LcdGamePin P5P6 = new LcdGamePin(27);
        public static readonly LcdGamePin P6 = new LcdGamePin(28);
        public static readonly LcdGamePin P7 = new LcdGamePin(29);
        public static readonly LcdGamePin P8 = new LcdGamePin(30);
        public static readonly LcdGamePin P9 = new LcdGamePin(31);
        public static readonly LcdGamePin P10 = new LcdGamePin(32);
        public static readonly LcdGamePin P11 = new LcdGamePin(33);
        public static readonly LcdGamePin P12 = new LcdGamePin(34);
        public static readonly LcdGamePin P13 = new LcdGamePin(35);
        public static readonly LcdGamePin P13P14 = new LcdGamePin(36);
        public static readonly LcdGamePin P14 = new LcdGamePin(37);
        public static readonly LcdGamePin P15 = new LcdGamePin(38);
        public static readonly LcdGamePin P16 = new LcdGamePin(39);
        public static readonly LcdGamePin P17 = new LcdGamePin(40);
        public static readonly LcdGamePin P18 = new LcdGamePin(41);
        public static readonly LcdGamePin P19 = new LcdGamePin(42);
        public static readonly LcdGamePin P20 = new LcdGamePin(43);
        public static readonly LcdGamePin P21 = new LcdGamePin(44);
        public static readonly LcdGamePin P21P22 = new LcdGamePin(45);
        public static readonly LcdGamePin P22 = new LcdGamePin(46);
        public static readonly LcdGamePin P23 = new LcdGamePin(47);
        public static readonly LcdGamePin P24 = new LcdGamePin(48);
        public static readonly LcdGamePin P25 = new LcdGamePin(49);
        public static readonly LcdGamePin P26 = new LcdGamePin(50);
        public static readonly LcdGamePin P27 = new LcdGamePin(51);
        public static readonly LcdGamePin P28 = new LcdGamePin(52);
        public static readonly LcdGamePin P29 = new LcdGamePin(53);
        public static readonly LcdGamePin P29P30 = new LcdGamePin(54);
        public static readonly LcdGamePin P30 = new LcdGamePin(55);
        public static readonly LcdGamePin P31 = new LcdGamePin(56);
        public static readonly LcdGamePin P32 = new LcdGamePin(57);
        public static readonly LcdGamePin P33 = new LcdGamePin(58);
        public static readonly LcdGamePin P34 = new LcdGamePin(59);
        public static readonly LcdGamePin P35 = new LcdGamePin(60);
        public static readonly LcdGamePin P36 = new LcdGamePin(61);
        public static readonly LcdGamePin P37 = new LcdGamePin(62);
        public static readonly LcdGamePin P37P38 = new LcdGamePin(63);
        public static readonly LcdGamePin P38 = new LcdGamePin(64);
        public static readonly LcdGamePin P39 = new LcdGamePin(65);
        public static readonly LcdGamePin P40 = new LcdGamePin(66);
        public static readonly LcdGamePin P41 = new LcdGamePin(67);
        public static readonly LcdGamePin PT0 = new LcdGamePin(68);
        public static readonly LcdGamePin PT1 = new LcdGamePin(69);
        public static readonly LcdGamePin PT2 = new LcdGamePin(70);
        public static readonly LcdGamePin PT3 = new LcdGamePin(71);
        public static readonly LcdGamePin PT4 = new LcdGamePin(72);
        public static readonly LcdGamePin PT5 = new LcdGamePin(73);
        public static readonly LcdGamePin PT6 = new LcdGamePin(74);
        public static readonly LcdGamePin PT7 = new LcdGamePin(75);
        public static readonly LcdGamePin PT8 = new LcdGamePin(76);
        public static readonly LcdGamePin PT9 = new LcdGamePin(77);
        public static readonly LcdGamePin T0 = new LcdGamePin(78);
        public static readonly LcdGamePin T1 = new LcdGamePin(79);
        public static readonly LcdGamePin T2 = new LcdGamePin(80);
        public static readonly LcdGamePin T3 = new LcdGamePin(81);
        public static readonly LcdGamePin T4 = new LcdGamePin(82);
        public static readonly LcdGamePin T5 = new LcdGamePin(83);
        public static readonly LcdGamePin PC0 = new LcdGamePin(84);
        public static readonly LcdGamePin PC1 = new LcdGamePin(85);
        public static readonly LcdGamePin PC2 = new LcdGamePin(86);
        public static readonly LcdGamePin MFR = new LcdGamePin(87);
        public static readonly LcdGamePin MFL = new LcdGamePin(88);
        public static readonly LcdGamePin LFR = new LcdGamePin(89);
        public static readonly LcdGamePin LFL = new LcdGamePin(90);
        public static readonly LcdGamePin MER = new LcdGamePin(91);
        public static readonly LcdGamePin MEL = new LcdGamePin(92);
        public static readonly LcdGamePin LER = new LcdGamePin(93);
        public static readonly LcdGamePin LEL = new LcdGamePin(94);
        public static readonly LcdGamePin AM = new LcdGamePin(95);
        public static readonly LcdGamePin PM = new LcdGamePin(96);
        public static readonly LcdGamePin PS = new LcdGamePin(97);
        public static readonly LcdGamePin MT = new LcdGamePin(98);

        public static readonly int Count = 99;
	}

    public partial class MarioBrosViewModel
    {
        public LcdGamePinState LF0
        {
            get
            {
                return Get(MarioBrosPin.LF0);
            }

            set
            {
                Set(MarioBrosPin.LF0, value);
            }
        }
        public LcdGamePinState LF1
        {
            get
            {
                return Get(MarioBrosPin.LF1);
            }

            set
            {
                Set(MarioBrosPin.LF1, value);
            }
        }
        public LcdGamePinState LF2
        {
            get
            {
                return Get(MarioBrosPin.LF2);
            }

            set
            {
                Set(MarioBrosPin.LF2, value);
            }
        }
        public LcdGamePinState L2
        {
            get
            {
                return Get(MarioBrosPin.L2);
            }

            set
            {
                Set(MarioBrosPin.L2, value);
            }
        }
        public LcdGamePinState L2L
        {
            get
            {
                return Get(MarioBrosPin.L2L);
            }

            set
            {
                Set(MarioBrosPin.L2L, value);
            }
        }
        public LcdGamePinState L2R
        {
            get
            {
                return Get(MarioBrosPin.L2R);
            }

            set
            {
                Set(MarioBrosPin.L2R, value);
            }
        }
        public LcdGamePinState L1
        {
            get
            {
                return Get(MarioBrosPin.L1);
            }

            set
            {
                Set(MarioBrosPin.L1, value);
            }
        }
        public LcdGamePinState L1L
        {
            get
            {
                return Get(MarioBrosPin.L1L);
            }

            set
            {
                Set(MarioBrosPin.L1L, value);
            }
        }
        public LcdGamePinState L1R
        {
            get
            {
                return Get(MarioBrosPin.L1R);
            }

            set
            {
                Set(MarioBrosPin.L1R, value);
            }
        }
        public LcdGamePinState L0
        {
            get
            {
                return Get(MarioBrosPin.L0);
            }

            set
            {
                Set(MarioBrosPin.L0, value);
            }
        }
        public LcdGamePinState L0L
        {
            get
            {
                return Get(MarioBrosPin.L0L);
            }

            set
            {
                Set(MarioBrosPin.L0L, value);
            }
        }
        public LcdGamePinState L0R
        {
            get
            {
                return Get(MarioBrosPin.L0R);
            }

            set
            {
                Set(MarioBrosPin.L0R, value);
            }
        }
        public LcdGamePinState M2
        {
            get
            {
                return Get(MarioBrosPin.M2);
            }

            set
            {
                Set(MarioBrosPin.M2, value);
            }
        }
        public LcdGamePinState M2L
        {
            get
            {
                return Get(MarioBrosPin.M2L);
            }

            set
            {
                Set(MarioBrosPin.M2L, value);
            }
        }
        public LcdGamePinState M2R
        {
            get
            {
                return Get(MarioBrosPin.M2R);
            }

            set
            {
                Set(MarioBrosPin.M2R, value);
            }
        }
        public LcdGamePinState M1
        {
            get
            {
                return Get(MarioBrosPin.M1);
            }

            set
            {
                Set(MarioBrosPin.M1, value);
            }
        }
        public LcdGamePinState M1L
        {
            get
            {
                return Get(MarioBrosPin.M1L);
            }

            set
            {
                Set(MarioBrosPin.M1L, value);
            }
        }
        public LcdGamePinState M1R
        {
            get
            {
                return Get(MarioBrosPin.M1R);
            }

            set
            {
                Set(MarioBrosPin.M1R, value);
            }
        }
        public LcdGamePinState M0
        {
            get
            {
                return Get(MarioBrosPin.M0);
            }

            set
            {
                Set(MarioBrosPin.M0, value);
            }
        }
        public LcdGamePinState M0L
        {
            get
            {
                return Get(MarioBrosPin.M0L);
            }

            set
            {
                Set(MarioBrosPin.M0L, value);
            }
        }
        public LcdGamePinState M0R
        {
            get
            {
                return Get(MarioBrosPin.M0R);
            }

            set
            {
                Set(MarioBrosPin.M0R, value);
            }
        }
        public LcdGamePinState P0
        {
            get
            {
                return Get(MarioBrosPin.P0);
            }

            set
            {
                Set(MarioBrosPin.P0, value);
            }
        }
        public LcdGamePinState P1
        {
            get
            {
                return Get(MarioBrosPin.P1);
            }

            set
            {
                Set(MarioBrosPin.P1, value);
            }
        }
        public LcdGamePinState P2
        {
            get
            {
                return Get(MarioBrosPin.P2);
            }

            set
            {
                Set(MarioBrosPin.P2, value);
            }
        }
        public LcdGamePinState P3
        {
            get
            {
                return Get(MarioBrosPin.P3);
            }

            set
            {
                Set(MarioBrosPin.P3, value);
            }
        }
        public LcdGamePinState P4
        {
            get
            {
                return Get(MarioBrosPin.P4);
            }

            set
            {
                Set(MarioBrosPin.P4, value);
            }
        }
        public LcdGamePinState P5
        {
            get
            {
                return Get(MarioBrosPin.P5);
            }

            set
            {
                Set(MarioBrosPin.P5, value);
            }
        }
        public LcdGamePinState P5P6
        {
            get
            {
                return Get(MarioBrosPin.P5P6);
            }

            set
            {
                Set(MarioBrosPin.P5P6, value);
            }
        }
        public LcdGamePinState P6
        {
            get
            {
                return Get(MarioBrosPin.P6);
            }

            set
            {
                Set(MarioBrosPin.P6, value);
            }
        }
        public LcdGamePinState P7
        {
            get
            {
                return Get(MarioBrosPin.P7);
            }

            set
            {
                Set(MarioBrosPin.P7, value);
            }
        }
        public LcdGamePinState P8
        {
            get
            {
                return Get(MarioBrosPin.P8);
            }

            set
            {
                Set(MarioBrosPin.P8, value);
            }
        }
        public LcdGamePinState P9
        {
            get
            {
                return Get(MarioBrosPin.P9);
            }

            set
            {
                Set(MarioBrosPin.P9, value);
            }
        }
        public LcdGamePinState P10
        {
            get
            {
                return Get(MarioBrosPin.P10);
            }

            set
            {
                Set(MarioBrosPin.P10, value);
            }
        }
        public LcdGamePinState P11
        {
            get
            {
                return Get(MarioBrosPin.P11);
            }

            set
            {
                Set(MarioBrosPin.P11, value);
            }
        }
        public LcdGamePinState P12
        {
            get
            {
                return Get(MarioBrosPin.P12);
            }

            set
            {
                Set(MarioBrosPin.P12, value);
            }
        }
        public LcdGamePinState P13
        {
            get
            {
                return Get(MarioBrosPin.P13);
            }

            set
            {
                Set(MarioBrosPin.P13, value);
            }
        }
        public LcdGamePinState P13P14
        {
            get
            {
                return Get(MarioBrosPin.P13P14);
            }

            set
            {
                Set(MarioBrosPin.P13P14, value);
            }
        }
        public LcdGamePinState P14
        {
            get
            {
                return Get(MarioBrosPin.P14);
            }

            set
            {
                Set(MarioBrosPin.P14, value);
            }
        }
        public LcdGamePinState P15
        {
            get
            {
                return Get(MarioBrosPin.P15);
            }

            set
            {
                Set(MarioBrosPin.P15, value);
            }
        }
        public LcdGamePinState P16
        {
            get
            {
                return Get(MarioBrosPin.P16);
            }

            set
            {
                Set(MarioBrosPin.P16, value);
            }
        }
        public LcdGamePinState P17
        {
            get
            {
                return Get(MarioBrosPin.P17);
            }

            set
            {
                Set(MarioBrosPin.P17, value);
            }
        }
        public LcdGamePinState P18
        {
            get
            {
                return Get(MarioBrosPin.P18);
            }

            set
            {
                Set(MarioBrosPin.P18, value);
            }
        }
        public LcdGamePinState P19
        {
            get
            {
                return Get(MarioBrosPin.P19);
            }

            set
            {
                Set(MarioBrosPin.P19, value);
            }
        }
        public LcdGamePinState P20
        {
            get
            {
                return Get(MarioBrosPin.P20);
            }

            set
            {
                Set(MarioBrosPin.P20, value);
            }
        }
        public LcdGamePinState P21
        {
            get
            {
                return Get(MarioBrosPin.P21);
            }

            set
            {
                Set(MarioBrosPin.P21, value);
            }
        }
        public LcdGamePinState P21P22
        {
            get
            {
                return Get(MarioBrosPin.P21P22);
            }

            set
            {
                Set(MarioBrosPin.P21P22, value);
            }
        }
        public LcdGamePinState P22
        {
            get
            {
                return Get(MarioBrosPin.P22);
            }

            set
            {
                Set(MarioBrosPin.P22, value);
            }
        }
        public LcdGamePinState P23
        {
            get
            {
                return Get(MarioBrosPin.P23);
            }

            set
            {
                Set(MarioBrosPin.P23, value);
            }
        }
        public LcdGamePinState P24
        {
            get
            {
                return Get(MarioBrosPin.P24);
            }

            set
            {
                Set(MarioBrosPin.P24, value);
            }
        }
        public LcdGamePinState P25
        {
            get
            {
                return Get(MarioBrosPin.P25);
            }

            set
            {
                Set(MarioBrosPin.P25, value);
            }
        }
        public LcdGamePinState P26
        {
            get
            {
                return Get(MarioBrosPin.P26);
            }

            set
            {
                Set(MarioBrosPin.P26, value);
            }
        }
        public LcdGamePinState P27
        {
            get
            {
                return Get(MarioBrosPin.P27);
            }

            set
            {
                Set(MarioBrosPin.P27, value);
            }
        }
        public LcdGamePinState P28
        {
            get
            {
                return Get(MarioBrosPin.P28);
            }

            set
            {
                Set(MarioBrosPin.P28, value);
            }
        }
        public LcdGamePinState P29
        {
            get
            {
                return Get(MarioBrosPin.P29);
            }

            set
            {
                Set(MarioBrosPin.P29, value);
            }
        }
        public LcdGamePinState P29P30
        {
            get
            {
                return Get(MarioBrosPin.P29P30);
            }

            set
            {
                Set(MarioBrosPin.P29P30, value);
            }
        }
        public LcdGamePinState P30
        {
            get
            {
                return Get(MarioBrosPin.P30);
            }

            set
            {
                Set(MarioBrosPin.P30, value);
            }
        }
        public LcdGamePinState P31
        {
            get
            {
                return Get(MarioBrosPin.P31);
            }

            set
            {
                Set(MarioBrosPin.P31, value);
            }
        }
        public LcdGamePinState P32
        {
            get
            {
                return Get(MarioBrosPin.P32);
            }

            set
            {
                Set(MarioBrosPin.P32, value);
            }
        }
        public LcdGamePinState P33
        {
            get
            {
                return Get(MarioBrosPin.P33);
            }

            set
            {
                Set(MarioBrosPin.P33, value);
            }
        }
        public LcdGamePinState P34
        {
            get
            {
                return Get(MarioBrosPin.P34);
            }

            set
            {
                Set(MarioBrosPin.P34, value);
            }
        }
        public LcdGamePinState P35
        {
            get
            {
                return Get(MarioBrosPin.P35);
            }

            set
            {
                Set(MarioBrosPin.P35, value);
            }
        }
        public LcdGamePinState P36
        {
            get
            {
                return Get(MarioBrosPin.P36);
            }

            set
            {
                Set(MarioBrosPin.P36, value);
            }
        }
        public LcdGamePinState P37
        {
            get
            {
                return Get(MarioBrosPin.P37);
            }

            set
            {
                Set(MarioBrosPin.P37, value);
            }
        }
        public LcdGamePinState P37P38
        {
            get
            {
                return Get(MarioBrosPin.P37P38);
            }

            set
            {
                Set(MarioBrosPin.P37P38, value);
            }
        }
        public LcdGamePinState P38
        {
            get
            {
                return Get(MarioBrosPin.P38);
            }

            set
            {
                Set(MarioBrosPin.P38, value);
            }
        }
        public LcdGamePinState P39
        {
            get
            {
                return Get(MarioBrosPin.P39);
            }

            set
            {
                Set(MarioBrosPin.P39, value);
            }
        }
        public LcdGamePinState P40
        {
            get
            {
                return Get(MarioBrosPin.P40);
            }

            set
            {
                Set(MarioBrosPin.P40, value);
            }
        }
        public LcdGamePinState P41
        {
            get
            {
                return Get(MarioBrosPin.P41);
            }

            set
            {
                Set(MarioBrosPin.P41, value);
            }
        }
        public LcdGamePinState PT0
        {
            get
            {
                return Get(MarioBrosPin.PT0);
            }

            set
            {
                Set(MarioBrosPin.PT0, value);
            }
        }
        public LcdGamePinState PT1
        {
            get
            {
                return Get(MarioBrosPin.PT1);
            }

            set
            {
                Set(MarioBrosPin.PT1, value);
            }
        }
        public LcdGamePinState PT2
        {
            get
            {
                return Get(MarioBrosPin.PT2);
            }

            set
            {
                Set(MarioBrosPin.PT2, value);
            }
        }
        public LcdGamePinState PT3
        {
            get
            {
                return Get(MarioBrosPin.PT3);
            }

            set
            {
                Set(MarioBrosPin.PT3, value);
            }
        }
        public LcdGamePinState PT4
        {
            get
            {
                return Get(MarioBrosPin.PT4);
            }

            set
            {
                Set(MarioBrosPin.PT4, value);
            }
        }
        public LcdGamePinState PT5
        {
            get
            {
                return Get(MarioBrosPin.PT5);
            }

            set
            {
                Set(MarioBrosPin.PT5, value);
            }
        }
        public LcdGamePinState PT6
        {
            get
            {
                return Get(MarioBrosPin.PT6);
            }

            set
            {
                Set(MarioBrosPin.PT6, value);
            }
        }
        public LcdGamePinState PT7
        {
            get
            {
                return Get(MarioBrosPin.PT7);
            }

            set
            {
                Set(MarioBrosPin.PT7, value);
            }
        }
        public LcdGamePinState PT8
        {
            get
            {
                return Get(MarioBrosPin.PT8);
            }

            set
            {
                Set(MarioBrosPin.PT8, value);
            }
        }
        public LcdGamePinState PT9
        {
            get
            {
                return Get(MarioBrosPin.PT9);
            }

            set
            {
                Set(MarioBrosPin.PT9, value);
            }
        }
        public LcdGamePinState T0
        {
            get
            {
                return Get(MarioBrosPin.T0);
            }

            set
            {
                Set(MarioBrosPin.T0, value);
            }
        }
        public LcdGamePinState T1
        {
            get
            {
                return Get(MarioBrosPin.T1);
            }

            set
            {
                Set(MarioBrosPin.T1, value);
            }
        }
        public LcdGamePinState T2
        {
            get
            {
                return Get(MarioBrosPin.T2);
            }

            set
            {
                Set(MarioBrosPin.T2, value);
            }
        }
        public LcdGamePinState T3
        {
            get
            {
                return Get(MarioBrosPin.T3);
            }

            set
            {
                Set(MarioBrosPin.T3, value);
            }
        }
        public LcdGamePinState T4
        {
            get
            {
                return Get(MarioBrosPin.T4);
            }

            set
            {
                Set(MarioBrosPin.T4, value);
            }
        }
        public LcdGamePinState T5
        {
            get
            {
                return Get(MarioBrosPin.T5);
            }

            set
            {
                Set(MarioBrosPin.T5, value);
            }
        }
        public LcdGamePinState PC0
        {
            get
            {
                return Get(MarioBrosPin.PC0);
            }

            set
            {
                Set(MarioBrosPin.PC0, value);
            }
        }
        public LcdGamePinState PC1
        {
            get
            {
                return Get(MarioBrosPin.PC1);
            }

            set
            {
                Set(MarioBrosPin.PC1, value);
            }
        }
        public LcdGamePinState PC2
        {
            get
            {
                return Get(MarioBrosPin.PC2);
            }

            set
            {
                Set(MarioBrosPin.PC2, value);
            }
        }
        public LcdGamePinState MFR
        {
            get
            {
                return Get(MarioBrosPin.MFR);
            }

            set
            {
                Set(MarioBrosPin.MFR, value);
            }
        }
        public LcdGamePinState MFL
        {
            get
            {
                return Get(MarioBrosPin.MFL);
            }

            set
            {
                Set(MarioBrosPin.MFL, value);
            }
        }
        public LcdGamePinState LFR
        {
            get
            {
                return Get(MarioBrosPin.LFR);
            }

            set
            {
                Set(MarioBrosPin.LFR, value);
            }
        }
        public LcdGamePinState LFL
        {
            get
            {
                return Get(MarioBrosPin.LFL);
            }

            set
            {
                Set(MarioBrosPin.LFL, value);
            }
        }
        public LcdGamePinState MER
        {
            get
            {
                return Get(MarioBrosPin.MER);
            }

            set
            {
                Set(MarioBrosPin.MER, value);
            }
        }
        public LcdGamePinState MEL
        {
            get
            {
                return Get(MarioBrosPin.MEL);
            }

            set
            {
                Set(MarioBrosPin.MEL, value);
            }
        }
        public LcdGamePinState LER
        {
            get
            {
                return Get(MarioBrosPin.LER);
            }

            set
            {
                Set(MarioBrosPin.LER, value);
            }
        }
        public LcdGamePinState LEL
        {
            get
            {
                return Get(MarioBrosPin.LEL);
            }

            set
            {
                Set(MarioBrosPin.LEL, value);
            }
        }
        public LcdGamePinState AM
        {
            get
            {
                return Get(MarioBrosPin.AM);
            }

            set
            {
                Set(MarioBrosPin.AM, value);
            }
        }
        public LcdGamePinState PM
        {
            get
            {
                return Get(MarioBrosPin.PM);
            }

            set
            {
                Set(MarioBrosPin.PM, value);
            }
        }
        public LcdGamePinState PS
        {
            get
            {
                return Get(MarioBrosPin.PS);
            }

            set
            {
                Set(MarioBrosPin.PS, value);
            }
        }
        public LcdGamePinState MT
        {
            get
            {
                return Get(MarioBrosPin.MT);
            }

            set
            {
                Set(MarioBrosPin.MT, value);
            }
        }
	}
}
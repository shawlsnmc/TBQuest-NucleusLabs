using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleusLabs
{
    /// <summary>
    /// static class sets the layout of the game screen
    /// </summary>
    //public static class ConsoleLayout
    //{
    //    //
    //    // console window configuration
    //    //
    //    public static int WindowWidth = 160;
    //    public static int WindowHeight = 35;
    //    public static int WindowPositionLeft = 0;
    //    public static int WindowPositionTop = 0;

    //    //
    //    // header configuration
    //    //
    //    // Note: The header height is the sum of lines of text and 2 blank lines.
    //    //       The top positions of other elements should be adjusted accordingly and
    //    //       the number of lines of text displayed by the header should not change.
    //    public static int HeaderWidth = 160;
    //    public static int HeaderPositionLeft = 0;
    //    public static int HeaderPositionTop = 0;

    //    //
    //    // footer configuration
    //    //
    //    // Note: The footer height is the sum of lines of text and 2 blank lines.
    //    //       The heights of other elements should be adjusted accordingly and
    //    //       the number of lines of text displayed by the footer should not change.
    //    public static int FooterWidth = 160;
    //    public static int FooterPositionLeft = 0;
    //    public static int FooterPositionTop = 32;

    //    //
    //    // menu box configuration
    //    //
    //    public static int MenuBoxWidth = 37;
    //    public static int MenuBoxHeight = 20;
    //    public static int MenuBoxPositionLeft = 122;
    //    public static int MenuBoxPositionTop = 3;

    //    //
    //    // message box configuration
    //    //
    //    public static int MessageBoxWidth = 120;
    //    public static int MessageBoxHeight = 25;
    //    public static int MessageBoxPositionLeft = 1;
    //    public static int MessageBoxPositionTop = 3;

    //    //
    //    // input box configuration
    //    //
    //    public static int InputBoxWidth = 120;
    //    public static int InputBoxHeight = 4;
    //    public static int InputBoxPositionLeft = 1;
    //    public static int InputBoxPositionTop = 28;

    //    //
    //    // status box configuration
    //    //
    //    public static int StatusBoxWidth = 37;
    //    public static int StatusBoxHeight = 9;
    //    public static int StatusBoxPositionLeft = 122;
    //    public static int StatusBoxPositionTop = 23;
    //}
    public static class ConsoleLayout
    {
        //
        // console window configuration
        //
        public static int WindowWidth = 150; //was 160
        public static int WindowHeight = 60; //was 35
        public static int WindowPositionLeft = 0;
        public static int WindowPositionTop = 0;

        //
        // input box configuration
        //
        public static int InputBoxHeight = 4;


        //
        // header configuration
        //
        // Note: The header height is the sum of lines of text and 2 blank lines.
        //       The top positions of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the header should not change.
        public static int HeaderWidth = WindowWidth; // was 150
        public static int HeaderPositionLeft = 0;
        public static int HeaderPositionTop = 0;
        public static int HeaderHeight = 3; //not really used by the header

        //
        // footer configuration
        //
        // Note: The footer height is the sum of lines of text and 2 blank lines.
        //       The heights of other elements should be adjusted accordingly and
        //       the number of lines of text displayed by the footer should not change.
        public static int FooterWidth = WindowWidth; //was 160
        public static int FooterPositionLeft = 0;
        public static int FooterHeight = HeaderHeight; //not really used by the footer
        public static int FooterPositionTop = WindowHeight - FooterHeight; //was 32

        //
        // status box configuration
        //
        public static int StatusBoxWidth = 32;
        public static int StatusBoxHeight = WindowHeight - (HeaderHeight + FooterHeight);
        public static int StatusBoxPositionLeft = 1; //was 122
        public static int StatusBoxPositionTop = 3; //was 23
        //public static int StatusBoxPositionTop = 3 + MenuBoxHeight; //was 23

        //
        // message box configuration
        //
        public static int MessageBoxWidth = WindowWidth - (StatusBoxWidth * 2) - 4; //was 120
        public static int MessageBoxHeight = WindowHeight - (HeaderHeight + FooterHeight + InputBoxHeight); //was 25
        //public static int MessageBoxHeight = WindowHeight - 6 - InputBoxHeight; //was 25
        public static int MessageBoxPositionLeft = StatusBoxWidth + 2;
        public static int MessageBoxPositionTop = StatusBoxPositionTop;


        public static int InputBoxPositionTop = MenuBoxPositionTop + MessageBoxHeight + HeaderHeight; //was 28


        //
        // input box configuration
        //
        public static int InputBoxWidth = MessageBoxWidth; //was 120
        public static int InputBoxPositionLeft = MessageBoxPositionLeft;
        /// public static int InputBoxPositionTop = 23; //was 28 moved down
        //public static int InputBoxPositionTop = 3 + MessageBoxHeight; //was 28


        //
        // menu box configuration
        //
        public static int MenuBoxWidth = StatusBoxWidth;
        //        public static int MenuBoxHeight = WindowHeight - 16 - StatusBoxHeight; //was 20
        public static int MenuBoxHeight = WindowHeight - (HeaderHeight + FooterHeight); //was 20
        public static int MenuBoxPositionLeft = StatusBoxWidth + MessageBoxWidth + 3; //was 122
        public static int MenuBoxPositionTop = StatusBoxPositionTop;


    }
}

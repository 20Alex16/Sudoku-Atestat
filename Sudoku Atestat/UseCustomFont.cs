using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Atestat
{
    class UseCustomFont
    {
        static private FontFamily customFont() // functie luata de pe internet
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            try
            {
                pfc.AddFontFile("Seven Segment.ttf");
            }
            catch (Exception e) {
                pfc.AddFontFile("../../Resources/Seven Segment.ttf");
            }

            return pfc.Families.First();
        }

        static private FontFamily font;
        static bool ok = false;

        public static FontFamily getFont()
        {
            if (!ok)
            {
                font = customFont();
                ok = true;
            }

            return font;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wordle
{
    public class Betu : Button
    {
        private static string[] magyarAbece = new string[]
        {
            "_", "A", "Á", "B", "C", "Cs", "D", "Dz", "Dzs", "E", "É", "F", "G", "Gy",
            "H", "I", "Í", "J", "K", "L", "Ly", "M", "N", "Ny", "O", "Ó", "Ö",
            "Ő", "P", "Q", "R", "S", "Sz", "T", "Ty", "U", "Ú", "Ü", "Ű", "V",
            "W", "X", "Y", "Z", "Zs"
        };

        private String word_invis { get; set; }
        private int index { get; set; }

        private String feladvany { get; set; }

        public Betu(String betu, string feladvany)
        {
            word_invis = betu;
            this.Width = 100;
            this.Height = 100;
            this.Margin = new System.Windows.Thickness(25);
            this.FontSize = 70;
            index = 0;
            Content = magyarAbece[index];
        }

        protected override void OnClick()
        {
            index++;
            if (index >= magyarAbece.Length) index = 1;
            Content = magyarAbece[index];
            Color();
            base.OnClick();
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            index--;
            if (index < 1) index = magyarAbece.Length - 1;
            Content = magyarAbece[index];
            Color();
            base.OnMouseRightButtonDown(e);
        }

        private void Color()
        {
            if (magyarAbece[index] == word_invis)
            {
                this.Background = Brushes.ForestGreen;
                this.Foreground = Brushes.White;
            }
            else if (feladvany.Contains(magyarAbece[index]))
            {
                this.Background = Brushes.Yellow;
                this.Foreground = Brushes.Black;
            }
            else
            {
                this.Background = Brushes.LightGray;
                this.Foreground = Brushes.Black;
            }
        }
    }
}

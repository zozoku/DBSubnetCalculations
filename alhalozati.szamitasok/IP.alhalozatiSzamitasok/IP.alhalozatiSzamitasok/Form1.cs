// készítette 13b /1csoport/, befejezte:  KZ
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlhalozatiSzamitasok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PontozottDecIP = "0.0.0.0";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void TBIPbekeres_TextChanged(object sender, EventArgs e)
        {
            //if (Helyes_IP_Ertek(Text.Split('.')))
            //    //Bok_Click(sender, e);
            //else;
            //PontozottDecIP = Text;
        }

        private void TBprefix_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void B0_Click(object sender, EventArgs e)
        {
            TBIPbekeres.Text += 0.ToString(); // "0"
        }

        private void B11_Click(object sender, EventArgs e)
        {
            TBIPbekeres.Text += 1.ToString(); // "1"
        }

        private void Bpont_Click(object sender, EventArgs e)
        {
            TBIPbekeres.Text += (sender as Button).Text;
        }

        private void Btorles_Click(object sender, EventArgs e)
        {
            TBIPbekeres.Text = "";
        }

        public string RemoveLastCharacter(string original)
        {
            string result = "";
            for (int i = 0; i < original.Length - 1; i++)
            {
                result += original[i];
            }
            return result;
        }

        // decimális számot (szám -- int -- formátum)  binárisba vált (karakterlánc a visszaadott érték (típusa)! )
        public string DecToBin(int number)
        {
            string result = "";
            int temp = number;
            while (temp !=0 )
            {
                result = (temp % 2).ToString() + result;
                temp /= 2;
            }
            return result;
        }
        // decimális számot (string formátum) binárisba vált (karakterlánc itt is a visszaadott érték (típusa)! )
        public string DecToBin(string strNumber)
        {
            string result = "";
            int temp = int.Parse(strNumber);
            while (temp != 0)
            {
                result = (temp % 2).ToString() + result;
                temp /= 2;
            }
            return result;
        }

        private void Bvissza_Click(object sender, EventArgs e)
        {
            TBIPbekeres.Text = RemoveLastCharacter(TBIPbekeres.Text);
        }

        public string Feltoltes(int count, bool fromLeft, char fillChar)
        {
            string result = "";
            for (int i = 0; i < 8-count; i++)
            {
                result += "1";
            }
            if (fromLeft)
                for (int j = 0; j < count; j++)
                {
                    result = fillChar + result;
                }
            else            
                for (int j = 0; j < count; j++)
                {
                    result += fillChar;
                }
            return result;
        }

        private bool BetweenTwoNumber(long number, long bottom, long up)
        {
            return (number >= bottom && number <= up);
        }

        //private bool Helyes_IP_Ertek(string[] ipDecimalStrings)
        //{
        //    int[] ipDecimals = new int[ipDecimalStrings.Length] ;
        //    for (int i = 0; i < ipDecimals.Length; i++)
        //    {
        //        ipDecimals[i] = int.Parse(ipDecimalStrings[i]);
        //    }
        //    return  BetweenTwoNumber(ipDecimals[0], 0, 255)
        //            &&
        //            BetweenTwoNumber(ipDecimals[1], 0, 255)
        //            &&
        //            BetweenTwoNumber(ipDecimals[2], 0, 255)
        //            &&
        //            BetweenTwoNumber(ipDecimals[3], 0, 255);
        //}

        private bool Helyes_IP_Ertek(string dottedIPstring)
        {
            // ha nem tartalmaz pontokat a paraméter vagy nincs pontosan 4 számérték pontokkal elválasztva
            // akkor "hamis" értékkel tér vissza
            if ( !dottedIPstring.Contains(".") || (dottedIPstring.Split('.').Length != 4))
                return false;
            // ha "rendben van" a karakterlánc (pl. 10.0.0.0 formátumú, akkor: 
            string[] ipDecimalisak = dottedIPstring.Split('.');
            //byte[] ipDecimalisak = new byte[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    ipDecimals[i] = byte.Parse(ipDecimalisak[i]);
            //}
            return BetweenTwoNumber(long.Parse(ipDecimalisak[0]), 0, 255)
                    &&
                    BetweenTwoNumber(long.Parse(ipDecimalisak[1]), 0, 255)
                    &&
                    BetweenTwoNumber(long.Parse(ipDecimalisak[2]), 0, 255)
                    &&
                    BetweenTwoNumber(long.Parse(ipDecimalisak[3]), 0, 255);
        }


        const string binarisEgyesek = "11111111";
        const string binarisNullak = "00000000";
        const string uzenet = " osztályú nyilvános, azaz publikus IP cím";
        const string uzenet2 = " osztályú privát IP cím";
        private string pontozottDecIP;
        public string PontozottDecIP {
            get
            {
                return pontozottDecIP;
            }
            set
            {
                
                if (Helyes_IP_Ertek(value))
                    pontozottDecIP = value;
                else
                {
                    //value = "192.168.100.100";
                    //pontozottDecIP = value;
                    string uzenet = "Ld. az \"Adja meg az IP címet\" alatti szövegdobozban:";
                    uzenet += "\n\n\tNem helyes módon szerepel vagy nincs megadva az IP cím.";
                    uzenet += "\n\n\n[ a helyes formátum: x.y.z.w,  ahol\n\t0 <= x, y, z, w <= 255, \tpl. 192.168.10.1 ]";                    
                    MessageBox.Show(uzenet);
                }
            }                
        }
        

        private void Bok_Click(object sender, EventArgs e)
        {
            string prefix = "0";
            PontozottDecIP = TBIPbekeres.Text;
            string [] part = PontozottDecIP.Split('.');
            int elso = int.Parse(part[0]);
            int masodik = int.Parse(part[1]);
            // maszk - mezőkhöz
            string feltoltendo = "";

            if (elso <= 127)
            {
                TBosztaly.Text = "A";
                prefix = "8";
                if (elso == 10)
                    TBosztalykiiras.Text = TBosztaly.Text + uzenet2;
                else TBosztalykiiras.Text = TBosztaly.Text + uzenet;
            }
            else if ( elso < 192)
            {
                TBosztaly.Text = "B";
                prefix = "16";
                if (elso == 172 && masodik > 15 && masodik < 32)
                    TBosztalykiiras.Text = TBosztaly.Text + uzenet2;
                else TBosztalykiiras.Text = TBosztaly.Text + uzenet;
            }
            else
            {
                TBosztaly.Text = "C";
                prefix = "24";
                if (elso == 192 && masodik == 168) 
                    TBosztalykiiras.Text = TBosztaly.Text + uzenet2;
                else TBosztalykiiras.Text = TBosztaly.Text + uzenet;                
            }
            TBprefix.Text = "Prefix: " + prefix;
            TBbin1.Text = DecToBin(part[0]);
            TBbin2.Text = DecToBin(part[1]);
            TBbin3.Text = DecToBin(part[2]);
            TBbin4.Text = DecToBin(part[3]);
            
            
            //ez mindig csupa egyes (8-nál kisebb nem lehet a prefix)
            TBbinmaszk1.Text = binarisEgyesek;
            int prefixNumber = int.Parse(prefix);
            int deficit = 0;
            if (prefixNumber >= 24)
            {
                TBbinmaszk2.Text = binarisEgyesek;
                TBbinmaszk3.Text = binarisEgyesek;
                deficit = prefixNumber - 24;
                if (deficit > 0)
                {
                    TBbinmaszk4.Text = Feltoltes(32 - prefixNumber, false, '0');
                }
                else
                    TBbinmaszk4.Text = binarisNullak;

            }
            else  if (prefixNumber >= 16)
            {
                TBbinmaszk2.Text = binarisEgyesek;
                deficit = prefixNumber - 16;
                if (deficit > 0)
                {
                    TBbinmaszk3.Text = Feltoltes(24 - prefixNumber, false, '0');
                }
                else
                    TBbinmaszk3.Text = binarisNullak;
            }
            else if (prefixNumber >= 8)
            {
                //TBbinmaszk2.Text = binarisEgyesek;
                deficit = prefixNumber - 8;
                if (deficit > 0)
                {
                    TBbinmaszk2.Text = Feltoltes(16 - prefixNumber, false, '0'); ;
                }
                else
                    TBbinmaszk2.Text = binarisNullak;
            }       
        }

        private void kilepButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

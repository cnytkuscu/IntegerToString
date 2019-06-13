using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            int number = Convert.ToInt32(textBox1.Text);
            intToString fnk = new intToString(this);
            fnk.detectLength(number);
            fnk.fillTextbox();
        }
    }
    class intToString
    {
        private Form1 frm;
        private int sayi, length = 0, basamakk = 10, bolen = 1;
        private string keke = "";
        private string[] birler = { " ", " bir", " iki", " üç", " dört", " beş", " altı", " yedi", " sekiz", " dokuz" };
        private string[] onlar = { " ", " on", " yirmi", " otuz", " kırk", " elli", " altmış", " yetmiş", " seksen", " doksan" };
        private string[] katlar = { " yüz", " bin", " milyon" };
        private string[] reverseText = new string[8];
        public intToString(Form1 frm_)
        {
            frm = frm_;
        }
        public void detectLength(int number)
        {
            sayi = number;
            for (int i = 1; ; i = i = i * 10)
            {
                if (number == 0)
                    length = 1;
                if (number / i > 0)
                    length++;
                else break;
            }
            detectNumber();
        }
        private void detectNumber()
        {
            for (int i = 1; i <= length; i++)
            {
                selectString((sayi % basamakk) / bolen, i);
                basamakk = basamakk * 10;
                bolen = bolen * 10;
            }
        }
        private void selectString(int value, int basamak)
        {
            switch (basamak)
            {
                case 1:
                    {
                        keke = birler[value];
                        typeString(keke, basamak);
                        break;
                    }
                case 2:
                    {
                        keke = onlar[value];
                        typeString(keke, basamak);
                        break;
                    }
                case 3:
                    {
                        keke = birler[value] + katlar[0];
                        if (value == 1)
                            keke = katlar[0];
                        if (value == 0)
                            keke = " ";
                        typeString(keke, basamak);
                        break;
                    }
                case 4:
                    {
                        keke = birler[value] + katlar[1];
                        if (value == 1)
                            keke = katlar[1];
                        if (value == 0)
                            keke = katlar[1];
                        typeString(keke, basamak);
                        break;
                    }
                case 5:
                    {
                        keke = onlar[value];
                        typeString(keke, basamak);
                        break;
                    }
                case 6:
                    {
                        keke = birler[value] + katlar[0];
                        if (value == 1)
                            keke = katlar[0];
                        if (value == 0)
                            keke = " ";
                        typeString(keke, basamak);
                        break;
                    }
                case 7:
                    {
                        keke = birler[value] + katlar[2];
                        if (value == 0)
                            keke = " ";
                        typeString(keke, basamak);
                        break;
                    }
            }
        }
        public void fillTextbox()
        {
            for (int i = length; i > 0; i--)
            {
                frm.textBox2.Text = frm.textBox2.Text + reverseText[i].ToString().ToUpper();
            }
        }
        public void typeString(string text, int basamak)
        {
            reverseText[basamak] = text + " ".ToString();
        }
    }
}

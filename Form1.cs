using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DH_Algorithm
{
    public partial class Form1 : Form
    {
        private int SharedKey;
        public Form1()
        {
            InitializeComponent();
        }
        // EncryptedKey = ModExp(AgreedBase, PrivateKey, AgreedMod);
        private void button3_Click(object sender, EventArgs e)
        {
            int baseValue, exponent, mod;

            if (!int.TryParse(textBox3.Text, out baseValue) ||
                !int.TryParse(textBox1.Text, out exponent) ||
                !int.TryParse(textBox2.Text, out mod))
            {
                // Handle the case where parsing fails, maybe display an error message
                // or set default values.
                return;
            }

            textBox5.Text = ModExp(baseValue, exponent, mod).ToString();
            Console.WriteLine(ModExp(baseValue, exponent, mod).ToString());
        }
        private static int ModExp(int baseValue, int exponent, int mod)
        {
            int result = 1;
            baseValue = baseValue % mod;

            while (exponent > 0)
            {
                if ((exponent % 2) == 1)
                {
                    result = (result * baseValue) % mod;
                }
                exponent = exponent >> 1;
                baseValue = (baseValue * baseValue) % mod;
            }

            return result;
        }
        // SharedKey = ModExp(EncryptedKey2, PrivateKey, AgreedMod);
        private void button4_Click(object sender, EventArgs e)
        {
            int baseValue, exponent, mod;

            if (!int.TryParse(textBox4.Text, out baseValue) ||
                !int.TryParse(textBox1.Text, out exponent) ||
                !int.TryParse(textBox2.Text, out mod))
            {
                // Handle the case where parsing fails, maybe display an error message
                // or set default values.
                return;
            }
            SharedKey = ModExp(baseValue, exponent, mod);
            Console.WriteLine(SharedKey);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { richTextBox1.Text = Cryptography.Encrypt(richTextBox1.Text, SharedKey.ToString()); } catch { }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { richTextBox1.Text = Cryptography.Decrypt(richTextBox1.Text, SharedKey.ToString()); } catch { }
        }
    }
}

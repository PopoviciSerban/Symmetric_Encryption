using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace Criptare_Simetrica
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
                TextBox1.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = EncryptAesManaged(TextBox1.Text);
        }

        static string EncryptAesManaged(string raw)
        {
            byte[] encrypted;

            using (AesManaged aes = new AesManaged())
                encrypted = EncryptAes(raw, aes.Key, aes.IV);

            return Encoding.UTF8.GetString(encrypted);
        }

        static byte[] EncryptAes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
   
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
 
                using (MemoryStream ms = new MemoryStream())
                { 
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {  
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);

                        encrypted = ms.ToArray();
                    }
                }
            }
            
            return encrypted;
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = EncryptDesManaged(TextBox1.Text);
        }

        static string EncryptDesManaged(string raw)
        {
            byte[] encrypted;

            using (DES des = DES.Create())
                encrypted = EncryptDes(raw, des.Key, des.IV);

            return Encoding.UTF8.GetString(encrypted);
        }

        static byte[] EncryptDes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (DES des = DES.Create())
            {
                ICryptoTransform encryptor = des.CreateEncryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);

                        encrypted = ms.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = EncryptTripleDesManaged(TextBox1.Text);
        }

        static string EncryptTripleDesManaged(string raw)
        {
            byte[] encrypted;

            using (TripleDES tdes = TripleDES.Create())
                encrypted = EncryptTripleDes(raw, tdes.Key, tdes.IV);

            return Encoding.UTF8.GetString(encrypted);
        }

        static byte[] EncryptTripleDes(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (TripleDES tdes = TripleDES.Create())
            {
                ICryptoTransform encryptor = tdes.CreateEncryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);

                        encrypted = ms.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private void ListBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = EncryptRijndaelManaged(TextBox1.Text);
        }

        static string EncryptRijndaelManaged(string raw)
        {
            byte[] encrypted;

            using (Rijndael myRijndael = Rijndael.Create())
                encrypted = EncryptRijndael(raw, myRijndael.Key, myRijndael.IV);

            return Encoding.UTF8.GetString(encrypted);
        }

        static byte[] EncryptRijndael(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (Rijndael myRijndael = Rijndael.Create())
            {
                ICryptoTransform encryptor = myRijndael.CreateEncryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);

                        encrypted = ms.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            TextBox2.Text = EncryptRC2Managed(TextBox1.Text);
        }

        static string EncryptRC2Managed(string raw)
        {
            byte[] encrypted;

            using (RC2 rc2 = RC2.Create())
                encrypted = EncryptRC2(raw, rc2.Key, rc2.IV);

            return Encoding.UTF8.GetString(encrypted);
        }

        static byte[] EncryptRC2(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (RC2 rc2 = RC2.Create())
            {
                ICryptoTransform encryptor = rc2.CreateEncryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);

                        encrypted = ms.ToArray();
                    }
                }
            }

            return encrypted;
        }
    }
}

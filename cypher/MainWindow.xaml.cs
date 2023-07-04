using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

namespace cypher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        UnicodeEncoding converter = new UnicodeEncoding();
        byte[] data;
        RSAParameters privateKey;
        RSAParameters publicKey;
        public MainWindow()
        {
            
            InitializeComponent();
            privateKey = rsa.ExportParameters(true);
            publicKey = rsa.ExportParameters(false);
        }
        private void encrypt_Click(object sender, RoutedEventArgs e)
        {
            data = RSAencrypt(converter.GetBytes(input_1.Text), publicKey, false);
            output_1.Text = Encoding.Unicode.GetString(data);
        }
        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            data = RSAdecrypt(data, privateKey, false);
            output_2.Text = Encoding.Unicode.GetString(data);
        }
        private byte[] RSAencrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKeyInfo);
                return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
            }
            
        }
        private byte[] RSAdecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKeyInfo);
                return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
            }
        }
        private void copy_Click(object sender, RoutedEventArgs e)
        {
            input_2.Text = output_1.Text;
        }
    }
}

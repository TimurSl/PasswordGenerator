using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace MatrixRainWpfApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int passwordLength = 8;
		private bool useSymbols = true;
		private bool useNumbers = true;
		private bool useUppercase = true;
        private bool useLowercase = true;

        private string password = "";

        public MainWindow()
		{
			InitializeComponent();

			MRain.Start();

			LengthTextBox.Text = passwordLength.ToString();
			SymbolsCheckbox.IsChecked = useSymbols;
			NumbersCheckbox.IsChecked = useNumbers;
			BigLettersCheckbox.IsChecked = useUppercase;
			SmallLettersCheckbox.IsChecked = useLowercase;

		}

		private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            password = GeneratePassword(useSymbols, useNumbers, useUppercase, useLowercase, passwordLength);
            PasswordTextbox.Text = password;
        }
        #region NumbersCheckbox

        private void NumbersCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            useNumbers = true;
        }

        private void NumbersCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            useNumbers = false;
        }

        #endregion

        #region SymbolsCheckbox

        private void SymbolsCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            useSymbols = true;
        }

        private void SymbolsCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            useSymbols = false;
        }

        #endregion

        #region SmallLettersCheckbox

        private void SmallLettersCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            useLowercase = false;
        }

        private void SmallLettersCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            useUppercase = true;
        }

        #endregion

        #region BigLettersCheckbox

        private void BigLettersCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            useUppercase = true;
        }

        private void BigLettersCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            useUppercase = false;
        }

        #endregion

        private void MinusLengthButton_Click(object sender, RoutedEventArgs e)
        {
            passwordLength--;
            passwordLength = passwordLength < 4 ? 4 : passwordLength;
            LengthTextBox.Text = passwordLength.ToString();
        }

        private void PlusLengthButton_Click(object sender, RoutedEventArgs e)
        {
            passwordLength++;
            passwordLength = passwordLength > 100 ? 100 : passwordLength;
            LengthTextBox.Text = passwordLength.ToString();
        }

        private void CopyPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // copy password to clipboard
            password.CopyToClipboard();
        }

        private string GeneratePassword(bool useSymbols, bool useNumbers, bool useUppercase, bool useLowercase,
            int passwordLength)
        {
            var symbols = "!@#$%^&*()_+";
            var numbers = "1234567890";
            var uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowercase = "abcdefghijklmnopqrstuvwxyz";

            var password = "";

            var random = new Random ();

            for (int i = 0; i < passwordLength; i++)
            {
                var randomChar = "";
                if (useSymbols)
                {
                    randomChar += symbols;
                }

                if (useNumbers)
                {
                    randomChar += numbers;
                }

                if (useUppercase)
                {
                    randomChar += uppercase;
                }

                if (useLowercase)
                {
                    randomChar += lowercase;
                }

                if (!useSymbols && !useNumbers && !useUppercase && !useLowercase)
                {
                    // make all symbols + numbers + uppercase + lowercase in password
                    randomChar += symbols;
                    randomChar += numbers;
                    randomChar += uppercase;
                    randomChar += lowercase;
                }

                password += randomChar[random.Next(0, randomChar.Length)];
            }

            // shuffle password and cut it to password lentgh, if it's too long, add += password
            password = new string(password.ToCharArray ().OrderBy(s => (random.Next(2) % 2) == 0).ToArray ());
            if (password.Length > passwordLength)
            {
                password = password.Substring(0, passwordLength);
            }
            else if (password.Length < passwordLength)
            {
                password += password;
                password = password.Substring(0, passwordLength);
            }

            return password;
        }
    }   
}

static class ClipboardExtensions
{
    public static void CopyToClipboard(this string text)
    {
        Clipboard.SetText(text);
    }
}

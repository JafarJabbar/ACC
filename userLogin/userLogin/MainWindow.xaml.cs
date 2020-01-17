using System;
using System.Collections.Generic;
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

namespace userLogin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1Container model = new Model1Container();
        public MainWindow()
        {
            InitializeComponent();
        }


        #region Sign In
        /// <summary>
        /// Istfadeci adi ve parolun database den gelen melumatlarla yoxlanmasi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            var user = model.users.FirstOrDefault(p=>p.istfAd==Username.Text);
            if (Username.Text == " " || Password.Password == "")
            {
                notification.Visibility = Visibility.Visible;
                notification.Text = "Saheler bosh buraxila bilmez... ";
            }
            else if (user==null)
            {
                notification.Visibility = Visibility.Visible;
                notification.Text = "Bele istfadechi yoxdur...";
            }
            
            else if (user.shifre == Password.Password)
            {
                girish.Visibility = Visibility.Visible;
                SignInPanel.Visibility = Visibility.Collapsed;
                esasSehife.Width = 600;
                esasSehife.Height = 600;
            }
            
            else
            {
                notification.Visibility = Visibility.Visible;
                notification.Text = "Yalnish istfadechi adi ve ya parol...";
            }


        }
        #endregion

        #region qeydiyyatKec
        /// <summary>
        /// qeydiyyat paneline kecid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            esasSehife.Height = 650;
            SignUpPanel.Visibility = Visibility.Visible;
            SignInPanel.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region qeydiyyat
        /// <summary>
        /// Qeydiyyatdan kecen yeni istfadecinin db e elave olunmasi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qeydiyyat_Click(object sender, RoutedEventArgs e)
        {
            if (ad.Text!="" && soyad.Text!="" && newIstfad.Text!="" && Shifre.Password!="" )
            {
                if (eMail.Text.Contains('@') && eMail.Text.Contains('.'))
                {
                    model.users.Add(new user()
                    {
                        ad = ad.Text,
                        soyad = soyad.Text,
                        istfAd = newIstfad.Text,
                        shifre = Shifre.Password,
                        eMail = eMail.Text,
                        telNom = telNom.Text
                    });
                    model.SaveChanges();
                    SignUpPanel.Visibility = Visibility.Collapsed;
                    SignInPanel.Visibility = Visibility.Visible;
                }
                else
                {
                    notificationSecond.Visibility = Visibility.Visible;
                    notificationSecond.Text = "Elektron poçt düzgün daxil olunmayıb...";
                }
            }
            else
            {
                notificationSecond.Visibility = Visibility.Visible;
                notificationSecond.Text = "Sahələr boş buraxıla bilməz...";
            }
        }
        #endregion

    }
}

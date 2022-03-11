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
using System.Windows.Threading;
using System.Data.Entity;

namespace PishiStirai.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private byte _failedCounter = 0; //счётчик попыток неправильной авторизации
        private DispatcherTimer _timer = new DispatcherTimer(); //таймер для блокирования кнопки
        private string _answer; //переменная для сохранения ответа на каптчу

        public LoginPage()
        {
            InitializeComponent();
            imgCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4); //создание каптчи с 4 символами
            _answer = imgCaptcha.CaptchaText;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            tbxLogin.Text = "";
            pbxPassword.Password = "";
            tbxCaptchaAnswer.Text = "";
        }

        private async void BtnEnter_Click(object sender, RoutedEventArgs args)
        {
            try
            {
                var currentUser = await App.db.User.FirstOrDefaultAsync(e => e.UserLogin == tbxLogin.Text &&
                e.UserPassword == pbxPassword.Password); //запрос к бд
                if (currentUser != null && _answer.ToLower() == tbxCaptchaAnswer.Text.ToLower() == true) // если всё верно
                {
                    App.CurrentUser = currentUser;
                    NavigationService.Navigate(new ProductPage());
                }
                if (_failedCounter == 2) //если не получилось зайти с двух раз
                {
                    imgCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
                    _answer = imgCaptcha.CaptchaText;
                    _failedCounter = 0;
                    btnEnter.IsEnabled = false;
                    _timer.Interval = TimeSpan.FromSeconds(10);
                    _timer.Tick += TimerTick;
                    _timer.Start();
                }
                else if (currentUser == null)
                {
                    MessageBox.Show("Логин или пароль введены неправильно!", "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    imgCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
                    _answer = imgCaptcha.CaptchaText;
                    _failedCounter++;
                }
                else if (_answer.ToLower() != tbxCaptchaAnswer.Text.ToLower()) //если каптча введена неправильно
                {
                    MessageBox.Show("Проверь ввод каптчи!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    UpdateCaptcha();
                    _failedCounter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при авторизации");
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            _timer.Stop();
            btnEnter.IsEnabled = true;
            tbxLogin.Text = "";
            pbxPassword.Password = "";
            tbxCaptchaAnswer.Text = "";
        }
        private void UpdateCaptcha() //метод обновления каптчи
        {
            imgCaptcha.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 4);
            _answer = imgCaptcha.CaptchaText;
        }
    }
}

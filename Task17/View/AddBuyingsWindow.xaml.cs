using System.Data;
using System.Windows;

using Task17.Model;

namespace Task17.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrdersWindow.xaml
    /// </summary>
    public partial class AddBuyingsWindow : Window
    {
        /// <summary>
        /// Констрктор
        /// </summary>
        private AddBuyingsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="newBuying">Новый покупатель</param>
        public AddBuyingsWindow(Buyings newBuying) : this()
        {
            CancelButton.Click += delegate { DialogResult = false; };
            AddButton.Click += delegate
            {
                // Проверка на наличие инъекции
                if (DataBaseInformationSecurity.IsSQLInjection(FirstNameTextBox.Text) ||
                    DataBaseInformationSecurity.IsSQLInjection(MiddleNameTextBox.Text) ||
                    DataBaseInformationSecurity.IsSQLInjection(LastNameTextBox.Text) ||
                    DataBaseInformationSecurity.IsSQLInjection(PhoneNumberTextBox.Text) ||
                    DataBaseInformationSecurity.IsSQLInjection(EmailTextBox.Text))
                {
                    DialogResult = false;
                    MessageBox.Show("Обнаружена SQL-инъекция");
                    return;
                }

                // Если все хорошо, то инициализирую запись
                newBuying.FirstName = FirstNameTextBox.Text;
                newBuying.MiddleName = MiddleNameTextBox.Text;
                newBuying.LastName = LastNameTextBox.Text;
                newBuying.PhoneNumber = PhoneNumberTextBox.Text;
                newBuying.Email = EmailTextBox.Text;

                DialogResult = true;
            };
        }
    }
}

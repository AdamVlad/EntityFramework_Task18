using System;
using System.Data;
using System.Windows;

using Task17.Model;

namespace Task17.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrdersWindow.xaml
    /// </summary>
    public partial class AddOrdersWindow : Window
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        private AddOrdersWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="newOrder"></param>
        /// <param name="isEmailExistsDelegate">Функция, определяющая наличие переданного Email</param>
        public AddOrdersWindow(
            Orders newOrder,
            Predicate<string> isEmailExistsDelegate) : this()
        {
            CancelButton.Click += delegate { DialogResult = false; };
            AddButton.Click += delegate
            {
                // Проверка на наличие инъекции
                if (DataBaseInformationSecurity.IsSQLInjection(EmailTextBox.Text) ||
                    DataBaseInformationSecurity.IsSQLInjection(ProductCodeTextBox.Text) ||
                    DataBaseInformationSecurity.IsSQLInjection(ProductNameTextBox.Text))
                {
                    DialogResult = false;
                    MessageBox.Show("Обнаружена SQL-инъекция");
                    return;
                }

                // Проверяю, существует ли введенный Email в таблице покупателей
                if (!isEmailExistsDelegate(EmailTextBox.Text))
                {
                    DialogResult = false;
                    MessageBox.Show("Покупателя с введнными Email не существует");
                    return;
                }

                // Если все хорошо, то инициализирую запись
                newOrder.Email = EmailTextBox.Text;
                newOrder.ProductCode = Int32.Parse(ProductCodeTextBox.Text);
                newOrder.ProductName = ProductNameTextBox.Text;
                DialogResult = true;
            };
        }
    }
}

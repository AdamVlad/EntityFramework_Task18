using System.Windows;
using System.Data.Entity;

using Task17.Model;
using Task17.ViewModel;

namespace Task17.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _mainVM = new MainVM();
            BuyingsDataGrid.ItemsSource = _mainVM.ContextDataBase.Buyings.Local.ToBindingList<Buyings>();
            OrdersDataGrid.ItemsSource = _mainVM.ContextDataBase.Orders.Local.ToBindingList<Orders>();
        }

        /// <summary>
        /// Обработчик клика по кнопке добавления записи в таблицу Buyings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyingsMenuItemAddClick(object sender, RoutedEventArgs e)
        {
            _mainVM.AddBuying();
        }

        /// <summary>
        /// Обработчик клика по кнопке удаления записи в таблице Buyings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyingsMenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            _mainVM.DeleteBuying(BuyingsDataGrid.SelectedItem as Buyings);
        }

        /// <summary>
        /// Обработчик клика по кнопке удаления записи в таблице Orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdersMenuItemAddClick(object sender, RoutedEventArgs e)
        { 
            _mainVM.AddOrder();
        }

        /// <summary>
        /// Обработчик клика по кнопке удаления записи в таблице Orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdersMenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            _mainVM.DeleteOrder(OrdersDataGrid.SelectedItem as Orders);
        }

        /// <summary>
        /// Обработчик кнопки сохранения изменений в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainVM.ContextDataBase.SaveChangesAsync();
        }

        private MainVM _mainVM;
    }
}

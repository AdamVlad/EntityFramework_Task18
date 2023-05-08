using System.Data.Entity;
using System.Linq;

using Task17.Model;
using Task17.View;

namespace Task17.ViewModel
{
    /// <summary>
    /// Класс, соединяющий модель и представление
    /// </summary>
    public class MainVM
    {
        public MSSQLDBEntities ContextDataBase { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainVM()
        {
            ContextDataBase = new MSSQLDBEntities();

            ContextDataBase.Buyings.Load();
            ContextDataBase.Orders.Load();
        }

        /// <summary>
        /// Определяет, существует ли переданый Email в таблице покупателей
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>
        /// true - существует
        /// false - не существует
        /// </returns>
        public bool IsEmailExistsInBuyingsDB(string email)
        {
            var count = ContextDataBase.Buyings.Count(c => c.Email == email);
            return count > 0;
        }

        /// <summary>
        /// Добавление нового покупателя
        /// </summary>
        public void AddBuying()
        {
            // Создаю новую запись и вызываю окно добавление записи
            Buyings newBuying = new Buyings();
            AddBuyingsWindow addBuyingsWindow = new AddBuyingsWindow(newBuying);
            addBuyingsWindow.ShowDialog();

            // Если в результате добавления записи все успешно, то создаю ее и обновляю таблицу
            if (addBuyingsWindow.DialogResult.Value)
            {
                ContextDataBase.Buyings.Add(newBuying);
            }
        }

        /// <summary>
        /// Добавление нового заказа
        /// </summary>
        public void AddOrder()
        {
            // Создаю новую запись и вызываю окно добавление записи
            Orders newOrder = new Orders();
            AddOrdersWindow addOrdersWindow = new AddOrdersWindow(
                newOrder,
                IsEmailExistsInBuyingsDB);

            addOrdersWindow.ShowDialog();

            // Если в результате добавления записи все успешно, то создаю ее и обновляю таблицу
            if (addOrdersWindow.DialogResult.Value)
            {
                ContextDataBase.Orders.Add(newOrder);
            }
        }

        /// <summary>
        /// Удаление покупателя
        /// </summary>
        /// <param name="buying"></param>
        public void DeleteBuying(Buyings buying)
        {
            ContextDataBase.Buyings.Remove(buying);
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOrder(Orders order)
        {
            ContextDataBase.Orders.Remove(order);
        }
    }
}

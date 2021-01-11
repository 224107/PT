using Presentation.Base;
using Presentation.View;



namespace Presentation.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public RelayCommand ToCustomerCommand { get; set; }
        public RelayCommand ToProductCommand { get; set; }
        public RelayCommand ToEventCommand { get; set; }
        public MainViewModel()
        {
            ToCustomerCommand = new RelayCommand(ToCustomer);
            ToProductCommand = new RelayCommand(ToProduct);
            ToEventCommand = new RelayCommand(ToEvent);
        }

        void ToCustomer(object parameter)
        {
            var win = new CustomerView();
            win.Show();
        }

        void ToProduct(object parameter)
        {
            var win = new ProductView();
            win.Show();
        }
        void ToEvent(object parameter)
        {
            var win = new EventView();
            win.Show();
        }


    }
}

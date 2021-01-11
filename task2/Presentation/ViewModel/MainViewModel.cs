using Presentation.Base;
using Presentation.View;



namespace Presentation.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel selectedViewModel;
        public RelayCommand ToCustomerCommand { get; set; }
        public RelayCommand ToProductCommand { get; set; }
        public RelayCommand ToEventCommand { get; set; }
        public MainViewModel()
        {
            ToCustomerCommand = new RelayCommand(ToCustomer);
            ToProductCommand = new RelayCommand(ToProduct);
            ToEventCommand = new RelayCommand(ToEvent);
        }

        public void ToCustomer(object parameter)
        {

            if (parameter == null)
            {
                selectedViewModel = new CustomerViewModel();
            }
            else
            {
                var win = new CustomerView();
                win.Show();
            }
        }

        public void ToProduct(object parameter)
        {
            if (parameter == null){
                selectedViewModel = new ProductViewModel();
            }
            else
            {
                var win = new ProductView();
                win.Show();
            }           
        }
        public void ToEvent(object parameter)
        {
            if (parameter == null)
            {
                selectedViewModel = new EventViewModel();
            }
            else
            {
                var win = new EventView();
                win.Show();
            }           
        }
    }
}

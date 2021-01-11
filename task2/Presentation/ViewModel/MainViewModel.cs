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

            if(parameter == null)
            {
                var win = new CustomerView();
                win.Show();
            }
            else if(parameter.ToString() == "Customer")
            {
                selectedViewModel = new CustomerViewModel();
            }
        }

        public void ToProduct(object parameter)
        { 
            if (parameter == null)
            {
                var win = new ProductView();
                win.Show();
            }
            else if(parameter.ToString() == "Product")
            {
                selectedViewModel = new ProductViewModel();
            }           
        }
        public void ToEvent(object parameter)
        {
            if (parameter == null)
            {
                var win = new EventView();
                win.Show();
            }
            else if(parameter.ToString() == "Event")
            {
                selectedViewModel = new EventViewModel();
            }           
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;

namespace PresentationTest
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void InitiallySetToClientListView()
        {
            MainViewModel mainViewModel = new MainViewModel();
            Assert.IsNull(mainViewModel.selectedViewModel);

        }

        [TestMethod]
        public void SwitchViewToCustomerView()
        {
            MainViewModel mainViewModel = new MainViewModel();

            mainViewModel.ToCustomer(null);
            Assert.IsInstanceOfType(mainViewModel.selectedViewModel, typeof(CustomerViewModel));
            
        }

        [TestMethod]
        public void SwitchViewToProductView()
        {
            MainViewModel mainViewModel = new MainViewModel();

            mainViewModel.ToProduct(null);
            Assert.IsInstanceOfType(mainViewModel.selectedViewModel, typeof(ProductViewModel));
        }

        [TestMethod]
        public void SwitchViewToEventView()
        {
            MainViewModel mainViewModel = new MainViewModel();

            mainViewModel.ToEvent(null);
            Assert.IsInstanceOfType(mainViewModel.selectedViewModel, typeof(EventViewModel));
        }
    }
}

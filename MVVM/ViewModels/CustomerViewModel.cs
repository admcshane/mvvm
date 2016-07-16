using System;
using MVVM.Commands;
using MVVM.Models;
using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    internal class CustomerViewModel
    {
        private Customer customer;
        private CustomerInfoViewModel childViewModel;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        public CustomerViewModel()
        {
            customer = new Customer("Austin");
            childViewModel = new CustomerInfoViewModel() { Info = "Instantiated in CustomerViewModel() constructor." };
            UpdateCommand = new UpdateCustomerCommand(this);
        }

        /// <summary>
        /// Gets the customer instance
        /// </summary>
        public Customer Customer
        {
            get
            {
                return customer;
            }
        }

        /// <summary>
        /// Gets the UpdateCommand for the ViewModel.
        /// </summary>
        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Saves changes made to the Customer instance.
        /// </summary>
        public void SaveChanges()
        {
            CustomerInfoView view = new CustomerInfoView();
            view.DataContext = childViewModel;

            childViewModel.Info = Customer.Name + " was updated in the database.";

            view.ShowDialog();
        }
    }
}
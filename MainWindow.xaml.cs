using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
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
using PublicEventsManager.Entities;
using PublicEventsManager.Repositories;
using PublicEventsManager.Models;

namespace PublicEventsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["PublicEventsManagerConnectionString"].ConnectionString;
        List<PublicEventViewModel> publicEventsViewModels = new List<PublicEventViewModel>();
        List<PublicEvent> publicEvents = new PublicEventRepository(_connectionString).GetAllPublicEvents().ToList();

        public MainWindow()
        {
            InitializeComponent();

            Window loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (!(loginWindow.DialogResult.HasValue && loginWindow.DialogResult.Value))
            {

                this.Close();
                return;
            }

            #region Public Events Visualization
            publicEvents = publicEvents.GroupBy(item => item.Name).Select(group => group.First()).ToList();

            foreach (PublicEvent item in publicEvents)
            {
                publicEventsViewModels.Add(new PublicEventViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    Location = item.Location,
                    Price = item.AvaragePrice.ToString()
                });
            }

            mainGrid.ItemsSource = publicEventsViewModels;
   
            #endregion
        }

        private void filterPublicEventsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<PublicEventViewModel> filteredByPriceItems = new List<PublicEventViewModel>();
                foreach (PublicEventViewModel item in publicEventsViewModels)
                {
                    if (double.Parse(item.Price) > double.Parse(lowerPriceTextBox.Text) &&
                        double.Parse(item.Price) < double.Parse(upperPriceTextBox.Text))
                    {
                        filteredByPriceItems.Add(item);
                    }
                }
                mainGrid.ItemsSource = filteredByPriceItems;

            }
            catch(FormatException formatException)
            {
                MessageBox.Show("Sorry invalid data",formatException.ToString());
            }
        }

        private void refreshPriceFitlerButton_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.ItemsSource = publicEventsViewModels;
        }

        private void filterByDateButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void filterByTypeNameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void getTypesListButton_Click(object sender, RoutedEventArgs e)
        {
            List<EventType> typesList = new EventTypeRepository(_connectionString).GetAllEventTypes().ToList();

            foreach (EventType item in typesList)
            {
                typesListBox.Items.Add(item.Name);
            }
          
        }

        private void newPublicEventConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PublicEvent newPublicEvent = new PublicEvent();

                newPublicEvent.Name = newPublicEventNameTextBox.Text;
                newPublicEvent.Location = newPublicEventLocationTextBox.Text;
                newPublicEvent.Description = newPublicEventDescriptionTextBox.Text;
                newPublicEvent.TicketsAmount = int.Parse(newPublicEventTicketsAmountTextBox.Text);

                publicEventsViewModels.Add(new PublicEventViewModel
                {
                    Name = newPublicEvent.Name,
                    Description = newPublicEvent.Description,
                    Location = newPublicEvent.Location,
                    Price = newPublicEvent.AvaragePrice.ToString()
                });

               new PublicEventRepository(_connectionString).AddNewPublicEvent(newPublicEvent);
            }
            catch(FormatException formatException)
            {
                MessageBox.Show("Sorry, invalid data", formatException.ToString());
            }
        }

        private void getTicketsByOwnerNameConfirmButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CA2_Harry_Flanagan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create list
        List<Activity> allActivities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

            //Create Activity Objects
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(),
                TypeOfActivity = TypeOfActivity.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = TypeOfActivity.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = TypeOfActivity.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = TypeOfActivity.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = TypeOfActivity.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = TypeOfActivity.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = TypeOfActivity.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = TypeOfActivity.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = TypeOfActivity.Air,
                Cost = 200m
            };

            //add to list
            allActivities.Add(l1);
            allActivities.Add(l2);
            allActivities.Add(l3);
            allActivities.Add(w1);
            allActivities.Add(w2);
            allActivities.Add(w3);
            allActivities.Add(a1);
            allActivities.Add(a2);
            allActivities.Add(a3);

            //Sort all activities based on the date
            allActivities.Sort();

            //display within the listbox
            lbxActivites.ItemsSource = allActivities;

        }

        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {
            //What item is selected
            Activity selectedActivitity = lbxActivites.SelectedItem as Activity;

            //null check
            if (selectedActivitity != null)
            {

                //move item from left listbox to right
                allActivities.Remove(selectedActivitity);
                selectedActivities.Add(selectedActivitity);

                RefreshScreen();
            }

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
            // Get the currently selected item in the ListBox.
            Activity selectedActivity = lbxActivites.SelectedItem as Activity;

            //if nothing is selected
            if (selectedActivity != null)
            {
                txtDesctiption.Text = selectedActivity.Description;
            }

        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //What item is selected
            Activity selectedActivitity = lbxSelected.SelectedItem as Activity;

            //null check
            if (selectedActivitity != null)
            {

                //move item from right listbox to left
                allActivities.Add(selectedActivitity);
                selectedActivities.Remove(selectedActivitity);

                RefreshScreen();
            }

        }

        private void RefreshScreen()
        {
            //refresh
            lbxActivites.ItemsSource = null;
            lbxActivites.ItemsSource = allActivities;

            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = selectedActivities;
        }

        //Works for all radio buttons
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();

            if(rbAll.IsChecked == true)
            {
                //show all activities
                RefreshScreen();
            }
            else if (rbLand.IsChecked == true)
            {
                //show all Land activities
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == TypeOfActivity.Land)
                    {
                        //MessageBox.Show("Land Selected");
                        filteredActivities.Add(activity);

                        lbxActivites.ItemsSource = null;
                        lbxActivites.ItemsSource = filteredActivities;

                    }
                }
            }
            else if (rbWater.IsChecked == true)
            {
                //show all Water activities
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == TypeOfActivity.Water)
                    {
                        filteredActivities.Add(activity);
                        lbxActivites.ItemsSource = null;
                        lbxActivites.ItemsSource = filteredActivities;

                    }
                }
            }
            else if (rbAir.IsChecked == true)
            {
                //show all Air activities
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == TypeOfActivity.Air)
                    {
                        filteredActivities.Add(activity);
                        lbxActivites.ItemsSource = null;
                        lbxActivites.ItemsSource = filteredActivities;
                    }
                }
            }
            

        }

   
    }
}

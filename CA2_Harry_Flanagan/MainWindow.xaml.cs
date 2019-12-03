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
/*Author Harry Flanagan*/
namespace CA2_Harry_Flanagan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Lists
        List<Activity> allActivities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();

        //Varibles
        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        //Run when window is loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Create all Activity Objects
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
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

            //Add to allActivities list
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

            //display within the listbox on the right
            lbxActivites.ItemsSource = allActivities;

        }

        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {

            //What item is selected
            Activity selectedActivitity = lbxActivites.SelectedItem as Activity;

            //null check
            if (selectedActivitity != null)
            {
                bool validDate = true; //Used to check if selected activity date != any activity already selected
                for (int i = 0; i < selectedActivities.Count; i++) //Counts and checks each of the selcted activties
                {
                    if (selectedActivitity.ActivityDate == selectedActivities[i].ActivityDate) //If the selected Activty's Date == to any of the dates in the already selected activies
                    {
                        //Display message and change validDate to false
                        MessageBox.Show("Cannot add activties with the same date", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
                        validDate = false;
                    }


                }
                if (validDate == true) //Will only add activity to the right list box if the validDate == true
                {
                    //move item from left listbox to right
                    allActivities.Remove(selectedActivitity);
                    selectedActivities.Add(selectedActivitity);

                    //Sets and displays total cost within the Total Cost textbox
                    totalCost = totalCost + selectedActivitity.Cost;
                    txtTotalCost.Text = totalCost.ToString("C");
                }

                RefreshScreen();

            }
            else if (selectedActivitity == null)
            {
                //Display Message if no activity is selected
                MessageBox.Show("No activity selected", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else // if the program gets through both of the null checks
            {
                MessageBox.Show("Unkown Error", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Get the currently selected item in the ListBox.
            Activity selectedActivity = lbxActivites.SelectedItem as Activity;

            //If nothing is selected
            if (selectedActivity != null)
            {
                //Display activity in text box
                txtDesctiption.Text = selectedActivity.Description;

                //Converts to string in currency formate and displays cost in text box
                txtCost.Text = selectedActivity.Cost.ToString("C");


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

                //Sets and displays total cost within the Total Cost textbox
                totalCost = totalCost - selectedActivitity.Cost;
                txtTotalCost.Text = totalCost.ToString("C");

                RefreshScreen();
            }
            else if (selectedActivitity == null)
            {
                //Display message box if no activity is selected
                MessageBox.Show("No activity selected", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else // if the program gets through both of the null checks
            {
                MessageBox.Show("Unkown Error", "Activity Planner", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void RefreshScreen()
        {
            //Rereshes the screen
            lbxActivites.ItemsSource = null;
            lbxActivites.ItemsSource = allActivities;

            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = selectedActivities;
        }

        //Works for all radio buttons
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();

            if (rbAll.IsChecked == true)
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

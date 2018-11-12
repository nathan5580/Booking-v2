using MvvmExample.Helpers;
using MvvmExample.Model;
using System;
using System.Collections.ObjectModel;

namespace MvvmExample.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        public ObservableCollection<Person> People { get; set; }

        public ViewModelMain()
        {
            People = new ObservableCollection<Person>
            {
                new Person { FirstName="Nathan", LastName="WILCKE", Age=21 },
                new Person { FirstName="Adrien", LastName="Marini", Age=31 },
                new Person { FirstName="Steve", LastName="Bigleur", Age=60 },
            };
            TextProperty1 = "User";

            // Addings command to ralayCommand
            AddUserCommand = new RelayCommand(AddUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
        }

        object _SelectedPerson;
        public object SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if (_SelectedPerson != value)
                {
                    _SelectedPerson = value;
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        #region AddUserCommand        
        /// <summary>
        /// Gets or sets the add user command.
        /// </summary>
        /// <value>
        /// The add user command.
        /// </value>
        /// =====================================================================================
        /// Modification : Initial : 12/11/2018 |N.Wilcké (SESA474351)  
        /// =====================================================================================
        public RelayCommand AddUserCommand { get; set; }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// =====================================================================================
        /// Modification : Initial : 12/11/2018 |N.Wilcké (SESA474351)   
        /// =====================================================================================
        void AddUser(object parameter)
        {
            if (parameter == null) return;
            People.Add(new Person { FirstName = parameter.ToString(), LastName = parameter.ToString(), Age = DateTime.Now.Second });
        }
        #endregion

        #region DeleteUserCommand        
        /// <summary>
        /// Gets or sets the delete user command.
        /// </summary>
        /// <value>
        /// The delete user command.
        /// </value>
        /// =====================================================================================
        /// Modification : Initial : 12/11/2018 |N.Wilcké (SESA474351)  
        /// =====================================================================================
        public RelayCommand DeleteUserCommand { get; set; }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// =====================================================================================
        /// Modification : Initial : 12/11/2018 |N.Wilcké (SESA474351)
        /// =====================================================================================
        void DeleteUser(object parameter)
        {
            if (_SelectedPerson != null)
            {
                if (_SelectedPerson.GetType() == typeof(Person))
                {
                    People.Remove((Person)_SelectedPerson);
                }
            }
        }
        #endregion

    }
}

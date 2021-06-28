using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UIModeMVVM.DB;
using UIModeMVVM.Models;
using UIModeMVVM.Views;

namespace UIModeMVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private LocalDB localDB;

        private ObservableCollection<Student> gridModelList;

        private string _searchName = string.Empty;

        public string SearchName
        {
            get
            {
                return _searchName;
            }

            set
            {
                _searchName = value;

                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Student> GridModelList
        {
            get
            {
                return gridModelList;
            }

            set
            {
                gridModelList = value;

                RaisePropertyChanged();
            }
        }

        public RelayCommand<string> SearchCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand<int> EditCommand { get; set; }
        public RelayCommand<int> DeleteCommand { get; set; }

        public MainViewModel()
        {
            localDB = new LocalDB();

            SearchCommand = new RelayCommand<string>(x => {
                Query();
            });

            ResetCommand = new RelayCommand(() =>
            {
                SearchName = string.Empty;
                Query();
            });
            
            AddCommand = new RelayCommand(() =>
            {
                Add();
            });
            
            EditCommand = new RelayCommand<int>(x =>
            {
                Edit(x);
            });
            
            DeleteCommand = new RelayCommand<int>(x =>
            {
                Delete(x);
            });
        }

        public void Query()
        {
            var students = string.IsNullOrEmpty(SearchName) ?
                localDB.GetStudents() : localDB.GetStudentsByName(SearchName);

            GridModelList = new ObservableCollection<Student>();

            if (students != null)
            {
                students.ForEach(x => {
                    GridModelList.Add(x);
                });
            }
        }

        public void Edit(int id)
        {
            var student = localDB.GetStudentById(id);

            if (student != null)
            {
                var copyStu = new Student
                {
                    Id = student.Id,
                    Name = student.Name
                };

                UserView view = new UserView(copyStu);
                var diaResult = view.ShowDialog();

                if (diaResult.Value)
                {
                    var updateStu = GridModelList.FirstOrDefault(t => t.Id == student.Id);

                    if (updateStu != null)
                    {
                        updateStu.Name = student.Name = copyStu.Name;
                    }
                }
            }

        }
        
        public void Delete(int id)
        {
            var student = localDB.GetStudentById(id);

            if (student != null)
            {
                var ensureResult = MessageBox.Show($"确认删除当前用户 {student.Name} 吗？", "操作提示", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (ensureResult == MessageBoxResult.Yes)
                {
                    localDB.DeleteStudent(id);

                    Query();
                }
            }
        }

        public void Add()
        {
            var copyStu = new Student();

            UserView view = new UserView(copyStu);
            var diaResult = view.ShowDialog();

            if (diaResult.Value)
            {
                copyStu.Id = gridModelList.Max(x => x.Id) + 1;
                GridModelList.Add(copyStu);
                localDB.AddStudent(copyStu);
                Query();
            }

        }
    }
}

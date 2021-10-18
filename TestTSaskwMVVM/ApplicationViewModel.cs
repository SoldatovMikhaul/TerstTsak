using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using TestTakMVVM;

namespace TestTaskMVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Parametr selectedParametr;

        public ObservableCollection<Parametr> Parametrs { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Parametr parametr = new Parametr();
                        Parametrs.Insert(0, parametr);
                        SelectedParametr = parametr;
                    }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Parametr parametr = obj as Parametr;
                        if (parametr != null)
                        {
                            Parametrs.Remove(parametr);
                        }
                    },
                    (obj) => Parametrs.Count > 0));
            }
        }
        public Parametr SelectedParametr
        {
            get { return selectedParametr; }
            set
            {
                selectedParametr = value;
                OnPropertyChanged("SelectedParametr");
            }
        }

        public ApplicationViewModel()
        {
            Parametrs = new ObservableCollection<Parametr>
                {
                    new Parametr {Title="Parametr1", Types=Parametr.ParametrTypes.Значение_из_списка },
                    new Parametr {Title="Parametr2", Types=Parametr.ParametrTypes.Набор_значчений_из_списк},
                    new Parametr {Title="Parametr3", Types=Parametr.ParametrTypes.Простая_строка },
                    new Parametr {Title="Parametr5", Types=Parametr.ParametrTypes.Простая_строка }
                };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using TestTakMVVM;
using System.Linq;
using System;

namespace TestTaskMVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Parametr selectedParametr;
        IFileService fileService;
        IDialogService dialogService;

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

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Parametrs.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var phones = fileService.Open(dialogService.FilePath);
                              Parametrs.Clear();
                              foreach (var p in phones)
                                    Parametrs.Add(p);
                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
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

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Parametrs = new ObservableCollection<Parametr>
                {
                    new Parametr {Title="Parametr1", Types=Parametr.ParametrTypes.Значение_из_списка },
                    new Parametr {Title="Parametr2", Types=Parametr.ParametrTypes.Набор_значчений_из_списк},
                    new Parametr {Title="Parametr3", Types=Parametr.ParametrTypes.Простая_строка },
                    new Parametr {Title="Parametr4", Types=Parametr.ParametrTypes.Строка_с_историей},
                    new Parametr {Title="Parametr5", Types=Parametr.ParametrTypes.Простая_строка },
                    new Parametr {Title="Parametr6", Types=Parametr.ParametrTypes.Набор_значчений_из_списк }
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
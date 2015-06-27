using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows;

namespace Wpf
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _memo;
        public string Memo
        {
            get { return _memo; }
            set
            {
                _memo = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Memo"));
            }
        }

        public class CommandModalCore : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter)
            {
                Window w = new Window();
                w.Title = "Modal";
                w.ShowDialog();
            }
        }

        public ICommand CommandModal { get { return new CommandModalCore(); } }

        public class CommandModelessCore : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter)
            {
                Window w = new Window();
                w.Title = "Modeless";
                w.Show();
            }
        }

        public ICommand CommandModalSequential { get { return new CommandModalSequentialCore(); } }

        public class CommandModalSequentialCore : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter)
            {
                {
                    Window w = new Window();
                    w.Title = "Modal1";
                    w.ShowDialog();
                }
                {
                    Window w = new Window();
                    w.Title = "Modal2";
                    w.ShowDialog();
                }
            }
        }

        public ICommand CommandModeless { get { return new CommandModelessCore(); } }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public IEnumerable<Person> Persons { get; private set; }

        public VM()
        {
            Persons = Enumerable.Range('A', 26).Select(e => new Person() { Age = 30, Name = ((char)e).ToString() });
        }
    }
}

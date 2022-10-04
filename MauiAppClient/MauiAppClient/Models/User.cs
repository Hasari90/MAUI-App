using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppClient.Models
{
    public class User : INotifyPropertyChanged
    {
        int _id;
        public int Id { get => _id; set { if (_id == value) return; _id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id))); } }

        string _name;
        public string Name { get => _name; set { if (_name == value) return; _name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); } }

        string _surname;
        public string Surmane { get => _surname; set { if (_surname == value) return; _surname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surmane))); } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

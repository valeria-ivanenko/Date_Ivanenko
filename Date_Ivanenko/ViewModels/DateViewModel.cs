using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Desktop.Date_Ivanenko.Tools;

namespace Desktop.Date_Ivanenko.ViewModels
{
    class DateViewModel : INotifyPropertyChanged
    {
        private RelayCommand<object> _commitCommand;
        private DateTime _userBirthDate;
        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime UserBirthDate
        {
            get { return _userBirthDate; }
            set { _userBirthDate = value;
                if (GetAge() > 135 || value > DateTime.Today)
                {
                    MessageBox.Show("Incorrect Date!");
                    Age = 0;
                    WesternZodiac = "";
                    ChineseZodiac = "";
                    
                }
                else
                {
                    Age = GetAge();
                    SetZodiac();
                    SetChineseZodiac();
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value;
                OnPropertyChange("Age");
            }
        }

        private void OnPropertyChange(string v)
        {
            if (v != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set { _westernZodiac = value;
                OnPropertyChange("WesternZodiac");
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set { _chineseZodiac = value;
                OnPropertyChange("ChineseZodiac");
            }
        }

        public RelayCommand<object> CommitCommand
        {
            get
            {
                return _commitCommand ??= new RelayCommand<object>(_ => Commit(), CanExecute);
            }
        }

        private void Commit()
        {
            MessageBox.Show("Data Commited");
            if ((UserBirthDate.Month == DateTime.Today.Month) && (UserBirthDate.Day == DateTime.Today.Day))
            {
                MessageBox.Show("Happy Birthday!");
            }
        }

        private bool CanExecute(object obj)
        {
            if (String.IsNullOrEmpty(WesternZodiac) || String.IsNullOrEmpty(ChineseZodiac)) return false;
            return true;
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - UserBirthDate.Year;
            if (UserBirthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public void SetZodiac()
        {
            switch (UserBirthDate.Month)
            {
                case 1:
                    if (UserBirthDate.Day <= 20) WesternZodiac = "Capricorn";
                    else
                    { WesternZodiac = "Aquarius"; }
                    break;
                case 2:
                    if (UserBirthDate.Day <= 19)
                    { WesternZodiac = "Aquarius"; }
                    else
                    { WesternZodiac = "Pisces"; }
                    break;
                case 3:
                    if (UserBirthDate.Day <= 20)
                    { WesternZodiac = "Pisces"; }
                    else
                    { WesternZodiac = "Aries"; }
                    break;
                case 4:
                    if (UserBirthDate.Day <= 20)
                    { WesternZodiac = "Aries"; }
                    else
                    { WesternZodiac = "Taurus"; }
                    break;
                case 5:
                    if (UserBirthDate.Day <= 21)
                    { WesternZodiac = "Taurus"; }
                    else
                    { WesternZodiac = "Gemini"; }
                    break;
                case 6:
                    if (UserBirthDate.Day <= 22)
                    { WesternZodiac = "Gemini"; }
                    else
                    { WesternZodiac = "Cancer"; }
                    break;
                case 7:
                    if (UserBirthDate.Day <= 22)
                    { WesternZodiac = "Cancer"; }
                    else
                    { WesternZodiac = "Leo"; }
                    break;
                case 8:
                    if (UserBirthDate.Day <= 23)
                    { WesternZodiac = "Leo"; }
                    else
                    { WesternZodiac = "Virgo"; ; }
                    break;
                case 9:
                    if (UserBirthDate.Day <= 23)
                    { WesternZodiac = "Virgo"; }
                    else
                    { WesternZodiac = "Libra"; }
                    break;
                case 10:
                    if (UserBirthDate.Day <= 23)
                    { WesternZodiac = "Libra"; }
                    else
                    { WesternZodiac = "Scorpio"; ; }
                    break;
                case 11:
                    if (UserBirthDate.Day <= 22)
                    { WesternZodiac = "Scorpio"; }
                    else
                    { WesternZodiac = "Sagittarius"; }
                    break;
                case 12:
                    if (UserBirthDate.Day <= 21)
                    { WesternZodiac = "Sagittarius"; }
                    else
                    { WesternZodiac = "Capricorn"; }
                    break;
                default:
                    break;
            }
        }
        public void SetChineseZodiac()
        {
            string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };


            int ei = (int)Math.Floor((UserBirthDate.Year - 4.0) % 10 / 2);
            int ai = (UserBirthDate.Year - 4) % 12;

            ChineseZodiac = elements[ei] + " " + animals[ai];
        }
    }
}

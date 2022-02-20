using Desktop.Date_Ivanenko.ViewModels;
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

namespace Desktop.Date_Ivanenko.Views
{
    public partial class DateView : UserControl
    {
        private DateViewModel _viewModel;
        public DateView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DateViewModel();
        }

        private void DpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? date = DpDate.SelectedDate.Value.Date;
            if (date == null)
            {

            } else
            {
                _viewModel.UserBirthDate = DpDate.SelectedDate.Value.Date;
                if (!(_viewModel.UserBirthDate > DateTime.Today) && !(_viewModel.Age > 135))
                {
                    TbAge.Text = _viewModel.Age.ToString();
                    TbWestZodiac.Text = _viewModel.WesternZodiac;
                    TbChineseZodiac.Text = _viewModel.ChineseZodiac;
                } else
                {
                    MessageBox.Show("Inccorect Date!");
                }
            }

        }
    }
}

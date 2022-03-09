using Microsoft.Win32;
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
using TemplateEngineDocumentation.MVVM.Model;
using TemplateEngineDocumentation.MVVM.ViewModel;

namespace TemplateEngineDocumentation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			(DataContext as MainViewModel).FunctionsList.Add(new Function());
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{
				Templater templater = new(DataContext as MainViewModel);
				SaveFileDialog saveFileDialog = new()
				{
					DefaultExt = ".docx",
					Title = "Сохранение",
					Filter = "Word | .docx",
					FilterIndex = 0
				};
				if (saveFileDialog.ShowDialog() == true)
				{
					templater.AddContent(saveFileDialog.FileName);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Проверьте что все поля заполнены правильно");
			}
			
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			var viewModel = (DataContext as MainViewModel);
			var count = viewModel.FunctionsList.Count;
			if (count <= 1)
			{
				return;
			}
			viewModel.FunctionsList.RemoveAt(count - 1);
		}
	}
}

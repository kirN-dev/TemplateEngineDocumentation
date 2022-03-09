using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace TemplateEngineDocumentation.MVVM.ViewModel
{
	class MainViewModel
	{
		public MainViewModel()
		{
			FunctionsList = new();
			FunctionsList.Add(new Function());
		}
		[Required]
		public string NameProgramm { get; set; }

		[Required]
		public string Intended { get; set; }

		[Required]
		public string Based { get; set; }

		[Required]
		public string DevelopmentTopic { get; set; }

		[Required]
		public string Code { get; set; }

		[Required]
		public string FunctionalPurpose { get; set; }

		[Required]
		public string Processor { get; set; }

		[Required]
		public string RAM { get; set; }

		[Required]
		public string HardDiskSpace { get; set; }

		[Required]
		public string VideoAdapter { get; set; }

		[Required]
		public string Screen { get; set; }

		[Required]
		public string VSVersion { get; set; }

		[Required]
		public string RuntimeVersion { get; set; }

		[Required]
		public ObservableCollection<Function> FunctionsList { get; set; }
	}

	public class Function
	{
		public string Title { get; set; }
	}
}

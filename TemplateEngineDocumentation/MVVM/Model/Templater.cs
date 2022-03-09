using System;
using System.IO;
using TemplateEngine.Docx;
using TemplateEngineDocumentation.MVVM.ViewModel;

namespace TemplateEngineDocumentation.MVVM.Model
{
	class Templater
	{
		public MainViewModel _mainViewModel { get; set; }
		public Templater(MainViewModel mainViewModel)
		{
			_mainViewModel = mainViewModel;
		}
		public void AddContent(string fileName)
		{

			File.Delete(fileName);
			File.Copy("SRS.docx", fileName);

			ListContent listContent = new("Function List");
			foreach (var item in _mainViewModel.FunctionsList)
			{
				listContent.AddItem(new FieldContent("Function", item.Title));
			}

			var valuesToFill = new Content(
				new FieldContent("Name programm", _mainViewModel.NameProgramm),
				new FieldContent("Intended", _mainViewModel.Intended),
				new FieldContent("Based", _mainViewModel.Based),
				new FieldContent("Development topic", _mainViewModel.DevelopmentTopic),
				new FieldContent("Code", _mainViewModel.Code),
				new FieldContent("Functional purpose", _mainViewModel.FunctionalPurpose),
				listContent,
				new FieldContent("Processor", _mainViewModel.Processor),
				new FieldContent("RAM", _mainViewModel.RAM),
				new FieldContent("Hard disk space", _mainViewModel.HardDiskSpace),
				new FieldContent("Video Adapter", _mainViewModel.VideoAdapter),
				new FieldContent("Screen", _mainViewModel.Screen),
				new FieldContent("VS version", _mainViewModel.VSVersion),
				new FieldContent("Runtime version", _mainViewModel.RuntimeVersion)
			);

			using (var outputDocument = new TemplateProcessor(fileName)
				.SetRemoveContentControls(true))
			{
				outputDocument.FillContent(valuesToFill);
				outputDocument.SaveChanges();
			}
		}
	}
}

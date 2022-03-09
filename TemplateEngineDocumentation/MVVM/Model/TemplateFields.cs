using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TemplateEngineDocumentation.MVVM.Model
{
	class TemplateFields
	{
		private string _pathFields;
		public TemplateFields(string pathFields)
		{
			PathFields = pathFields;
		}
		public List<string> Fields { get; private set; }
		public string PathFields
		{
			get => _pathFields;
			set
			{
				if (!File.Exists(value))
				{
					throw new ArgumentException(nameof(PathFields), "File not exists");
				}

				_pathFields = value;
			}
		}

		public void SetFields()
		{
			using(StreamReader streamReader = new(PathFields))
			{
				Fields.AddRange(streamReader.ReadToEnd().Split('\n'));
			}
		}
	}
}

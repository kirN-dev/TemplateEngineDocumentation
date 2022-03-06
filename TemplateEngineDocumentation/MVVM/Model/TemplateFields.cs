using System;
using System.Collections.Generic;
using System.IO;

namespace TemplateEngineDocumentation.MVVM.Model
{
    class TemplateFields
    {
        private string _pathFields;
        public TemplateFields(string pathFields)
        {
            PathFields = pathFields;
        }
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

        public Dictionary<string, string> Fields { get; set; }
    }
}

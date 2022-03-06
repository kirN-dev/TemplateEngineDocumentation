using System;
using System.IO;
using TemplateEngine.Docx;

namespace TemplateEngineDocumentation.MVVM.Model
{
    class Templater
    {
        public static void AddContent()
        {
            File.Delete("OutputDocument.docx");
            File.Copy("SRS.docx", "OutputDocument.docx");

            var valuesToFill = new Content(
                new FieldContent("", DateTime.Now.Date.ToString()),
                new TableContent("Team members")
                    .AddRow(
                        new FieldContent("Full name", "Семёнов Илья Васильевич"),
                        new FieldContent("Role", "Разработчик"))
                    .AddRow(
                        new FieldContent("Full name", "Петров Фёдор Анатольевич"),
                        new FieldContent("Role", "Разработчик"))
                    .AddRow(
                        new FieldContent("Full name", "Артемьев Вячеслав Геннадьевич"),
                        new FieldContent("Role", "Ведущий разработчик")),
                new FieldContent("Count", "3")
            );

            using (var outputDocument = new TemplateProcessor("OutputDocument.docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
}

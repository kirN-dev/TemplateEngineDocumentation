using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TemplateEngineDocumentation.Utilites
{
	public class Configuration
	{
		private static string _connection;

		public static string GetPathFileds()
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				 .SetBasePath(Directory.GetCurrentDirectory())
				 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			var configuration = configurationBuilder.Build();
			_connection = configuration["Connection"];
			return _connection;
		}
	}
}

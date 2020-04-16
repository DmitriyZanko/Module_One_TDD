using System.IO;

namespace CalculatorSample.Logic
{
	public class Logger : ILogger
	{
		public void Log(string message)
		{
			File.AppendAllText("log.txt", message);
		}
	}
}

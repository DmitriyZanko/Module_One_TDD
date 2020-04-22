using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorSample.Logic
{
    public class Calculator
    {
		private ILogger _logger;

		public Calculator(ILogger logger)
		{
			_logger = logger;
		}

		public double Add(double x, double y)
		{
			var z = x + y;
			_logger.Log($"Operation Sum: x={x}, y={y}, result={z}");
			return z;
		}

		public double Subtract(double x, double y)
		{
			var z = x - y;
			_logger.Log($"Operation Subtract: x={x}, y={y}, result={z}");
			return z;
		}

		public double Multiply(double x, double y)
		{
			var z = x * y;
			_logger.Log($"Operation Multiply: x={x}, y={y}, result={z}");
			return z;
		}

		public double Divide(double x, double y)
		{
			var z = x / y;
			_logger.Log($"Operation Divide: x={x}, y={y}, result={z}");
			return z;
		}

		public int DivideInt(int x, int y)
		{
			try
			{
				var z = x / y;
				_logger.Log($"Operation Divide: x={x}, y={y}, result={z}");
				return z;
			}
			catch (DivideByZeroException ex)
			{
				_logger.Log($"Operation Divide: x={x}, y={y}, result={ex.Message}");
				throw new DivideByZeroException(ex.Message);
			}
		}

		public double Pow(double x, double y)
		{
			var z = Math.Pow(x, y);
			_logger.Log($"Operation Pow: x={x}, y={y}, result={z}");
			return z;
		}

		public IEnumerable<int> SearchNumbers(int sumDigits, int countDigits)
		{
			var loggerStartMessage = $"Operation SearchNumbers: {nameof(sumDigits)}={sumDigits}, {nameof(countDigits)}={countDigits}, result=";

			if (sumDigits < 0 || countDigits < 0)
			{
				var exceptionMessage = $"Argument {(sumDigits < 0 ? nameof(sumDigits) : nameof(countDigits))} must be zero or positive";
				_logger.Log($"{loggerStartMessage}'{exceptionMessage}'");
				throw new ArgumentException(exceptionMessage);
			}

			var startNumber = (int)Math.Pow(10, countDigits - 1);
			var endNumber = (int)Math.Pow(10, countDigits) - 1;

			var numbers = new List<int>();

			for (int number = startNumber; number <= endNumber; number++)
				if (number.ToString().Sum(c => Convert.ToInt32(c.ToString())) == sumDigits)
					numbers.Add(number);

			var result = numbers.Count > 0 ? new[] { numbers.Count, numbers.Min(), numbers.Max() } : new int[0];

			if (result.Length > 0)
			{
				_logger.Log($"{loggerStartMessage}'{string.Join(", ", result)}'");
				_logger.Log($"All numbers='{string.Join(", ", numbers)}'");
			}
			else
				_logger.Log($"{loggerStartMessage}'NO RESULT'");

			return result;
		}

	}
}

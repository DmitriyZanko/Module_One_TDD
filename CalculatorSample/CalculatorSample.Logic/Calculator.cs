using System;

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

	}
}

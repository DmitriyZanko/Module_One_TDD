using CalculatorSample.Logic;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace CalculatorSample.Tests
{
	[TestFixture]
	public class CalculatorTest
	{
		private Mock<ILogger> InitMock()
		{
			var mock = new Mock<ILogger>();
			mock.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(s => Debug.WriteLine(s));
			return mock;
		}

		private void CheckTest(double expected, double actual, Mock<ILogger> mock)
		{
			mock.Verify(l => l.Log(It.IsAny<string>()), Times.Exactly(1));
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Test_Sum_Positive_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Add(3, 4);
			CheckTest(7, actual, mock);
		}

		[Test]
		public void Test_Sum_Negative_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Add(-2, -6);
			CheckTest(-8, actual, mock);
		}

		[Test]
		public void Test_Subtract_Positive_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Subtract(8, 6);
			CheckTest(2, actual, mock);
		}

		[Test]
		public void Test_Subtract_Negative_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Subtract(-8, -2);
			CheckTest(-6, actual, mock);
		}

		[Test]
		public void Test_Multiply_Positive_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Multiply(5, 2);
			CheckTest(10, actual, mock);
		}

		[Test]
		public void Test_Multiply_Negative_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Multiply(-3, -7);
			CheckTest(21, actual, mock);
		}

		[Test]
		public void Test_Divide_Positive_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Divide(6, 2);
			CheckTest(3, actual, mock);
		}

		[Test]
		public void Test_Divide_Negative_Numbers()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Divide(-8, -2);
			CheckTest(4, actual, mock);
		}

		[Test]
		public void Test_Divide_By_Zero()
		{
			var actual = new Calculator(InitMock().Object).Divide(1, 0);
			Assert.IsTrue(double.IsInfinity(actual));
		}

		[Test]
		public void Test_DivideInt_By_Zero()
		{
			Assert.Throws<DivideByZeroException>(() => new Calculator(InitMock().Object).DivideInt(1, 0));
		}

		[Test]
		public void Test_Pow_Positive_Power()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Pow(3, 2);
			CheckTest(9, actual, mock);
		}

		[Test]
		public void Test_Pow_Negative_Power()
		{
			var mock = InitMock();
			var actual = new Calculator(mock.Object).Pow(4, -2);
			CheckTest(0.0625, actual, mock);
		}
	}
}

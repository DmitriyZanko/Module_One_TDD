using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emotions.Logic;

namespace Emotions.Tests
{
	[TestClass]
	public class NumanTest
	{
		[TestMethod]
		public void Human_Has_Recievied_Awesome_Gift_Test()
		{
			// Arrange
			var human = new Human();
			// Act
			human.RecievedGift();
			// Assert
			// все хорошо если человек испытывает эмоцию и эмоция это радость -> человек улыбается
			Assert.IsTrue(human.HasEmotion);
			Assert.AreEqual(new Happiness().GetType(), human.Emotion.GetType());
		}
	}
}

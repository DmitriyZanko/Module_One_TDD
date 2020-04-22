using System;

namespace Emotions.Logic
{
	public class Human
	{
		public Human()
		{
		}
		public bool HasEmotion => Emotion != null;
		public IEmotion Emotion { get; protected set; }
		public void RecievedGift()
		{
			Emotion = new Happiness();
		}
	}

	public class EmotionFactory : IEmotionFactory
	{
		//public IEmotion Get(EmotionTypes emotionType)
		//{

		//	switch (emotionType)
		//	{
		//		case EmotionTypes.Happiness:
		//			break;
		//		case EmotionTypes.Love:
		//			break;
		//		default:
		//			throw new ArgumentException();
		//	}
		//}
	}
}
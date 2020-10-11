using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
	private static TextWriter instance;

	private List<TextWriterSingle> textWriterSingleList;
	private void Awake()
	{
		instance = this;
		textWriterSingleList = new List<TextWriterSingle>();
	}
	#region  static Functions
	public static TextWriterSingle AddWriter_Static(ArabicText uiText, string textToWrite, float timePerChar,
		bool invisibleChar, bool removeWriter, Action onComplete)
	{
		if (removeWriter)
		{
			instance.Removewriter(uiText);
		}
		return instance.AddWriter(uiText, textToWrite, timePerChar, invisibleChar, onComplete);
	}
	private static void Removewriter_Static(ArabicText uiText)
	{
		instance.Removewriter(uiText);
	}
	#endregion

	public TextWriterSingle AddWriter(ArabicText uiText, string textToWrite, float timePerChar, bool invisibleChar, Action onComplete)
	{
		TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerChar, invisibleChar, onComplete);
		textWriterSingleList.Add(textWriterSingle);
		return textWriterSingle;
	}
	
	private void Removewriter(ArabicText uiText)
	{
		for (int i = 0; i < textWriterSingleList.Count; i++)
		{
			if (textWriterSingleList[i].GetUIText() == uiText)
			{
				textWriterSingleList.RemoveAt(i);
				i--;
			}
		}
	}
	private void Update()
	{
		for (int i = 0; i < textWriterSingleList.Count; i++)
		{
			bool destroyInstance = textWriterSingleList[i].Update();
			if (destroyInstance)
			{
				textWriterSingleList.RemoveAt(i);
				i--;
			}
		}
	}

	public class TextWriterSingle {
		private ArabicText uiText;
		private string textToWrite;
		private float timePerChar;
		private int characterIndex;
		private float timer;
		private bool invisibleChar;
		private Action onComplete;

		public TextWriterSingle(ArabicText uiText, string textToWrite, float timePerChar, bool invisibleChar, Action onComplete)
		{
			this.uiText = uiText;
			this.textToWrite = textToWrite;
			this.timePerChar = timePerChar;
			characterIndex = 0;
			this.onComplete = onComplete;
			this.invisibleChar = invisibleChar;
		}
		public bool Update()
		{
			if (uiText != null)
			{
				timer -= Time.deltaTime;
				while (timer <= 0f)
				{
					timer += timePerChar;
					characterIndex++;
					string text = textToWrite.Substring(0, characterIndex);
					uiText.Text = text;
					if (characterIndex >= textToWrite.Length)
					{
						if (onComplete != null) onComplete();
						uiText = null;
						return true;
					}
				}

			}
			return false;
		}
		public ArabicText GetUIText()
		{
			return uiText;
		}
		public bool isActive()
		{
			return characterIndex < textToWrite.Length;
		}
		public void WriteAllAndDestroy()
		{
			uiText.Text = textToWrite;
			if (onComplete != null) onComplete();
			characterIndex = textToWrite.Length;
			Removewriter_Static(uiText);
		}
	}

}

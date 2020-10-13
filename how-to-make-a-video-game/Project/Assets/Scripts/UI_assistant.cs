using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_assistant : MonoBehaviour
{
	private TextWriter.TextWriterSingle textWriterSingle;
	public  int current_index=0;
	public static int curr_indx=0;
	string[] messageArray;
    private ArabicText messageText;
	public static int sceneIndex = 3;
	public AudioSource source;
	public AudioClip[] clips;
	public GameObject talker;

	private void Awake()
	{
		
		messageText = transform.Find("Talker").Find("message").Find("messageText").GetComponent<ArabicText>();
		initailizeString();
		transform.Find("Talker").Find("message").GetComponent<Button>().onClick.AddListener(() => {
			if (textWriterSingle != null && textWriterSingle.isActive())
			{
				//textWriterSingle.WriteAllAndDestroy();
			}
			else if(current_index < messageArray.Length)
			{
				string message = messageArray[current_index];
				playClip();
				textWriterSingle = TextWriter.AddWriter_Static(messageText, message, 0.1f, true, true, null);
				current_index++;
			}
			else
			{
				SceneManager.LoadScene(sceneIndex);
			}
		});
	}
	private void playClip()
	{	
		source.clip = clips[current_index];
		source.Play();
	}
	private void stopClip()
	{
		source.Stop();
	}
	public void Skip()
	{
		//video.SetActive(false);
		SceneManager.LoadScene(sceneIndex);
	}
	private void initailizeString()
	{
		if (curr_indx == 0)
		{
			messageArray = new string[] {
					" مرحبا يا أصدقاء كيف حالكم امل أن تكونوا بخير",
					"درسنا اليوم عن اللغة العربية",
					"وسنتكلم عن المذكر و المؤنث"
			};
		}

		else if (curr_indx == 1)
		{
			messageArray = new string[] {
					"أحسنت!!",
					"والان الى لعبتنا ",
					"هيا!!!"
			 };
		}



	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2GameManager : MonoBehaviour
{
	[SerializeField]
	public Text scoreText;
	[SerializeField]
	public int maxScore;
	public GameObject LevelComplete;
	public static int score = 0;

	private void Start()
	{
		score = 0;
	}
	void Update()
    {
		if (maxScore==score)
		{
			LevelComplete.SetActive(true);
		}else
		scoreText.text = "Score: " + score; 
    }
}

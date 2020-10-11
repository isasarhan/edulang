using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void startGame()
	{
		SceneManager.LoadScene(0);
	}
	public void endGame()
	{
		Application.Quit();
	}
}

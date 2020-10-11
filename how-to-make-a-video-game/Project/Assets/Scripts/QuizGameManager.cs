using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class QuizGameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unAnsweredQuestions;
    private static int currentIndex;
    private Question currentQuestion;
    
    [SerializeField]
    private ArabicText questionText;
    
    [SerializeField]
    private Transform pointer;
    
    [SerializeField]
    private Image image;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    public AudioClip correct;
    public AudioClip wrong;
    public AudioSource name_sound;

    public GameObject result;
    void Start()
    {
		if (unAnsweredQuestions == null)
		{
            unAnsweredQuestions = questions.ToList();
            currentIndex = 0;
        }
        SetRandomQuestion();
        if (currentQuestion.name.ToString() != Names.هذا.ToString())
		{
            pointer.transform.position += new Vector3(-521, 0, 0);
		}
		
    }

	private void SetRandomQuestion()
	{
        if (currentIndex < questions.Length )
        {
            currentQuestion = questions[currentIndex];
            questionText.Text = currentQuestion.question;
            name_sound.clip = questions[currentIndex].audioClip;
            name_sound.Play();
            image.sprite = currentQuestion.sprite;
        }
    }
    IEnumerator TransitionToNextQuestion()
	{
        yield return new WaitForSeconds(timeBetweenQuestions);
        currentIndex++;

        if (currentIndex < questions.Length)
        {
            SceneManager.LoadScene(1);
        }
        else {
            unAnsweredQuestions = null;
            UI_assistant.curr_indx = 1;
            UI_assistant.sceneIndex = 2;
            SceneManager.LoadScene(0);
        }
            
    }
    public void UserSelection([SerializeField]ArabicText answer)
	{
		if (answer.Text.ToString().Equals((currentQuestion.name.ToString())))
		{
            Debug.Log("True");
            result.SetActive(true);
            ArabicText resultText = result.GetComponent<ArabicText>();
            result.GetComponent<AudioSource>().clip = correct;
            result.GetComponent<AudioSource>().Play();
            resultText.Text = "صحيح";
        }
		else
		{
            Debug.Log("False");
            result.SetActive(true);
            ArabicText resultText = result.GetComponent<ArabicText>();
            result.GetComponent<AudioSource>().clip = wrong;
            result.GetComponent<AudioSource>().Play();
            resultText.Text = "خطأ";
        }
        StartCoroutine(TransitionToNextQuestion());
	}
    
    public enum Names
    {
        هذا , هذه , هذان , هاتان, هؤلاء
    }
}


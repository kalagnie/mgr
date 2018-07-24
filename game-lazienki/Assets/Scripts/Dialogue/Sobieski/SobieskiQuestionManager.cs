using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class SobieskiQuestionManager : MonoBehaviour {

	//Listy pytan i odpowiedzi
	public Question[] questions;
	private static List<Question> unansweredQuestions;
	public Answer1[] answers1;
	private static List<Answer1> unusedAnswers1;
	public Answer2[] answers2;
	private static List<Answer2> unusedAnswers2;

	//Pierwsze pytanie i odpowiedz i ich indeksy
	private Question currentQuestion;
	private int currentQuestionIndex = 0;
	private Answer1 currentAnswer1;
	//private int currentAnswer1Index = 0;
	private Answer2 currentAnswer2;
	//private int currentAnswer2Index = 0;

	//Tekst pytan i odpowiedzi
	[SerializeField]
	private Text questionText;
	[SerializeField]
	private Text answer1Text;
	[SerializeField]
	private Text answer2Text;

	// Czas pomiedzy odpowiedziami
	[SerializeField]
	private float TimeBetweenQuestions = 0.1f;

	void Start(){
		Debug.Log ("Start");
		// answered all of the questions
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
			unansweredQuestions = questions.ToList<Question>();

		if (unusedAnswers1 == null)
			unusedAnswers1 = answers1.ToList<Answer1>();

		if (unusedAnswers2 == null)
			unusedAnswers2 = answers2.ToList<Answer2>();

		if (unansweredQuestions.Count == 0) {
			//ZMIANA SCENY, WYJSCIE
			unansweredQuestions = questions.ToList<Question>();
			unusedAnswers1 = answers1.ToList<Answer1>();
			unusedAnswers2 = answers2.ToList<Answer2>();
			Debug.Log ("EXIT");
		}

		//Inicjalizacja tekstu pytan i odpowiedzi
		currentQuestion = unansweredQuestions [currentQuestionIndex];
		questionText.text = currentQuestion.question;
		currentAnswer1 = unusedAnswers1 [currentQuestionIndex];
		answer1Text.text = currentAnswer1.answer1;
		currentAnswer2 = unusedAnswers2 [currentQuestionIndex];
		answer2Text.text = currentAnswer2.answer2;

		//testing
		/*
		Debug.Log (currentQuestion.question);
		Debug.Log (currentAnswer1.answer1);
		Debug.Log (currentAnswer2.answer2);
		*/
	}

	//Przejscie do nastepnego pytania
	IEnumerator TransitionToNextQuestion(){

		unansweredQuestions.Remove (currentQuestion);
		unusedAnswers1.Remove (currentAnswer1);
		unusedAnswers2.Remove (currentAnswer2);


		yield return new WaitForSeconds (TimeBetweenQuestions);
		//do nastepnego pytania z odpowiedziami
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void UserSelectAnswer1(){
		Debug.Log ("Answer1");
		if (currentQuestionIndex == 0 || currentQuestionIndex == 2 || currentQuestionIndex == 4) {
			Debug.Log ("EXIT");
			//SceneManager.LoadScene (1);
		}
		else
			StartCoroutine(TransitionToNextQuestion());
	}

	public void UserSelectAnswer2(){
		Debug.Log ("Answer2");

		if (currentQuestionIndex == 5) {
			Debug.Log ("EXIT");
			//SceneManager.LoadScene (1);
		}
		else
			StartCoroutine(TransitionToNextQuestion());
	}
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour {

	public Question[] questions;
	private static List<Question> unansweredQuestions;

	private Question currentQuestion;
	private int currentQuestionIndex = 0;

	[SerializeField]
	private Text questionText;

	[SerializeField]
	private float TimeBetweenQuestions = 1f;

	void Start(){
		if (unansweredQuestions == null || unansweredQuestions.Count == 0)
			unansweredQuestions = questions.ToList<Question>();

		currentQuestion = unansweredQuestions [currentQuestionIndex];
		questionText.text = currentQuestion.question;

		//testing
		Debug.Log (currentQuestion.question);
	}

	//void Update(){
	//questionText.text = currentQuestion.question;
	//}

	IEnumerator TransitionToNextQuestion(){
		unansweredQuestions.Remove (currentQuestion);
		yield return new WaitForSeconds (TimeBetweenQuestions);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void UserSelectAnswer1(){
		Debug.Log ("Answer1");
		currentQuestionIndex = 1;
		StartCoroutine(TransitionToNextQuestion ());
	}

	public void UserSelectAnswer2(){
		Debug.Log ("Answer2");
		currentQuestionIndex = 0;
		StartCoroutine(TransitionToNextQuestion ());
	}
}

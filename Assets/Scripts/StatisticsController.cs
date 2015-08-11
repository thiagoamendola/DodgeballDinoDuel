﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatisticsController : MonoBehaviour {

	public GameObject resultPanel;
	public Sprite secondSprite;

	public Text DurationTextDesc;
	public Text MaxMeteorTextDesc;
	public Text KnockedMeteor1TextDesc;
	public Text KnockedMeteor2TextDesc;

	public Text DurationText;
	public Text MaxMeteorText;
	public Text KnockedMeteor1Text;
	public Text KnockedMeteor2Text;

	public Player Player1;
	public Player Player2;
	public MeteorSpawnerScript MeteorSpawner;

	private float Duracao;
	private int MeteorosRebatidos;
	private int MaximoMeteorosSimultaneos;

	private bool AlreadyChanged;
	private int phase;

	

	int DestinationY;

	// Use this for initialization
	void Start () {
		phase = 0;
		resultPanel.transform.position = new Vector2(Screen.width/2f, -Screen.height * 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DisplayStatistics (){
		if (Player2.Vencedor == true){
			transform.Find("ResultPanel").GetComponent<Image>().sprite = secondSprite;
			DurationTextDesc.transform.Translate(new Vector2(-250,0));
			MaxMeteorTextDesc.transform.Translate(new Vector2(-250,0));
			KnockedMeteor1TextDesc.transform.Translate(new Vector2(-250,0));
			KnockedMeteor2TextDesc.transform.Translate(new Vector2(-250,0));

		}
		DurationText.GetComponent<Text>().text = (Time.time - MeteorSpawner.BeginTime).ToString();

		KnockedMeteor1Text.GetComponent<Text>().text = Player1.knockedMeteors.ToString();
		KnockedMeteor2Text.GetComponent<Text>().text = Player2.knockedMeteors.ToString();

		MaxMeteorText.GetComponent<Text>().text = MeteorSpawner.ExpectedMeteors.ToString();

		StartCoroutine("StatisticRoutine");



	}
	
	IEnumerator StatisticRoutine () {
		float EndSlide;

		//Primeira vez que a tela de estatisticas sobe:
		EndSlide = Screen.height * 0.5f;
		gameObject.SetActive(true);
		while(resultPanel.transform.position.y < EndSlide){
			resultPanel.transform.Translate(new Vector2(0,EndSlide * 2.0f * Time.deltaTime));
			yield return null;
		}

		while (!Input.GetKeyDown(KeyCode.Return)){
			yield return null;
		}

		//Descer a tela:
		EndSlide = -Screen.height * 0.5f;
		while(resultPanel.transform.position.y > EndSlide){
			resultPanel.transform.Translate(new Vector2(0, EndSlide * 2.0f * Time.deltaTime));
			yield return null;
		}

		GameObject.Find("!GameController").GetComponent<GameController>().InitiateRound();

		
	}



}
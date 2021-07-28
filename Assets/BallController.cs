using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//スコアを表示するテキスト
	private GameObject scoreText;

	//スコアを加算する計算用
	private int score = 0;

	// Use this for initialization
	void Start()
	{
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update()
	{
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ)
		{
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text>().text = "Game Over";
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other)
	{
		Debug.Log("衝突した " + other.gameObject.tag);

		if (other.gameObject.tag == "SmallStarTag")
		{
			score += 10;
		}

		if (other.gameObject.tag == "LargeStarTag")
		{
			score += 50;
		}

		if (other.gameObject.tag == "SmallCloudTag")
		{
			score += 30;
		}

		if (other.gameObject.tag == "LargeCloudTag")
		{
			score += 40;
		}



		//ScoreTextにスコアを表示
		this.scoreText.GetComponent<Text>().text = "Score " + score;
	}
}




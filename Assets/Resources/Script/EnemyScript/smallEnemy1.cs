using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallEnemy1 : Object
{
	float currentTime;
	float turnpointTime;
	int dirType = 0;

	public override void Initialize()
	{
		base.name = "smallEnemy1";
		base.Hp = 0;
		base.Speed = 2.0f;
		base.ObjectAnim = GetComponent<Animator>();

		turnpointTime = 1.0f;
	}

	public override void Progress()
	{
		if (GameManager.Instance.IntroCanvas.activeInHierarchy == false &&
			GameManager.Instance.CoinCanvas.activeInHierarchy == false)
		{
			transform.position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, 0.0f);
			UpDown();
		}
	}

	public override void Release()
	{

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
			Debug.Log("collision");
	}

	void UpDown()
	{
		currentTime += Time.deltaTime;
	
		if (dirType == 0)
		{
			transform.position += new Vector3(0.0f, -Speed * 0.25f * Time.deltaTime, 0.0f);
	
			if (currentTime > turnpointTime)
			{
				dirType = 1;
				currentTime = 0.0f;
			}
		}
		else if (dirType == 1)
		{
			transform.position += new Vector3(0.0f, Speed * 0.25f * Time.deltaTime, 0.0f);
	
			if (currentTime > turnpointTime)
			{
				dirType = 0;
				currentTime = 0.0f;
			}
		}
	}
}

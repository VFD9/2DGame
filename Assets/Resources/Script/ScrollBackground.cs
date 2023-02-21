using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private BackgroundBuilding[] scrollBackground;

	private float[] blueleftPosX = new float[2];
	private float[] bluerightPosX = new float[2];
	private float[] redleftPosX = new float[2];
	private float[] redrightPosX = new float[2];
	public int loopCount;

	float time;

	private void Start()
	{
		for (int i = 0; i < scrollBackground.Length - 2; ++i)
		{
			Vector2 vect = scrollBackground[i].spritebg.sprite.rect.size /
				scrollBackground[i].spritebg.sprite.pixelsPerUnit;

			blueleftPosX[i] = -(vect.x) * 10.0f;
			bluerightPosX[i] = vect.x * 10.0f;
		}

		for (int i = 2; i < scrollBackground.Length; ++i)
		{
			Vector2 vect = scrollBackground[i].spritebg.sprite.rect.size /
				scrollBackground[i].spritebg.sprite.pixelsPerUnit;

			redleftPosX[i - 2] = -(vect.x) * 10.0f;
			redrightPosX[i - 2] = vect.x * 10.0f;
		}

		loopCount = 0;
		time = 0.0f;
	}

	void Update()
    {
		Scrolling();
		RuinScrolling();
	}
	
    void Scrolling()
	{
		if (Camera.main.transform.position.x == 22.0f)
		{
			for (int i = 0; i < scrollBackground.Length - 2; ++i)
			{
				scrollBackground[i].gameObject.transform.position = new Vector3(
					scrollBackground[i].gameObject.transform.position.x + (-BackgroundManager.Instance.Speed * Time.deltaTime), 0.0f, 0.0f);
		
				if (scrollBackground[i].gameObject.transform.position.x < blueleftPosX[i] * 2.91f) // �����̴� ����� ī�޶󿡼� ������ ����� ���� x ��ǥ : -115.84
				{
					Vector3 nextPos = scrollBackground[i].gameObject.transform.position;
					nextPos = new Vector3(nextPos.x + bluerightPosX[i] + 38.3993f, nextPos.y, nextPos.z);
					scrollBackground[i].gameObject.transform.position = nextPos;
					loopCount += 1;

					if (loopCount > 0 && scrollBackground[i].transform.position == nextPos)
					{
						for (int j = 16; j < scrollBackground[i].transform.childCount; ++j)
							scrollBackground[i].transform.GetChild(j).gameObject.SetActive(true);
					}
				}

				if (loopCount > 1)
				{
					time += Time.deltaTime;

					for (int j = 3; j < 16; ++j)
						scrollBackground[i].transform.GetChild(j).gameObject.SetActive(true);

					if (time >= 5.0f)
					{
						scrollBackground[i].gameObject.SetActive(false);
						scrollBackground[i].transform.position = Vector3.zero;
					}
				}
			}
		}
	}

	// TODO : ���� ����
	void RuinScrolling()
	{
		if (scrollBackground[0].gameObject.activeInHierarchy == false &&
			scrollBackground[1].gameObject.activeInHierarchy == false)
		{
			for (int i = 2; i < scrollBackground.Length; ++i)
			{
				scrollBackground[i].gameObject.SetActive(true);

				scrollBackground[i].gameObject.transform.position = new Vector3(
					scrollBackground[i].transform.position.x + (-BackgroundManager.Instance.Speed * Time.deltaTime), 0.0f, 0.0f);

				if (scrollBackground[i].gameObject.transform.position.x < redleftPosX[i - 2] * 3.75f)
				{
					Vector3 nextPos = scrollBackground[i].gameObject.transform.position;
					nextPos = new Vector3(nextPos.x + redrightPosX[i - 2] + 28.32f, nextPos.y, nextPos.z);
					scrollBackground[i].gameObject.transform.position = nextPos;
				}
			}
		}
	}
}

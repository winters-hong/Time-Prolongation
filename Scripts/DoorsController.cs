using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour
{
	public AnimationClip[] clips;
    public int DoorStayTime = 3;
	private int currentNum;//当前是第几个clip
	private int length;
	float totalTime = 0f;

	// Start is called before the first frame update
	void Start()
	{
		currentNum = 0;
		length = clips.Length;
	}

	// Update is called once per frame
	void Update()
	{
		totalTime += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (currentNum >= length)
				currentNum = 0;
			this.GetComponent<Animation>().clip = clips[currentNum++];
			this.GetComponent<Animation>().Play();
			//Debug.Log("input SPACE!");
		}
	}

	// public void VisitScene(int aim)
	// {
	// 	if(ani_running)
	// 	{
	// 		return;
	// 	}
	// 	else
	// 	{
	// 		ani_running = true;
	// 		switch (aim)
	// 		{
	// 			case 1: currentNum=0; break;
	// 			case 2: currentNum=1; break;
	// 			case 3: currentNum=2; break;
	// 			default: currentNum=0; break;
	// 		}
	// 		this.GetComponent<Animation>().clip = clips[currentNum];
	// 		this.GetComponent<Animation>().Play();
	// 		StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>{   
	// 			this.GetComponent<Animation>().clip = clips[currentNum+3];
	// 			this.GetComponent<Animation>().Play();
    //         	}, 6f));
	// 	}

	// }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
	public GameObject theEnemy;
	public void ChangeAnim()
	{
		theEnemy.GetComponent<Animation>().Play("Attack"); //namnet p� din animation
	}
}


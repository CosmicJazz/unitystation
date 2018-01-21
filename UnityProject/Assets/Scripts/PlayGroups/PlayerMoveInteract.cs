using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player move interact. A check of interactions with colliders
/// </summary>
//TODO move all mission critical interactions to be based off this component to ensure reliability
public class PlayerMoveInteract : MonoBehaviour {

	public bool somethingInPath{ get; private set; }
	public Vector3Int positionOfObstruction { get; private set; }

	void Start()
	{
		somethingInPath = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.layer == 8){
			Debug.Log("Ran into another player! Do something");
		}

		if(other.gameObject.layer == 11){
			Debug.Log("Ran into Object! Do Something");
			somethingInPath = true;
			positionOfObstruction = Vector3Int.RoundToInt(other.transform.localPosition);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == 8) {
			Debug.Log("Left another player! Finish doing something");
		}

		if (other.gameObject.layer == 11) {
			//Left an Object! Do Something
			somethingInPath = false;
		}
	}
}

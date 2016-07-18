using UnityEngine;
using System.Collections;

public class DestroyAddPointContact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){

		Destroy(other.gameObject);
	}
}

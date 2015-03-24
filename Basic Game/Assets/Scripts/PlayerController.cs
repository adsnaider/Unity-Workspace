using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int count;
	public GUIText CountText;
	public GUIText WinText;

	void Start(){
		count = 0;
		CountText.text = "Total: " + count.ToString();
		WinText.text = "";
	}
	void FixedUpdate(){
		float MoveHorizontal = Input.GetAxis ("Horizontal");
		float MoveVertical = Input.GetAxis ("Vertical");
		Vector3 Movement = new Vector3 (MoveHorizontal, 0, MoveVertical);
		rigidbody.AddForce (Movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count++;
			CountText.text = "Total: " + count.ToString();
			if(count>=14){
				WinText.text="You Win! :D";
			}
		}
	}
}

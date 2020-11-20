using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	public float speed = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	public AudioSource Collect;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int cheese;


	void Start()
	{
		rb = GetComponent<Rigidbody>();

		cheese = 12;

		SetCountText();

		winTextObject.SetActive(false);
	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			PlayCollect();

			cheese = cheese - 1;

			SetCountText();
		}
	}

	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{
		countText.text = "Cheese Left: " + cheese.ToString();

		if (cheese <= 0)
		{
			GameController.instance.EndGame();
		}
	}

	
	public void PlayCollect()
    {
		Collect.Play();
    }


}
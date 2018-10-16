using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed;
    private int count = 0;
    public Text countText;
    public Text winText;
	public Text resetText;
    void Update()
    {
        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
		resetText.text = "";
		SetCountText();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 6)
        {
            winText.text = "You Win!";
			resetText.text = "Press the SPACE BAR to play again";
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			}
		}
    }
}

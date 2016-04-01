using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;

    public Text winText;
    public Text countText;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }
    }

    void Start ()
    {
        count = 0;
        SetCountText ();
        speed = 10.0f;
        rb = GetComponent<Rigidbody>();
        winText.text = "";
    }

    void SetCountText ()
    {
        countText.text = "Count " + count.ToString();
        if (count >= 7)
        {
            winText.text = "You Win!";
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
public float xMin, xMax, yMin, yMax;
}


public class CCPlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private float moveInput;

 

    //--text variables--//
    public Text countText;    
    public Text endText;
    private int count;

    public Boundary boundary;
    private float timer;
    private object GameLoader;

    //--Sound--//
    public AudioClip snowFlakeCaught;
    public AudioClip enemyCaught;

    void Start()
    {
        NewMethod();
        count = 0;        
        endText.text = "";
        SetCountText();
        //SetIntroText();
    }

    private void NewMethod()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,moveVertical,0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
            );

        //This does a timer before ending the game after 10 seconds.
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));

        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(snowFlakeCaught);
            count = count + 1;
            SetCountText();

          
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);

            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(enemyCaught);
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));
        }
    }
   
    void SetCountText()
    {
        countText.text = "Caught: " + count.ToString();
        if (count >= 10)
        {
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }
}

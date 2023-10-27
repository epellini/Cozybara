using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float Jump;
    float score;

    [SerializeField]
    bool isOnGround = false;
    bool isAlive = true;

    Rigidbody2D rb;

    public Text ScoreTxt;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isOnGround == true)
            {
                rb.AddForce(Vector2.up * Jump);
                isOnGround = false;
            }     
        }

        if(isAlive)
        {
            score += Time.deltaTime * 2;
            ScoreTxt.text = "SCORE: " + Mathf.Round(score).ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(isOnGround == false)
            {
                isOnGround = true;
            }
        }
        if (collision.gameObject.CompareTag("Crocodile"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}

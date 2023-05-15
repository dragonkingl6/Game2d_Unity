using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMainCode : MonoBehaviour
{
    private Rigidbody2D mbody;
    public static bool isGameOver = false;
    public float speedX, speedY;//toc do theo truc X,Y
    private Animator playerMain;//nhan vat

    public Text tinhdiem;
    int score = 0;
    void Start()
    {
        tinhdiem = GameObject.Find("tinhdiem").GetComponent<Text>();
        
        playerMain = GetComponent<Animator>();//findViewById
        mbody = GameObject.Find("playerMain").GetComponent<Rigidbody2D>();
        //thiet lap trang thai
        playerMain.SetBool("HDChay", false);
        playerMain.SetBool("HDDungIm", true);
        playerMain.SetBool("HDNhay", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "quaivat")
        {
            score--;
            Destroy(collision.gameObject);
            tinhdiem.text = "Diem :" + score.ToString();
            if (score <= 0)
            {

                StartCoroutine(TumbleAndJump());
            }
        }
        if (collision.gameObject.tag == "tien")
        {
            score = score + 2;
            Destroy(collision.gameObject);
            tinhdiem.text = "Diem :" + score.ToString();
        }
        if (collision.gameObject.tag == "kcXanh")
        {
            score = score + 5;
            Destroy(collision.gameObject);
            tinhdiem.text = "Diem :" + score.ToString();
        }
        if (collision.gameObject.tag == "kcXanhLa")
        {
            score = score + 5;
            Destroy(collision.gameObject);
            tinhdiem.text = "Diem :" + score.ToString();
        }
        if (collision.gameObject.tag == "kcDo")
        {
            score = score + 5;
            Destroy(collision.gameObject);
            tinhdiem.text = "Diem :" + score.ToString();
        }
        if (collision.gameObject.tag == "boss")
        {
            score = score - 4;
            Destroy(collision.gameObject);
            tinhdiem.text = "Diem :" + score.ToString();
            if (score <= 0)
            {
                Application.LoadLevel("menu");
            }
        }
        if (collision.gameObject.tag == "thienThach")
        {
            Application.LoadLevel("menu");
        }
        if (collision.gameObject.tag == "ong")
        {
            Application.LoadLevel("menu");
        }
        if (score == 50)
        {
            Application.LoadLevel("win");
        }

    }
    public void moveLeft()
    {
        playerMain.SetBool("HDChay", true);
        playerMain.SetBool("HDDungIm", false);
        playerMain.SetBool("HDNhay", false);
        float forceX = 0f;
        float forceY = 0f;
        float velo = Mathf.Abs(playerMain.velocity.x);
        forceX = -100f;
        Vector2 scale = transform.localScale;
        scale.x = -1;
        transform.localScale = scale;
        mbody.AddForce(new Vector2(forceX, forceY));
    }
    public void moveRight()
    {
        playerMain.SetBool("HDChay", true);
        playerMain.SetBool("HDDungIm", false);
        playerMain.SetBool("HDNhay", false);
        float forceX = 0f;
        float forceY = 0f;
        float velo = Mathf.Abs(playerMain.velocity.x);
        forceX = 100f;
        Vector2 scale = transform.localScale;
        scale.x = 1;
        transform.localScale = scale;
        mbody.AddForce(new Vector2(forceX, forceY));
    }
    public void moveUp()
    {
        playerMain.SetBool("HDChay", false);
        playerMain.SetBool("HDDungIm", false);
        playerMain.SetBool("HDNhay", true);
        gameObject.GetComponent<Rigidbody2D>().velocity
                   = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,
                   speedY);
    }
    private IEnumerator TumbleAndJump()
    {
        // Tumble for 10 seconds
        playerMain.transform.Rotate(0, 0, 45 * Time.deltaTime); // xoay nhân vật một góc 45 độ
        playerMain.transform.position = new Vector2(transform.position.x, transform.position.y + 1f * Time.deltaTime);
        yield return new WaitForSeconds(4f);

        playerMain.SetBool("HDNhay", true);
        yield return new WaitForSeconds(4f);



        // Jump for 10 seconds
        playerMain.SetBool("HDNhay", false);
        playerMain.SetBool("HDChay", true);
        yield return new WaitForSeconds(4f);

        // Return to screens
        Application.LoadLevel("menu");
    }
    void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerMain.SetBool("HDChay", true);
                playerMain.SetBool("HDNhay", false);
                playerMain.SetBool("HDDungIm", false);
                gameObject.transform.Translate(Vector2.left * speedX * Time.deltaTime);
                if (gameObject.transform.localScale.x > 0)
                {
                    gameObject.transform.localScale =
                        new Vector2(gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //nhan vat cu dong
                playerMain.SetBool("HDChay", true);
                playerMain.SetBool("HDNhay", false);
                playerMain.SetBool("HDDungIm", false);
                //di chuyen
                gameObject.transform.Translate(Vector2.right * speedX * Time.deltaTime);
                if (gameObject.transform.localScale.x < 0)
                {
                    gameObject.transform.localScale =
                        new Vector2(gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y);
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                playerMain.SetBool("HDNhay", true);
                playerMain.SetBool("HDChay", false);
                playerMain.SetBool("HDDungIm", false);
                gameObject.GetComponent<Rigidbody2D>().velocity
                    = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,
                    speedY);
            }
            else
            {
                playerMain.SetBool("HDChay", false);
                playerMain.SetBool("HDDungIm", true);
                playerMain.SetBool("HDNhay", false);
            }
            

        }
    }
}
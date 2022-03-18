using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UC2D;

public class PacmanContact : MonoBehaviour
{

    public delegate void Collect();
    public static event Collect OnCollect;

    [SerializeField] private int coins;

    [SerializeField] private Text text;
    [SerializeField] private Image BBImage, SBImage, WEImage;
    [SerializeField] private GameObject BBImageObj, SBO, WEO;
    [SerializeField] private int forRuby, forCoin, forEnemy;
    [SerializeField] private float MaxBufTime;
    private float blueBuf, speedBuf, WallBuf;
    
    private int score = 0;

    private void Start()
    {
        mapGen.SendCoins += HandCoins;
    }

    private void FixedUpdate()
    {
        blueBuf -= Time.deltaTime;
        speedBuf -= Time.deltaTime;
        WallBuf -= Time.deltaTime;
        BBImage.fillAmount = blueBuf / MaxBufTime;
        SBImage.fillAmount = speedBuf / MaxBufTime;
        WEImage.fillAmount = WallBuf / MaxBufTime;

        if(blueBuf <= 0)
        {
            blueBuf = 0;
        }
        if (speedBuf <= 0)
        {
            speedBuf = 0;
            gameObject.GetComponent<Move>().speedBuf = 0;
        }
        if (WallBuf >= 0.3f && WallBuf <= 0.5f)
        {
            transform.position = Vector.Round(transform.position);
        }
        if (WallBuf <= 0)
        {
            WallBuf = 0;
            gameObject.GetComponent<Move>().WallEater = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (blueBuf <= 0)
            {
                SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
            }
            else
            {
                Destroy(collision.gameObject);
                score += forEnemy;
            }
        }

        if (collision.collider.tag == "Wall")
        {
            if (WallBuf <= 0)
            {
                return;
            }
            else
            {
                Destroy(collision.gameObject);
                score += forCoin;
            }
        }

        text.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ruby")
        {
            score += forRuby;
            coins--;
            Destroy(collision.gameObject);
            CoinCheck();
        }

        if (collision.tag == "Coin")
        {
            coins--;
            score += forCoin;
            Destroy(collision.gameObject);
            CoinCheck();
        }

        if (collision.tag == "BlueBaff")
        {
            BBImageObj.SetActive(true);
            blueBuf += MaxBufTime;

            score += forCoin;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "SpeedUp")
        {
            SBO.SetActive(true);
            speedBuf += MaxBufTime;

            score += forCoin;
            Destroy(collision.gameObject);
            gameObject.GetComponent<Move>().speedBuf = 2f;
        }
        if (collision.tag == "WallEater")
        {
            WEO.SetActive(true);
            WallBuf += MaxBufTime;

            score += forCoin;
            Destroy(collision.gameObject);
            gameObject.GetComponent<Move>().WallEater = true;
        }
        text.text = score.ToString();
    }

    private void HandCoins(int coin) 
    {
        coins = coin;
    }

    private void CoinCheck()
    {
        if(coins == 0)
        {
            if (OnCollect != null)
            {
                OnCollect.Invoke();
            }
        }
    }

}

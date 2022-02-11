using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacmanContact : MonoBehaviour
{

    [SerializeField] private Text text;
    [SerializeField] private Image BBImage;
    [SerializeField] private GameObject BBImageObj;
    [SerializeField] private int forRuby, forCoin, forEnemy;
    [SerializeField] private float MaxBufTime;
    private bool blueBuf = false;
    
    private int score = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (!blueBuf)
            {
                SceneManager.LoadScene("mainScene", LoadSceneMode.Single);
            }
            else
            {
                Destroy(collision.gameObject);
                score += forEnemy;
            }
        }

        text.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ruby")
        {
            score += forRuby;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Coin")
        {
            score += forCoin;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "BlueBaff")
        {
            BBImageObj.SetActive(true);
            BBImage.fillAmount = 1;
            blueBuf = true;

            score += forCoin;
            Destroy(collision.gameObject);

            StopAllCoroutines();
            StartCoroutine(BBtime());
        }
        text.text = score.ToString();
    }

    IEnumerator BBtime()
    {
        for (int i = 0; i <= MaxBufTime; i++)
        {
            yield return new WaitForSecondsRealtime(1);
            BBImage.fillAmount = (MaxBufTime - i) / MaxBufTime;
        }
        BBImageObj.SetActive(false);
        blueBuf = false;

        yield return new WaitForEndOfFrame();
    }
    
}

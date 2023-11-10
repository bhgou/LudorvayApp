using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutor : MonoBehaviour
{
    
    public bool block = false;

    public GameObject gameOverPanel;
    public GameObject deathEffect;
    public GameObject gameWinPanel;
    public GameObject collectibleEffect;

    public Rigidbody rb;

    public float delta = 2.3f;
    public float lrSpeed = 2.5f;
    public float upSpeed = 2.5f;
    public float maxUpSpeed = 3f;
    public bool isBoosted = false;

    public AudioClip itemSound;
    public AudioClip deathSound;
   

    Vector3 startPos;


    bool isDead = false;

    private string Word = "Tay";
    private string WordOpr = "Спасибо";

    [SerializeField]private int TextInd = 0;
    float hueValue;

    public List<TextMeshProUGUI> Texti;
    public TextMeshProUGUI GameWinWord;
    public TextMeshProUGUI GamePausedWord;
    public TextMeshProUGUI TextOpisanie;
    public TextMeshProUGUI ScreenWord;
    public TextMeshProUGUI BukviSlova;

    public GameController GC;

    public string Slovo;

    public Color[] colors = new Color[3];


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    void Start()
    {
        TextInd = 0;
        Time.timeScale = 0;
        SoundManager.instance.musicSource.Stop();

        hueValue = Random.Range(0, 10) / 10.0f;

        Bukvi();
        StartCoroutine(SetBackgroundColor());
        Slovoki();
    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            if (isDead == true) return;


            Vector3 newPos = startPos;
            newPos.x += delta * Mathf.Sin(Time.time * lrSpeed);
            transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
            if(block == false)
            {
                if (Input.GetMouseButton(0))
                {
                    isBoosted = true;
                    rb.AddForce(transform.up * upSpeed);
                }
                else if (!Input.GetMouseButton(0))
                {
                    isBoosted = false;
                }
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SoundManager.instance.PlaySingle(deathSound);
            SoundManager.instance.musicSource.Stop();
            
            Death();
        }
        else if (other.gameObject.tag == "Collectible")
        {
            GetItem(other);
        }
        
        if (other.gameObject.tag == "CanvasVorText")
        {
            Slovo += Word[TextInd];
            Slovoki();
            if (TextInd < Word.Length - 1) //если индекс буквы меньше, чем колитество букв 
            {
                TextInd += 1;
                Bukvi();
            }
            else
            {
                StartCoroutine( Pause());
                TextInd = 0;
            }
            Destroy(other.gameObject);
        }
    }

    void GetItem(Collider other)
    {
        Destroy(Instantiate(collectibleEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject);
        GC.AddScore();

        SoundManager.instance.PlaySingle(itemSound);

    }

    void Death()
    {
        isDead = true;

        SoundManager.instance.PlaySingle(deathSound);
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 0.7f);
        StopPlayer();

        StartCoroutine(GameOver());
    }

    void StopPlayer()
    {
        Destroy(this.GetComponent<SphereCollider>());

        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
    }

    IEnumerator SetBackgroundColor() //что-то ненужное
    {
        while (true)
        {
            var i = Random.Range(0, colors.Length);
            Camera.main.backgroundColor = colors[i];
            Mks();
            yield return new WaitForSeconds(6);
        }
    }

    void Mks()
    {
        if(Camera.main.backgroundColor.a == 1)
        {
            this.GetComponent<Outline>().OutlineColor = Color.black;
        }
        else
        {
            this.GetComponent<Outline>().OutlineColor = Color.white;
        }
    }

    public void Bukvi() // какой-то цикл 
    {
        for (int i = 0; i < Texti.Count; i++)
        {
            Texti[i].text = Word[TextInd].ToString();
        }
    }

    public void Slovoki() // не обращайте внимания
    {
        ScreenWord.text = Slovo;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        gameWinPanel.SetActive(true);
        Time.timeScale = 0;
        SoundManager.instance.musicSource.Pause();
        GameWinWord.text = Slovo;
        TextOpisanie.text = WordOpr;
        Slovo = "";
        yield break;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
        BukviSlova.text = Slovo;
        Time.timeScale = 0;
        yield break;
    }

}

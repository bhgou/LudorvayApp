using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
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
    public AudioClip[] Clipi;
   

    Vector3 startPos;

    bool isDead = false;



    public string[] WordsEz =  new string[] {"нянь","анай","чебер","ческыт","валамон","яратон","тау"};
    public string[] WordsEzOpr = new string[] { "Хлеб", "Мама", "Красиво", "Вкусно", "Понятно", "Любовь", "Спасибо" }; // определения слов, они должны быть втаком же порядке, что и сами слова

    public string[] WordsNormal =  new string[] {"абалгы","учкыны","абдран","эскерыны","калык","дышетсконни","кагаз"};
    public string[] WordsNormalOpr = new string[] { "Папоротник", "Смотреть", "удивление", "Исследовать", "Народ", "Школа", "Бумага" }; // определения слов, они должны быть втаком же порядке, что и сами слова

    public string[] WordsHard =  new string[] {"укно","лёг","оброс","конгресс","гур","гид","буд","узы","бам","вуз","пуз"};
    public string[] WordsHardOpr = new string[] { "Окно", "Шишка", "Икона", "Кривой", "Печь", "Хлев", "Расти", "Земляника", "Щека", "Товар", "Яйцо" }; // определения слов, они должны быть втаком же порядке, что и сами слова

    private string[] Wordsss;
    private string[] WordsOpr;

    public int TextInd = 0;
    private int ind = 0;
    float hueValue;

    public List<TextMeshProUGUI> Texti;
    public TextMeshProUGUI GameWinWord;
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
        Time.timeScale = 0;
        SoundManager.instance.musicSource.Stop();

        hueValue = Random.Range(0, 10) / 10.0f;

        if (PlayerPrefs.GetInt("lvl") == 0)
        {
            if (PlayerPrefs.HasKey("TextIndEz"))
            {
                LoadTextEz();
            }
            Wordsss = WordsEz;
            WordsOpr = WordsEzOpr;
        }
        else if (PlayerPrefs.GetInt("lvl") == 1)
        {
            if (PlayerPrefs.HasKey("TextIndNormal"))
            {
                LoadTextNormal();
            }
            Wordsss = WordsNormal;
            WordsOpr = WordsNormalOpr;
        }
        else if (PlayerPrefs.GetInt("lvl") == 2)
        {
            if (PlayerPrefs.HasKey("TextIndHard"))
            {
                LoadTextHard();
            }
            Wordsss = WordsHard;
            WordsOpr = WordsHardOpr;
        }

        //SetBackgroundColor();

        Bukvi();

        if (PlayerPrefs.GetInt("lvl") == 0)
        {
            SaveTextEz();
        }
        else if (PlayerPrefs.GetInt("lvl") == 1)
        {
            SaveTextNormal();
        }
        else if (PlayerPrefs.GetInt("lvl") == 2)
        {
            SaveTextHard();
        }

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

            if (Input.GetMouseButton(0))
            {
                isBoosted = true;
                rb.AddForce(transform.up * upSpeed);
            }
            else if (!Input.GetMouseButton(0))
            {
                isBoosted = false;
            }
            if (TextInd >= Wordsss[ind].Length)
            {
                TextInd = 0;
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
            Slovo += Wordsss[ind][TextInd];
            Slovoki();
            if (TextInd < Wordsss[ind].Length - 1) //если индекс буквы меньше, чем колитество букв
            {
                TextInd += 1;
                Bukvi();
            }
            else
            {
                StartCoroutine( Pause());
                TextInd = 0;
            }
            if (PlayerPrefs.GetInt("lvl") == 0)
            {
                SaveTextEz();
            }
            else if (PlayerPrefs.GetInt("lvl") == 1)
            {
                SaveTextNormal();
            }
            else if (PlayerPrefs.GetInt("lvl") == 2)
            {
                SaveTextHard();
            }
            Destroy(other.gameObject);
        }
    }

    void GetItem(Collider other)
    {
        Destroy(Instantiate(collectibleEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject);
        GC.AddScore();

        var i = Random.Range(0, Clipi.Length);
        SoundManager.instance.PlaySingle(Clipi[i]);

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
            yield return new WaitForSeconds(6);
            Mks();
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
            Texti[i].text = Wordsss[ind][TextInd].ToString();
        }
    }

    public void RandomWord() //Непонятное говно
    {
        //ind = Random.Range(0, Wordsss.Length);
        //ind++;
        if (ind == Wordsss.Length - 1)
        {
            ind = 0;

        }
        else
        {
            ind++;
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
        TextOpisanie.text = WordsOpr[ind];
        Slovo = "";
        RandomWord();
        Bukvi();
        Slovoki();
        if (PlayerPrefs.GetInt("lvl") == 0)
        {
            SaveTextEz();
        }
        else if (PlayerPrefs.GetInt("lvl") == 1)
        {
            SaveTextNormal();
        }
        else if (PlayerPrefs.GetInt("lvl") == 2)
        {
            SaveTextHard();
        }
        yield break;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
        BukviSlova.text = Slovo;
        yield break;
    }


    void SaveTextEz()
    {
        PlayerPrefs.SetInt("TextIndEz", TextInd);
        PlayerPrefs.SetInt("indEz", ind);
        PlayerPrefs.SetString("SlovoEz", Slovo);
    }

    void LoadTextEz()
    {
        TextInd = PlayerPrefs.GetInt("TextIndEz");
        ind = PlayerPrefs.GetInt("indEz");
        Slovo = PlayerPrefs.GetString("SlovoEz");
    }

    void SaveTextNormal()
    {
        PlayerPrefs.SetInt("TextIndNormal", TextInd);
        PlayerPrefs.SetInt("indNormal", ind);
        PlayerPrefs.SetString("SlovoNormal", Slovo);
    }

    void LoadTextNormal()
    {
        TextInd = PlayerPrefs.GetInt("TextIndNormal");
        ind = PlayerPrefs.GetInt("indNormal");
        Slovo = PlayerPrefs.GetString("SlovoNormal");
    }

    void SaveTextHard()
    {
        PlayerPrefs.SetInt("TextIndHard", TextInd);
        PlayerPrefs.SetInt("indHard", ind);
        PlayerPrefs.SetString("SlovoHard", Slovo);
    }

    void LoadTextHard()
    {
        TextInd = PlayerPrefs.GetInt("TextIndHard");
        ind = PlayerPrefs.GetInt("indHard");
        Slovo = PlayerPrefs.GetString("SlovoHard");
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Language : MonoBehaviour
{
    public TextMeshProUGUI Options;
    [SerializeField] private string[] OptionsLanguage = new string[]{"настройки", "настройкаъёс"};
    public TextMeshProUGUI Play;
    [SerializeField] private string[] PlayLanguage = new string[]{"играть","шудыны"};
    public TextMeshProUGUI Quit;
    [SerializeField] private string[] QuitLanguage = new string[]{"выход", "кылбугор"};
    public TextMeshProUGUI[] Levels = new TextMeshProUGUI[3];
    [SerializeField] private string[][] LevelsLanguage = {new string[]{"уровень","чоштала"},
                                                          new string[]{"уровень","чоштала"},
                                                          new string[]{"уровень","чоштала"} };
    public TextMeshProUGUI Musik;
    [SerializeField] private string[] MusikLanguage = new string[]{"музыка","крезьгур"};
    public TextMeshProUGUI LanguageButton;
    [SerializeField] private string[] LanguageButtonLanguage = new string[]{"удмуртский","ӟуч кылын"};
    public TextMeshProUGUI Languagen;
    [SerializeField] private string[] LanguagenLanguage = new string[]{"язык","кыл"};

    void Start()
    {
        if(!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Language", 0);
        }
        Smana();
    }

    public void Languages()
    {
        if(PlayerPrefs.GetInt("Language") == 1)
        {
            PlayerPrefs.SetInt("Language", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Language", 1);
        }
        
        Smana();
    }

    private void Smana()
    {
        int a = PlayerPrefs.GetInt("Language");
        Options.text = OptionsLanguage[a];
        Play.text = PlayLanguage[a];
        Quit.text = QuitLanguage[a];
        Levels[0].text = LevelsLanguage[0][a];
        Levels[1].text = LevelsLanguage[1][a];
        Levels[2].text = LevelsLanguage[2][a];
        Musik.text = MusikLanguage[a];
        LanguageButton.text = LanguageButtonLanguage[a];
        Languagen.text = LanguagenLanguage[a];
    }
}

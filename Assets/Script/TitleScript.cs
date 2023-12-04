using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Tool;

namespace Tool
{
    public class GameManager
    {
        public int m_correct, m_incorrect;
        public int m_nowNumber,m_questionNumber;
        public string m_type;
        static GameManager _instance;
        public Text m_questionText,m_numberText,m_inputText,m_typeText;
        public bool[] isCorrect = new bool[100];


        public static GameManager Instance
        {
            get
            {
                if (_instance == null) _instance = new GameManager();
                return _instance;
            }
        }
        public void LoadScene(int i)
        {
            switch (i)
            {
                case 0:
                    SceneManager.LoadScene("TitleScene");
                    break;
                case 1:
                    SceneManager.LoadScene("QuestionScene");
                    break;
                case 2:
                    SceneManager.LoadScene("ResultScene");
                    break;
            }
        }
        public void SetContents(string type)
        {
            m_type = type;
        }
    }
}

namespace Main
{
    public class TitleScript : MonoBehaviour
    {
        GameManager GM;
        //ジャンルごとの出題漢字と正解の読み方リスト
        [SerializeField]List<string> Plants, PlantsRuby,PlantsRuby2, Fish, FishRuby,FishRuby2,Animals, AnimalsRuby,AnimalsRuby2 ,Birds, BirdsRuby,BirdsRuby2,Weather, WeatherRuby,WeatherRuby2, Ateji, AtejiRuby,AtejiRuby2, Country, CountryRuby,CountryRuby2, Verv, VervRuby,VervRuby2;
        [SerializeField]List<char> PlantsTips, FishTips, AnimalsTips,BirdsTips,WeatherTips,AtejiTips,CountryTips,VervTips;
        [SerializeField]List<int> PlantsWC, FishWC, AnimalsWC, BirdsWC, WeatherWC, AtejiWC, CountryWC, VervWC;
        [SerializeField] Text Count;
        public int questionNumber;
        public string type;
        //ランダムで選出された問題
        public static string[] randomQuestion = new string[100], questionsAnswer = new string[100],questionsAnswer2 = new string[100];
        public static char[] Tips = new char[100];
        public static int[] wordCount = new int[100];

        private void Start()
        {
            GM = GameManager.Instance;
            GM.m_questionNumber = questionNumber;
        }
    
        public void OnClick(int number)
        {
            switch (number)
            {
                case 0:
                    for (int pli = 0; pli < GM.m_questionNumber; pli++) {
                        int pl = Random.Range(0, Plants.Count);
                        randomQuestion[pli] = Plants[pl];
                        questionsAnswer[pli] = PlantsRuby[pl];
                        questionsAnswer2[pli] = PlantsRuby2[pl];
                        Tips[pli] = PlantsTips[pl];
                        wordCount[pli] = PlantsWC[pl];
                        type = "植物";
                        Plants.RemoveAt(pl);
                        PlantsRuby.RemoveAt(pl);
                        PlantsRuby2.RemoveAt(pl);
                        PlantsTips.RemoveAt(pl);
                        PlantsWC.RemoveAt(pl);
                        GM.SetContents(type);
                    }
                    break;
                case 1:
                    for (int fii = 0; fii < GM.m_questionNumber; fii++){
                        int fi = Random.Range(0, Fish.Count);
                        randomQuestion[fii] = Fish[fi];
                        questionsAnswer[fii] = FishRuby[fi];
                        questionsAnswer2[fii] = FishRuby2[fi];
                        Tips[fii] = FishTips[fi];
                        wordCount[fii] = FishWC[fi];
                        type = "魚";
                        Fish.RemoveAt(fi);
                        FishRuby.RemoveAt(fi);
                        FishRuby2.RemoveAt(fi);
                        FishTips.RemoveAt(fi);
                        FishWC.RemoveAt(fi);
                        GM.SetContents(type);
                    }
                    break;
                case 2:
                    for (int ani = 0; ani < GM.m_questionNumber; ani++)
                    {
                        int an = Random.Range(0, Animals.Count);
                        randomQuestion[ani] = Animals[an];
                        questionsAnswer[ani] = AnimalsRuby[an];
                        questionsAnswer2[ani] = AnimalsRuby2[an];
                        Tips[ani] = AnimalsTips[an];
                        wordCount[ani] = AnimalsWC[an];
                        type = "動物";
                        Animals.RemoveAt(an);
                        AnimalsRuby.RemoveAt(an);
                        AnimalsRuby2.RemoveAt(an);
                        AnimalsTips.RemoveAt(an);
                        AnimalsWC.RemoveAt(an);
                        GM.SetContents(type);
                    }
                    break;
                case 3:
                    for (int bii = 0; bii < GM.m_questionNumber; bii++)
                    {
                        int bi = Random.Range(0, Birds.Count);
                        randomQuestion[bii] = Birds[bi];
                        questionsAnswer[bii] = BirdsRuby[bi];
                        questionsAnswer2[bii] = BirdsRuby2[bi];
                        Tips[bii] = BirdsTips[bi];
                        wordCount[bii] = BirdsWC[bi];
                        type = "鳥";
                        Birds.RemoveAt(bi);
                        BirdsRuby.RemoveAt(bi);
                        BirdsRuby2.RemoveAt(bi);
                        BirdsTips.RemoveAt(bi);
                        BirdsWC.RemoveAt(bi);
                        GM.SetContents(type);
                    }
                    break;
                case 4:
                    for (int wei = 0; wei < GM.m_questionNumber; wei++)
                    {
                        int we = Random.Range(0, Weather.Count);
                        randomQuestion[wei] = Weather[we];
                        questionsAnswer[wei] = WeatherRuby[we];
                        questionsAnswer2[wei] = WeatherRuby2[we];
                        Tips[wei] = WeatherTips[we];
                        wordCount[wei] = WeatherWC[we];
                        type = "天気";
                        Weather.RemoveAt(we);
                        WeatherRuby.RemoveAt(we);
                        WeatherRuby2.RemoveAt(we);
                        WeatherTips.RemoveAt(we);
                        WeatherWC.RemoveAt(we);
                        GM.SetContents(type);
                    }
                    break;
                case 5:
                    for (int ati = 0; ati < GM.m_questionNumber; ati++)
                    {
                        int at = Random.Range(0, Ateji.Count);
                        randomQuestion[ati] = Ateji[at];
                        questionsAnswer[ati] = AtejiRuby[at];
                        questionsAnswer2[ati] = AtejiRuby2[at];
                        Tips[ati] = AtejiTips[at];
                        wordCount[ati] = AtejiWC[at];
                        type = "当て字";
                        Ateji.RemoveAt(at);
                        AtejiRuby.RemoveAt(at);
                        AtejiRuby2.RemoveAt(at);
                        AtejiTips.RemoveAt(at);
                        AtejiWC.RemoveAt(at);
                        GM.SetContents(type);
                    }
                    break;
                case 6:
                    for (int coi = 0; coi < GM.m_questionNumber; coi++)
                    {
                        int co = Random.Range(0, Country.Count);
                        randomQuestion[coi] = Country[co];
                        questionsAnswer[coi] = CountryRuby[co];
                        questionsAnswer2[coi] = CountryRuby2[co];
                        Tips[coi] = CountryTips[co];
                        wordCount[coi] = CountryWC[co];
                        type = "国";
                        Country.RemoveAt(co);
                        CountryRuby.RemoveAt(co);
                        CountryRuby2.RemoveAt(co);
                        CountryTips.RemoveAt(co);
                        CountryWC.RemoveAt(co);
                        GM.SetContents(type);
                    }
                    break;
                case 7:
                    for (int vei = 0; vei < GM.m_questionNumber; vei++)
                    {
                        int ve = Random.Range(0, Verv.Count);
                        randomQuestion[vei] = Verv[ve];
                        questionsAnswer[vei] = VervRuby[ve];
                        questionsAnswer2[vei] = VervRuby2[ve];
                        Tips[vei] = VervTips[ve];
                        wordCount[vei] = VervWC[ve];
                        type = "動作";
                        Verv.RemoveAt(ve);
                        VervRuby.RemoveAt(ve);
                        VervRuby2.RemoveAt(ve);
                        VervTips.RemoveAt(ve);
                        VervWC.RemoveAt(ve);
                        GM.SetContents(type);
                    }
                    break;
                default:
                    break;
            }
            SceneManager.LoadScene("QuestionScene");
        }

        public void OnClickNumber(int num)
        {
            switch (num)
            {
                case 0:
                    GM.m_questionNumber = 10;
                    Count.text = "10問";
                    Debug.Log("10問");
                    break;
                case 1:
                    GM.m_questionNumber = 15;
                    Count.text = "15問";
                    Debug.Log("15問");
                    break;
                case 2:
                    GM.m_questionNumber = 20;
                    Count.text = "20問";
                    Debug.Log("20問");
                    break;
                case 3:
                    GM.m_questionNumber = 25;
                    Count.text = "25問";
                    Debug.Log("25問");
                    break;
            }
        }
        public void OnExit()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
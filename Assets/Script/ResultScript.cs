using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tool;
using DG.Tweening;
public class ResultScript : QuestionScript
{
    GameManager GM;
    SaveResult sr;
    public Text ResultText;
    [SerializeField] GameObject Panel,Maru,Batsu;
    [SerializeField] Text t_numberText, t_questionText, t_answerText;
    [SerializeField] Transform objectParent;
    public static bool[] isCorrect =new bool[100];
    public static int[] i_number = new int[100];
    public static string[] s_question = new string[100], s_answer = new string[100];
    void Start()
    {
        GM = GameManager.Instance;
        sr = new SaveResult();
        Sllow(GM.m_correct, GM.m_incorrect);
        Calc(GM.m_correct, GM.m_questionNumber);
    }
    public void OnClickButton(int num)
    {
        switch (num)
        {
            case 0:
                GM.LoadScene(0);
                break;
            case 1:
                GM.m_nowNumber = 0;
                GM.LoadScene(1);
                break;
                    
        }
    }

    public void OnClickPaper()
    {
        Debug.Log("答え合わせ");
        Panel.transform.DOScale(new Vector2(1, 1), 1f).SetEase(Ease.OutExpo);


    }
    private void Sllow(int correction,int incorrection)
    {
        ResultText.text = "正解数：" + correction + "  不正解数：" + incorrection;
    }

    void Input()
    {
        for (int i = 0; i < GM.m_questionNumber; i++)
        {
            t_questionText.text = randomQuestion[i];
            t_answerText.text = questionsAnswer[i];
            i_number[i] = i+1 ;
            t_numberText.text = "("+i_number[i]+")";
            Judging(GM.isCorrect[i]);
        }
    }

    void Judging(bool iscorrect)
    {
        if (iscorrect == true)
        {
            Instantiate(Maru, transform.position, Quaternion.identity, objectParent);
        }else if(iscorrect == false)
        {
            Instantiate(Batsu, transform.position, Quaternion.identity, objectParent);
        }
    }
    void Calc(float _correct,float _number)
    {
        if (sr.isUsed == true)
        {
            string s = PlayerPrefs.GetString("SaveResult");
            var d = JsonUtility.FromJson<SaveResult>(s);
        }
        else { sr.isUsed = true; }
        sr.correct += _correct;
        float currentCorrect = sr.correct;
        Debug.Log(currentCorrect);
        sr.totalNumber += _number;
        float currentNumber = sr.totalNumber;
        Debug.Log(currentNumber);
        string json = JsonUtility.ToJson(sr);
        PlayerPrefs.SetString("SaveResult",json);


        float par = currentCorrect/currentNumber;
        Debug.Log(par);
        par = par * 100;
        Debug.Log(par+"%");
    }
    
}

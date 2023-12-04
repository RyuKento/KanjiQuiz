using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tool;
using Main;
using DG.Tweening;

public class QuestionScript : TitleScript
{
    GameManager GM;
    public Text QuestionText,InputText,NumberText,TypeText,TipsText,WordCountText,IncorrectText,AnswerText;
    public InputField inputField;
    public GameObject inputField_test;
    public GameObject maru;
    public GameObject passButton;
    public GameObject x;
    public string Answer,AnswerAnother;
    public char tips;
    public int nowNumber = 1,count,Correct,InCorrect,wordCounter;
    public AudioClip correctSound,inCorrectSound,skipSound;
    AudioSource audioSource;

    void Start()
    {
        GM = GameManager.Instance;
        inputField = inputField.GetComponent<InputField>();
        InputText = InputText.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        QuestionText.text = randomQuestion[0];
        Answer = questionsAnswer[0];
        AnswerAnother = questionsAnswer2[0];
        tips = Tips[0];
        wordCounter = wordCount[0];
        NowNumber(0);
        Debug.Log(GM.m_questionNumber);
        Correct = 0;
        InCorrect = 0;
        TypeText.text = "ジャンル：" + GM.m_type;
        Debug.Log(Answer);
        Debug.Log(AnswerAnother);
        inputField.ActivateInputField();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TipsOpen();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            WordCounterOpen();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Pass();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GiveUp();
        }
    }

    public void TipsOpen()
    {
        Debug.Log(tips);
        TipsText.text = "一文字目は「" + tips + "」";
    }
    public void WordCounterOpen()
    {
        Debug.Log(wordCounter);
        WordCountText.text = wordCounter + "文字";
    }
    public void OnValueChanged()
    {
        string value = inputField.GetComponent<InputField>().text;
        if(value.IndexOf("\n") != -1)
        {
            value = value.Trim();
            Jugde(value);
        }
    }
    public void GiveUp()
    {
        GM.m_correct = this.Correct;
        GM.m_incorrect = this.InCorrect;
        GM.LoadScene(2);
    }
    public void DeleatInput()
    {
        string value = inputField.GetComponent<InputField>().text;
        if (value == "")
        {
            Jugde(value);
        }
    }

    public void Jugde(string Input)
    {
        if ((Input == Answer)||(Input == AnswerAnother))
        {
            Correct = Correct + 1;
            if (nowNumber == GM.m_questionNumber)
            {
                StartCoroutine(WaitForSecondsCoroutine());
            }
            Debug.Log("正解！" + nowNumber);
            maru.transform.localScale = new Vector2(1, 1);
            inputField_test.SetActive(false);
            passButton.SetActive(false);
            Playback(0);
            StartCoroutine(CorrectCoroutine());
            //QuestionText.text = randomQuestion[nowNumber];
            //Answer = questionsAnswer[nowNumber];
            //AnswerAnother = questionsAnswer2[nowNumber];
            //Debug.Log(Answer);
            //Debug.Log(AnswerAnother);
            //tips = Tips[nowNumber];
            //wordCounter = wordCount[nowNumber];
            //NowNumber(nowNumber);
            //TipsText.text = "一文字目ヒント";
            //WordCountText.text = "文字数ヒント";
            //GM.isCorrect[count] = true;
            //count++;
            //nowNumber = nowNumber + 1;
            //GM.m_nowNumber = this.nowNumber;
        }
        else if ((Input != Answer) || (Input == AnswerAnother) && (Input != ""))
        {
            Debug.Log(Input);
            Debug.Log("違います！");
            x.transform.localScale = new Vector2(0, 0);
            x.transform.localScale = new Vector2(1, 0.75f);
            Playback(1);
            StartCoroutine(CrossCoroutine());
        }
        else if(Input =="")
        {
            return;
        }
        inputField.text = "";
    }
    public void Pass()
    {
        InCorrect = InCorrect + 1;
        if (nowNumber == GM.m_questionNumber)
        {
            StartCoroutine(WaitForSecondsCoroutine());
        }
        Debug.Log("パスしました" + nowNumber);
        inputField_test.SetActive(false);
        passButton.SetActive(false);
        Playback(2);
        StartCoroutine(InCorrectCoroutine());
        //QuestionText.text = randomQuestion[nowNumber];
        //Answer = questionsAnswer[nowNumber];
        //AnswerAnother = questionsAnswer2[nowNumber];
        //Debug.Log(Answer);
        //Debug.Log(AnswerAnother);
        //tips = Tips[nowNumber];
        //wordCounter = wordCount[nowNumber];
        //NowNumber(nowNumber);
        //TipsText.text = "一文字目ヒント";
        //WordCountText.text = "文字数ヒント";
        //GM.isCorrect[count] = false;
        //count++;
        //nowNumber = nowNumber + 1;
        //GM.m_nowNumber = this.nowNumber;
        //inputField.text = "";
    }

    void Playback(int i)
    {
        switch (i)
        {
            case 0:
                audioSource.PlayOneShot(correctSound);
                break;
            case 1:
                audioSource.PlayOneShot(inCorrectSound);
                break;
            case 2:
                audioSource.PlayOneShot(skipSound);
                break;
        }
    }

    void Initializing()
    {
        QuestionText.text = randomQuestion[nowNumber];
        Answer = questionsAnswer[nowNumber];
        AnswerAnother = questionsAnswer2[nowNumber];
        AnswerText.text = "";
        tips = Tips[nowNumber];
        wordCounter = wordCount[nowNumber];
        inputField_test.SetActive(true);
        passButton.SetActive(true);
        inputField.ActivateInputField();
        NowNumber(nowNumber);
        TipsText.text = "一文字目ヒント";
        WordCountText.text = "文字数ヒント";
        nowNumber = nowNumber + 1;
        GM.m_nowNumber = this.nowNumber;

        Debug.Log(Answer);
        Debug.Log(AnswerAnother);
    }
    public void NowNumber(int j)
    {
        switch (j)
        {
            case 0:
                SetQuestionNumber("一");
                break;
            case 1:
                SetQuestionNumber("二");
                break;
            case 2:
                SetQuestionNumber("三");
                break;
            case 3:
                SetQuestionNumber("四");
                break;
            case 4:
                SetQuestionNumber("五");
                break;
            case 5:
                SetQuestionNumber("六");
                break;
            case 6:
                SetQuestionNumber("七");
                break;
            case 7:
                SetQuestionNumber("八");
                break;
            case 8:
                SetQuestionNumber("九");
                break;
            case 9:
                SetQuestionNumber("十");
                break;
            case 10:
                SetQuestionNumber("十一");
                break;
            case 11:
                SetQuestionNumber("十二");
                break;
            case 12:
                SetQuestionNumber("十三");
                break;
            case 13:
                SetQuestionNumber("十四");
                break;
            case 14:
                SetQuestionNumber("十五");
                break;
            case 15:
                SetQuestionNumber("十六");
                break;
            case 16:
                SetQuestionNumber("十七");
                break;
            case 17:
                SetQuestionNumber("十八");
                break;
            case 18:
                SetQuestionNumber("十九");
                break;
            case 19:
                SetQuestionNumber("二十");
                break;
            case 20:
                SetQuestionNumber("二十一");
                break;
            case 21:
                SetQuestionNumber("二十二");
                break;
            case 22:
                SetQuestionNumber("二十三");
                break;
            case 23:
                SetQuestionNumber("二十四");
                break;
            case 24:
                SetQuestionNumber("二十五");
                break;
            default:
                break;
        }

    }

    public void SetQuestionNumber(string number)
    {
        NumberText.text = "第" + number + "問目";
    } 

    private IEnumerator InCorrectCoroutine()
    {
        Debug.Log("開始");
        AnswerText.text = Answer;
        yield return new WaitForSeconds(2.5f);
        Initializing();
        GM.isCorrect[count] = false;
        count++;
        inputField.text = "";
        Debug.Log("終わり");
    }
    private IEnumerator CorrectCoroutine()
    {
        Debug.Log("始め");
        AnswerText.text = inputField.text.Trim();
        yield return new WaitForSeconds(2.5f);
        Initializing();
        maru.transform.localScale=new Vector2(0,0);

        GM.isCorrect[count] = true;
        count++;

        Debug.Log("終了");
    }
    private IEnumerator WaitForSecondsCoroutine()
    {
        GM.m_correct = this.Correct;
        GM.m_incorrect = this.InCorrect;
        yield return new WaitForSeconds(2f);
        GM.LoadScene(2);
    }
    private IEnumerator CrossCoroutine()
    {
        Debug.Log("cross");
        yield return new WaitForSeconds(1);
        x.transform.localScale = new Vector2(0, 0);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;

public class GameHandler : MonoBehaviour
{
    public GameObject InstructionPanel;
    public GameObject GamePanel;
    public GameObject Extras;
    public Image FlagImage;
    public Button[] Options;
    private string Answer;
    public Sprite[] result;
    public GameObject resultGO;
    private Image resultImage;
    public Text gradeText;
    private int total;
    private int correct;
    CanvasGroup ResultCanvasGroup;
    CanvasGroup StreakCanvasGroup;
    public GameObject streakGO;
    private int GameIndex;
    public GameObject FinishPanel;
    public Text correctText;
    public Text wrongText;
    public Text totalText;
    public int[] FlagArray;
    private int count;
    public List<int> countryList = null;
    public List<int> GameList = null;
    public List<string> Countries = null;
    private string level;
    public Text DifficultyText;
    public Text comment;
    private int streakCounter;
    public Text streakText;
    public Text YourScore;
    User user = new User();
    private int wrong;
    public Sprite[] Level1;
    public Sprite[] Level2;
    public Sprite[] Level3;
    public Sprite[] Level4;
    public Sprite[] Level5;
    public Sprite[] Level6;
    public Sprite[] Level7;
    public Sprite[] Level8;
    public Sprite[] Level9;
    public Sprite[] Level10;
    public Sprite[] Level11;
    public Sprite[] Level12;
    public Sprite[] Level13;
    public Sprite[] Level14;
    public Sprite[] Level15;
    bool InPlay;
    float timer;
    public Sprite[] FlagSprite;
    public Text timerText;
    public float startTime;
    bool keepTiming;
    float initTime;
    float countDown;
    bool TimeUp;
    public GameObject NextPanel;
    public Text nextLevelTxt;
    public Text questionsTxt;
    private float nextTime;
    public Text timeTxt;
    public GameObject retryBtn;
    private int InitScore;
    private int InitQuest;
    private int InitCorrect;
    private int Init_Total;
    private int InitWrong;
    public Sprite[] InitLevel;
    public Text Nextcomment;
    int correct_Counter;
    public Sprite[] PassOrFail;
    public Image passOrfail;


    public static int Score;
    public static string ClassName;
    //public string[] Countries = new string[] { "Uganda", "United States", "United Kingdom", "Germany", "Argentina", "Japan", "Canada", "India" };



    void Start()
    {
        //To reset values
        /*Score = 0;
        total = 0;
        wrong = 0;
        nextTime = 60f;
        level = "1";*/


        //PlayerPrefs
        if (PlayerPrefs.HasKey("Score"))
        {
            Score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            Score = 0;
        }

        if (PlayerPrefs.HasKey("Total"))
        {
           total = PlayerPrefs.GetInt("Total");
        }
        else
        {
            total = 0;
        }

        if (PlayerPrefs.HasKey("Wrong"))
        {
            wrong = PlayerPrefs.GetInt("Wrong");
        }
        else
        {
            wrong = 0;
        }

        if (PlayerPrefs.HasKey("Correct"))
        {
            correct = PlayerPrefs.GetInt("Correct");
        }
        else
        {
            wrong = 0;
        }

        if (PlayerPrefs.HasKey("nextTime"))
        {
            nextTime = PlayerPrefs.GetFloat("nextTime");
        }
        else
        {
            nextTime = 60f;
        }

        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetString("Level");
        }
        else
        {
            level = "1";
        }

        //Initializers
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ResultCanvasGroup = resultGO.GetComponent<CanvasGroup>();
        StreakCanvasGroup = streakGO.GetComponent<CanvasGroup>();
        resultGO.SetActive(false);
        streakGO.SetActive(false);
        InstructionPanel.SetActive(true);
        GamePanel.SetActive(false);
        Extras.SetActive(false);
        FinishPanel.SetActive(false);
        NextPanel.SetActive(false);
        retryBtn.SetActive(false);

        if(resultGO != null)
        resultImage = resultGO.GetComponent<Image>();


        DifficultyText.text = "Level " + level;
        streakCounter = 0;
        ClassName = "Geography 1";
      
        


        //Setting flags
        if(level == "1")
        FlagSprite = Level1;
        else
        if (level == "2")
        FlagSprite = Level2;
        else
        if (level == "3")
            FlagSprite = Level3;
        else
         if (level == "4")
            FlagSprite = Level4;
        else
        if (level == "5")
            FlagSprite = Level5;
        else
        if (level == "6")
            FlagSprite = Level6;
        else
        if (level == "7")
            FlagSprite = Level7;
        else
        if (level == "8")
            FlagSprite = Level8;
        else
        if (level == "9")
            FlagSprite = Level9;
        else
        if (level == "10")
            FlagSprite = Level10;
        else
        if (level == "11")
            FlagSprite = Level11;
        else
        if (level == "12")
            FlagSprite = Level12;
        else
        if (level == "13")
            FlagSprite = Level13;
        else
        if (level == "14")
            FlagSprite = Level14;
        else
        if (level == "15")
            FlagSprite = Level15;


        if(level != "Done")
        {
            //Loading list values
            ReloadCountryNames();
            ReloadListGame();
            ReloadListCountries();

            //Choosing first flag
            GameIndex = GetUniqueRandomGame();
        }
        else
        {
            Finish();
        }



        InPlay = false;
        TimeUp = false;
        InitLevel = FlagSprite;
        correct_Counter = 0;
        passOrfail.sprite = PassOrFail[0];
       

    }


  
    void Update()
    {
        gradeText.text = correct.ToString() + "/" + total.ToString();



        if (keepTiming)
        {
            UpdateTime();
            if (timer >= nextTime)
            {
                StopTimer();
                timerText.text = "0:0.00";
                TimeUp = true;
                GameOver();
                comment.text = "You ran out of time";
                passOrfail.sprite = PassOrFail[1];
                //Debug.Log("Timer stopped at " + TimeToString(StopTimer()));
            }
        }
    }

    public void StartGame()
    {
        InstructionPanel.SetActive(false);
        GamePanel.SetActive(true);
        Extras.SetActive(true);

        // Set Game
        SetFlagOptions(GameIndex);
        InPlay = true;
        StartTimer();
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }



    int GetUniqueRandomCountry()
    {

        int rand = Random.Range(0, countryList.Count-1);
        int value = countryList[rand];
        countryList.RemoveAt(rand);
        return value;
    }

    public void ReloadCountryNames()
    {

        Countries.Clear();
        for (int i = 0; i < FlagSprite.Length; i++)
        {
            Countries.Add(FlagSprite[i].name);
        }
    }

    public void ReloadListCountries()
    {

        countryList.Clear();
        for (int i = 0; i < Countries.Count; i++)
        {
            countryList.Add(i);
        }
    }


    int GetUniqueRandomGame()
    {
        int rand = Random.Range(0, GameList.Count - 1);
        int value = GameList[rand];
        GameList.RemoveAt(rand);
        return value;
    }

    public void ReloadListGame()
    {

        GameList.Clear();
        for (int i = 0; i < FlagSprite.Length; i++)
        {
            GameList.Add(i);
        }
    }


    public void SetWordSet(int AnsIndex)
    {
        int randomAnsPos = Random.Range(0, 3);
        for (int i = 0; i < 4; i++)
        {
            if (i != randomAnsPos)
            {
                int randNum = GetUniqueRandomCountry();
                while (Countries[randNum] == FlagSprite[AnsIndex].name)
                {
                   randNum = GetUniqueRandomCountry();
                }

                Options[i].GetComponentInChildren<Text>().text = Countries[randNum];
                Options[i].name = Countries[randNum];
            }
            else
            {
                Options[i].GetComponentInChildren<Text>().text = FlagSprite[AnsIndex].name;
                Options[i].name = FlagSprite[AnsIndex].name;
            }

        } 
    }



    public void SetFlagOptions(int Index)
    {

        if(Index < FlagSprite.Length)
        {
            Answer = FlagSprite[Index].name;
            FlagImage.sprite = FlagSprite[Index];
            SetWordSet(Index);
        }


    }


    public void CheckAnswer(int BtnIndex)
    {
        count++;

        if (count <= FlagSprite.Length)
        {

            Button button = Options[BtnIndex];
            string Choice = button.name;
            resultGO.SetActive(true);

            if (GameList.Count != 0)
            GameIndex = GetUniqueRandomGame();

            total += 1;
            ReloadListCountries();


            if (Choice == Answer)
            {
                resultImage.sprite = result[0];
                correct += 1;
                streakCounter += 1;
                Score += 1;
                correct_Counter += 1;
            }
            else
            {
                resultImage.sprite = result[1];
                streakCounter = 0;
            }


            StartCoroutine(DoFade(ResultCanvasGroup));


            if (streakCounter == 5)
            {
                streakGO.SetActive(true);
                streakText.text = "+5   Streak";
                Score += 5;
                StartCoroutine(DoFade(StreakCanvasGroup));
            }
            else
            if (streakCounter == 10)
            {
                streakGO.SetActive(true);
                streakText.text = "+10   Streak \nGood Job!";
                Score += 10;
                StartCoroutine(DoFade(StreakCanvasGroup));
            }
            else
            if (streakCounter == 20)
            {
                streakGO.SetActive(true);
                streakText.text = "+20   Streak \nAmazing!";
                Score += 20;
                StartCoroutine(DoFade(StreakCanvasGroup));
            }
            else
            if (streakCounter == 30)
            {
                streakGO.SetActive(true);
                streakText.text = "+30   Streak \nExceptional!";
                Score += 30;
                StartCoroutine(DoFade(StreakCanvasGroup));
            }
            else
            if (streakCounter == 50)
            {
                streakGO.SetActive(true);
                streakText.text = "+50   Streak \nThat's Crazy!";
                Score += 50;
                StartCoroutine(DoFade(StreakCanvasGroup));
            }
            else 
            if (streakCounter == 100)
            {
                streakGO.SetActive(true);
                streakText.text = "+100   Bonus! \nA perfect record";
                Score += 100;
                StartCoroutine(DoFade(StreakCanvasGroup));
            }

    

            StartCoroutine(Next(ResultCanvasGroup));
        }
      

    }


    IEnumerator DoFade(CanvasGroup canvasGroup)
    {        
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * 1.8f;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
        
    }

    IEnumerator Next(CanvasGroup canvasGroup)
    {
        yield return new WaitForSeconds(1.8f);
        canvasGroup.alpha = 0;
        resultGO.SetActive(false);

        StreakCanvasGroup.alpha = 0;
        streakGO.SetActive(false);

        SetFlagOptions(GameIndex);

        if (count >= FlagSprite.Length)
        {
            wrong = count - correct_Counter;

            //Setting Comments based on score
            if (wrong == 0)
                Nextcomment.text = "Perfect Score!";
            else
            if (wrong <= 5)
                Nextcomment.text = "Excellent Job!";
            else
                if (wrong > 5 && wrong <= 10)
                Nextcomment.text = "Good Work!";
            else
                if (wrong > 10 && wrong <= 20)
                Nextcomment.text = "Needs Some Work...";
            else
                Nextcomment.text = "Poorly Done!";

            TimeUp = false;
            if(correct_Counter > 2)
            {
                passOrfail.sprite = PassOrFail[0];
                    if (level == "1")
                    {
                        level = "2";
                        FlagSprite = Level2;
                        nextTime = 50;
                    }
                    else
               if (level == "2")
                    {
                        level = "3";
                        FlagSprite = Level3;
                        nextTime = 50;
                    }
                    else
               if (level == "3")
                    {
                        level = "4";
                        FlagSprite = Level4;
                        nextTime = 45;
                    }
                    else
               if (level == "4")
                    {
                        level = "5";
                        FlagSprite = Level5;
                        nextTime = 45;
                    }
                    else
               if (level == "5")
                    {
                        level = "6";
                        FlagSprite = Level6;
                        nextTime = 40;
                    }
                    else
               if (level == "6")
                    {
                        level = "7";
                        FlagSprite = Level7;
                        nextTime = 45;
                    }
                    else
               if (level == "7")
                    {
                        level = "8";
                        FlagSprite = Level8;
                        nextTime = 40;
                    }
                    else
               if (level == "8")
                    {
                        level = "9";
                        FlagSprite = Level9;
                        nextTime = 40;
                    }
                    else
               if (level == "9")
                    {
                        level = "10";
                        FlagSprite = Level10;
                        FlagSprite = Level9;
                        nextTime = 35;
                    }
                    else
               if (level == "10")
                    {
                        level = "11";
                        FlagSprite = Level11;
                        nextTime = 35;
                    }
                    else
               if (level == "11")
                    {
                        level = "12";
                        FlagSprite = Level12;
                        nextTime = 35;
                    }
                    else
               if (level == "12")
                    {
                        level = "13";
                        FlagSprite = Level13;
                        nextTime = 35;
                    }
                    else
               if (level == "13")
                    {
                        level = "14";
                        FlagSprite = Level14;
                        nextTime = 30;
                    }
                    else
               if (level == "14")
                    {
                        level = "15";
                        FlagSprite = Level15;
                        nextTime = 30;
                    }
                    else
               if (level == "15")
                        level = "Done";


                InitScore = Score;
                InitQuest = total;
                InitCorrect = correct;
                InitWrong = wrong;
                Init_Total = total;
                InitLevel = FlagSprite;

                //Store values in playerprefs
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.SetInt("Total", total);
                PlayerPrefs.SetInt("Wrong", wrong);
                PlayerPrefs.SetInt("Correct", correct);
                PlayerPrefs.SetFloat("nextTime", nextTime);
                PlayerPrefs.SetString("Level", level);

            }
            else
            {
                passOrfail.sprite = PassOrFail[1];
            }
           


            if (level!="Done")
            {
                StopTimer();
                count = 0;
                if (correct_Counter >=0 && correct_Counter<=2)
                {
                    Finish();
                    comment.text = "You got too many wrong";
                    TimeUp = true;
                }
                else
                {
                    ReloadCountryNames();
                    ReloadListCountries();
                    ReloadListGame();
                    GameIndex = GetUniqueRandomGame();
                    SetFlagOptions(GameIndex);
                    DifficultyText.text = "Level " + level;
                    NextPanel.SetActive(true);
                    int IntLvl = int.Parse(level) - 1;
                    nextLevelTxt.text = "You've completed level " + IntLvl.ToString();
                    questionsTxt.text = "Questions: " + FlagSprite.Length.ToString();
                    timeTxt.text = "Time: " + nextTime.ToString() + " seconds";
                }          
            }


            if (level == "Done")
            {
                GameOver();


                //Posting score to database
                // PostToDatabase();
            }

            correct_Counter = 0;

        }

        
    }

    public void Finish()
    {
        retryBtn.SetActive(false);


        if (!TimeUp)
        {
            comment.text = "Paused";
        }
        
        if(InPlay)
        {

            if (FinishPanel.activeInHierarchy && level != "Done" && !TimeUp )
            {
                if(!NextPanel.activeInHierarchy)
                ResumeTimer();

                FinishPanel.SetActive(false);
                GamePanel.SetActive(true);
            }
            else
            {
                StopTimer();
                FinishPanel.SetActive(true);
                GamePanel.SetActive(false);
                correctText.text = "Correct Answers: " + correct.ToString();
                wrong = total - correct;
                wrongText.text = "Wrong Answers: " + wrong.ToString();
                totalText.text = "Total Questions: " + total.ToString();
                YourScore.text = "Your Overall Score: " + Score.ToString();
            }

            if (level != "Done" && !NextPanel.activeInHierarchy)
                retryBtn.SetActive(true);

        }
        else
        {
            if (FinishPanel.activeInHierarchy && !TimeUp )
            {
                
                FinishPanel.SetActive(false);
            }
            else
            {
                
                FinishPanel.SetActive(true);
            }


        }




    }

    // DATABASE
    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://wsis-world.firebaseio.com/" + Score.ToString() + ".json", user);
    }

    public void GetClassName()
    {
        RetrieveFromDatabase();
    }

    private void UpdateClassName()
    {
        comment.text = "Class: " + user.ClassName;
    }

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://wsis-world.firebaseio.com/" + Score.ToString() + ".json").Then(onResolved: response =>
        {
            user = response;
            UpdateClassName();
        });
        
    }

    void GameOver()
    {

        // Finish game panel
        Finish();


        //Setting Comments based on score
        if (wrong == 0)
            comment.text = "Amazing Job!";
        else
        if (wrong <= 5)
            comment.text = "Excellent Job!";
        else
            if (wrong > 5 && wrong <= 10)
            comment.text = "Good Work!";
        else
            if (wrong > 10 && wrong <= 20)
            comment.text = "Needs Some Work...";
        else
            comment.text = "Poorly Done!";

        TimeUp = false;
    }

    void UpdateTime()
    {
        timer = Time.time - startTime;
        countDown = nextTime - timer;
        timerText.text = TimeToString(countDown);
    }

    float StopTimer()
    {
        keepTiming = false;
        return timer;
    }

    void ResumeTimer()
    {
        keepTiming = true;
        startTime = Time.time - timer;
    }

    void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
    }

    public void NextLevel()
    {
        NextPanel.SetActive(false);
        StartTimer();    
    }

    public void Retry()
    {
        count = 0;
        FlagSprite = InitLevel;
        TimeUp = false;

        //Loading list values
        ReloadCountryNames();
        ReloadListGame();
        ReloadListCountries();

        //Choosing first flag
        GameIndex = GetUniqueRandomGame();
        SetFlagOptions(GameIndex);

        FinishPanel.SetActive(false);
        GamePanel.SetActive(true);
        streakCounter = 0;
        Score = Score - InitScore;
        correct = InitCorrect;
        total = Init_Total;
        wrong = InitWrong;

        wrongText.text = "Wrong Answers: " + wrong.ToString();
        totalText.text = "Total Questions: " + total.ToString();
        YourScore.text = "Your Overall Score: " + Score.ToString();
        StartTimer();

    }
}

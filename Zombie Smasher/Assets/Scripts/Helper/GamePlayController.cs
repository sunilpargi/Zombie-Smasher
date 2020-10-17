using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;
    public Transform[] lanes;
    public float min_ObstacleDelay = 10f, max_ObstacleDelay = 40f;
    private float halfGroundsize;
    private BaseController playerController;

   [SerializeField] private Text score_Text;
    private int zombie_Kill_Count;

    [SerializeField] private GameObject pause_Panel;
    [SerializeField] private GameObject gameOver_Panel;
    [SerializeField] private Text final_Score;
    void Awake()
    {
        MakeInstance();
    }
    private void Start()
    {
        halfGroundsize = GameObject.Find("GroundBlock Main").GetComponent<GroundBlock>().halfLength;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseController>();

        StartCoroutine(GenerateObstacle());

    }

    private void MakeInstance()
    {
       if(instance == null)
        {
            instance = this;
        }

       else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateObstacle()
    {
        float timer = UnityEngine.Random.Range(min_ObstacleDelay, max_ObstacleDelay / playerController.speed.z);
        yield return new WaitForSeconds(timer);

        CreateObstacles(playerController.gameObject.transform.position.z + halfGroundsize);

        StartCoroutine(GenerateObstacle());
    }

   void CreateObstacles(float zPos)
    {
        int r = UnityEngine.Random.Range(0, 10);

        if(r >= 0 && r > 7)
        {
            int obstacleLane = UnityEngine.Random.Range(0, lanes.Length);

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x, 0, zPos), UnityEngine.Random.Range(0, obstaclePrefabs.Length));

            int zombieLane = 0;

            if(obstacleLane  == 0)
            {
                zombieLane = UnityEngine.Random.Range(0, 2) == 1 ? 1 : 2;
            }
            else if(obstacleLane == 1)
            {
                zombieLane = UnityEngine.Random.Range(0, 2) == 1 ? 0 : 2;
            }
            else if (obstacleLane == 2)
            {
                zombieLane = UnityEngine.Random.Range(0, 2) == 1 ? 1 : 0;
            }

            AddZombie(new Vector3(lanes[zombieLane].transform.position.x, 0.15f, zPos));
        }
    }

    void AddObstacle(Vector3 position, int type)
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[type], position, Quaternion.identity);
        bool mirror = UnityEngine.Random.Range(0, 1) == 1;

        switch (type)
        {
            case 0:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 1:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -20 : 20, 0f);
                break;
            case 2:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -1 : 1, 0f);
                break;
            case 3:
                obstacle.transform.rotation = Quaternion.Euler(0f, mirror ? -170 : 170, 0f);
                break;
        }

        obstacle.transform.position = position;
    }

    void AddZombie(Vector3 pos)
    {
        int count = UnityEngine.Random.Range(0, 3) + 1;

        for(int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 0, UnityEngine.Random.Range(1f, 10f) * i);

            Instantiate(zombiePrefabs[UnityEngine.Random.Range(0, zombiePrefabs.Length)], pos + shift * i, Quaternion.identity);
        }
    }
   public void IncreaseScore()
    {
        zombie_Kill_Count++;
        score_Text.text = zombie_Kill_Count.ToString();
    }

    public void PauseGame()
    {
        pause_Panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pause_Panel.SetActive(false);
        Time.timeScale = 1;
    }

     public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver_Panel.SetActive(true);
        final_Score.text = "Killed:" + zombie_Kill_Count;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }
}

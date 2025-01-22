using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RacingGameManagert : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject car;
    public GameObject gasItemPrefab;
    public TextMeshProUGUI gasText;

    private float gas = 100f;
    [SerializeField] private float carSpeed = 5;
    private bool isGameRunning = false;
    void Start()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        Time.timeScale = 0f; //게임 정지 상태 
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        isGameRunning = true;
        Time.timeScale = 1f; //게임 시작 
        InvokeRepeating("SpawnGas",2f,3f);
    }
    void Update()
    {
        if (!isGameRunning) return;
        //자동차 이동
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        car.transform.Translate(movement * (carSpeed * Time.deltaTime));
        // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        // car.transform.Translate(movement * (carSpeed * Time.deltaTime));
         // float horizontal = Input.GetAxis("Horizontal"); // 좌우 입력
         // car.transform.Translate(Vector3.right * horizontal * carSpeed * Time.deltaTime);
         //
        //가스 
        gas -= Time.deltaTime * 10f;
        gasText.text = "Gas: "+Mathf.Max(0,Mathf.FloorToInt(gas)).ToString();
        if (gas <= 0)
        {
            EndGame();
        }

    }

    void SpawnGas()
    {
        float xPos = Random.Range(-2f, 2f);
        Vector3 spawnPos = new Vector3(xPos, car.transform.position.y + 4f, 0f);
        Instantiate(gasItemPrefab, spawnPos, Quaternion.identity);
        Debug.Log("가스 생성");
    }

    void EndGame()
    {
        isGameRunning = false;
        endPanel.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddGas(float amount)
    {
        gas = Mathf.Min(gas + amount, 100f); // 가스 최대 100 제한
        Debug.Log($"가스 증가: 현재 가스 = {gas}");
    }
}
// ============================================
// [LoadScene.cs]
// Role : 씬 관리 Load, 카메라 전환
// Input : 
// Output : 
// -ChangeScene랑 짝궁
// ============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LoadScene : MonoBehaviour
{

    public CinemachineVirtualCamera targetCamera;

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("IntroUI");
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameoverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void Outtro()
    {
        SceneManager.LoadScene("Outtro");
    }

    public void ChoosegMenu()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
    public void SettingMenu()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("IntroUI");
            ActivateCameraForPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage1");
            ActivateCameraForPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage2");
            ActivateCameraForPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage3");
            ActivateCameraForPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage4");
            ActivateCameraForPlayer();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage5");
            ActivateCameraForPlayer();

        }
        else if (Input.GetKeyDown(KeyCode.Keypad9)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Outtro");
            ActivateCameraForPlayer();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ActivateCameraForPlayer();
    }

    void ActivateCameraForPlayer()
    {
        // 가능하면 플레이어에게 태그 "Player"를 붙여 놓으세요
        GameObject playerGO = GameObject.FindWithTag("Player");
        Transform playerTransform = playerGO ? playerGO.transform : null;

        // 씬에 있는 모든 Virtual Camera를 찾아서 플레이어를 Follow/LookAt 하는 카메라의 우선순위를 올립니다
        var vcams = FindObjectsOfType<CinemachineVirtualCamera>();
        foreach (var cam in vcams)
        {
            if (playerTransform != null && (cam.Follow == playerTransform || cam.LookAt == playerTransform))
            {
                cam.Priority = 15; // 활성 카메라 우선순위
            }
            else
            {
                cam.Priority = 10; // 기본 우선순위
            }
        }

        // (선택) public으로 설정한 targetCamera가 있으면 안전하게 우선순위 설정
        if (targetCamera != null)
        {
            targetCamera.Priority = 15;
        }
    }
}

                
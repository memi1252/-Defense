using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheet : MonoBehaviour
{
    [SerializeField] private GameObject cheetUi;
    [SerializeField] private TextMeshProUGUI text;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        cheetUi.SetActive(false);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            foreach (var enemy in GameManager.Instance.EnemyList)
            {
                enemy.GetComponent<EnemyBase>().move = false;
            }
            cheetUi.SetActive(true);
            text.text = "all enemy stop";
            StartCoroutine(Hide());
        }else if(Input.GetKeyDown(KeyCode.F2))
        {
            GameManager.Instance.gold += 100;
            cheetUi.SetActive(true);
            text.text = "100 gold";
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            for (int i = GameManager.Instance.EnemyList.Count - 1; i >= 0; i--)
            {
                GameManager.Instance.EnemyList[i].GetComponent<EnemyBase>().goldgive = false;
                GameManager.Instance.EnemyList[i].GetComponent<EnemyBase>().Die();
            }
            GameManager.Instance.EnemyList.Clear();
            cheetUi.SetActive(true);
            text.text = "all enemy die";
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            for (int i = GameManager.Instance.EnemyList.Count-1; i >= 0; i--)
            {
                GameManager.Instance.EnemyList[i].GetComponent<EnemyBase>().Die();
            }
            GameManager.Instance.EnemyList.Clear();
            cheetUi.SetActive(true);
            text.text = "all enemy die + gold";
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            GameManager.Instance.EnemyList.Clear();
            //메인화면
            cheetUi.SetActive(true);
            text.text = "mainLobby";
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.stage2 = false;
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            GameManager.Instance.EnemyList.Clear();
            SceneManager.LoadScene("stage1");
            cheetUi.SetActive(true);
            text.text = "stage1";
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.stage2 = false;
            StartCoroutine(Hide());
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            GameManager.Instance.EnemyList.Clear();
            SceneManager.LoadScene("stage2");
            cheetUi.SetActive(true);
            GameManager.Instance.itemconut = 0;
            GameManager.Instance.stage2 = true;
            text.text = "stage2";
            StartCoroutine(Hide());
        }

        
    }

    

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(2f);
        cheetUi.SetActive(false);
    }
}

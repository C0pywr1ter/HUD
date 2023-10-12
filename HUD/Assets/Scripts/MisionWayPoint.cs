using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MisionWayPoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Text metr;

    public Vector3 offset;

    float musicLevel;
    public AudioSource audioSource;

    public  int hpAmount = 0;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public List<GameObject> healthList;
    public GameObject miniMap;
    public bool isMiniMapHiden = false;
    private void Start()
    {
        isMiniMapHiden = MainMenu.hideMiniMap;
        
        hpAmount = MainMenu.healthAmount;
        healthList = new List<GameObject>() { hp1, hp2, hp3 };
        ChangeDifficulty();
        HideMiniMap();
    }
    private void Update()
    {

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    SceneManager.LoadScene(0);
        //}
      


        musicLevel = MainMenu.musicLevelValue;
        audioSource.volume = musicLevel;


        float minX = img.GetPixelAdjustedRect().width / 2; //минимальный x - левая граница игры
        float maxX = Screen.width - minX;//максимальный x - правая граница игры

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minX;

        Vector2 pose = Camera.main.WorldToScreenPoint(target.position + offset); //wayPoint следует за целью
        if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            //если меньше 0, значит цель по оси ось z(forward) находится за спиной  
            //таргет за спиной?
        {
            if(pose.x < Screen.width / 2)
            {
                pose.x = maxX; //когда таргет за спиной, цель будет в правой части экрана
            }
            else
            {
                pose.x = minX; //таргет в левой части экрана
            }
        }

        pose.x = Mathf.Clamp(pose.x, minX, maxX); // Clamp делает границы значения
        pose.y = Mathf.Clamp(pose.y, minY, maxY);
        img.transform.position = pose;

        metr.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m"; //показываем дистанцию до цели

    }
     void ChangeDifficulty()
    {
        for (int i = 0; i < hpAmount; i++)
        {
            healthList[i].SetActive(false);

        }
        Debug.Log(hpAmount);
    }
     void HideMiniMap()
    {
        Debug.Log(isMiniMapHiden);
        if (isMiniMapHiden)
        {
            miniMap.SetActive(false);
        }
        else 
        {
            miniMap.SetActive(true);
        }
    }
    public void BackToMenu()
    {
       SceneManager.LoadScene(0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;//公共变量score初始为1000

    void Awake()//类被引用时，在start之前
    {
        //如果玩家的highscore存在，读取
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore", score);
        }
        PlayerPrefs.SetInt("HighScore", score);//不存在则写回
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();//获取当前文字
        gt.text = "High Score: " + score;//加上score

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);//更新score
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    
    public Text scoreGT;//创建Text
   
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");//找到ScoreCounter
        scoreGT = scoreGO.GetComponent<Text>();//文字输入scoreGT
        print(scoreGT.text);
        scoreGT.text = "0";//设为0
        print(scoreGT.text);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;//获取鼠标当前输入
        mousePos2D.z = -Camera.main.transform.position.z;//相机的-z位置
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);//转换成3d坐标
        Vector3 pos = this.transform.position;//获取当前物体位置
        pos.x = mousePos3D.x;//通过鼠标输入转换变更x轴
        this.transform.position = pos; 
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);//删去标签为Apple的碰撞物

            int score = int.Parse(scoreGT.text);//转text到int
            score += 100;//碰撞一次后加100
            scoreGT.text = score.ToString();//转int为string

            if(score > HighScore.score)
            {
                HighScore.score = score;
            }
        }

    }
    
}

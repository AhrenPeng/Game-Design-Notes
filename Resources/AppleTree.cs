using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;//速度
    public float leftAndRightEdge = 10f;//左右边缘
    public float chanceToChangeDirections = 0.1f;//中途改变方向的几率
    public float secondsBetweenAppleDrops = 1f;//产生苹果的间隔


    // Start is called before the first frame update
    void Start()
    {
        //每秒掉苹果
        Invoke("DropApple", 2f);//两秒后呼唤第一次dropapple
    }
        //掉苹果声明
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);//创建实例化表
        apple.transform.position = transform.position;//苹果的位置等于苹果树的位置
        Invoke("DropApple", secondsBetweenAppleDrops);//之后设定苹果掉落时间间隔
    }

    // Update is called once per frame
    void Update()
    {   //基础移动
        Vector3 pos = transform.position;//位置赋予物体当前位置
        pos.x += speed * Time.deltaTime;    //位置的x坐标随时间改变
        transform.position = pos;// 把改变后的坐标赋给物体当前位置

        //改变方向
        if (pos.x < -leftAndRightEdge)//如果位置x坐标小于左边缘
        {
            speed = Mathf.Abs(speed);//向右移动
        }
        else if (pos.x > leftAndRightEdge)//如果位置x坐标大于右边缘
        {
            speed = -Mathf.Abs(speed);//向左移动
        }
        /*  快的电脑400回一秒，慢的电脑30回一秒
            else if(Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
        */
    }
        void FixedUpdate()
        {   //令其根据时间改变，固定50次一秒
            if (Random.value < chanceToChangeDirections)
            {
                speed *= -1;
            }
        }
    
}

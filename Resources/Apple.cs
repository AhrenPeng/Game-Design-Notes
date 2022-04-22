using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;//最低高度
 
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < bottomY)//如果物体坐标Y小于最低高度
        {
            Destroy(this.gameObject);//摧毁这个物体

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();//调用函数删除所有苹果
        }

        
    }
}

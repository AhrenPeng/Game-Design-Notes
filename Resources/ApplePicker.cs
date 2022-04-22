using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;//设置一个篮子prefab
    public int numBaskets = 3;//篮子数量
    public float basketBottomY = -14f;//
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;//创建一个物体表

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();//定义一个新表
        for (int i = 0; i < numBaskets; i++)//对于每个篮子
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);//实例化篮子
            Vector3 pos = Vector3.zero;//创建一个三维零pos
            pos.y = basketBottomY + basketSpacingY * i;
            tBasketGO.transform.position = pos;//每个篮子高度比下个篮子高2
            basketList.Add(tBasketGO);//将生成的篮子加入篮子表内

        }
    }

        public void AppleDestroyed()
        {
            //找到所有标签为Apple的物体并摧毁
            GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tApple in tAppleArray)
            {
                Destroy(tApple);
            }

            int basketIndex = basketList.Count - 1;//建立索引
            GameObject tBasketGO = basketList[basketIndex];//等于从下往上建立的最后一个篮子
            basketList.RemoveAt(basketIndex);//移出表
            Destroy(tBasketGO);//删除篮子

            if (basketList.Count == 0)
            {
                SceneManager.LoadScene("sceneAppleTree");//重新开始场景
            }
        }



    }


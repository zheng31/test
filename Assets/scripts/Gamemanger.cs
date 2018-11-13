using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanger : MonoBehaviour
{

    public GameObject UIRoot = null;
    public GameObject PoolRoot = null;
    public GameObject DispRoot = null;

    private List<GameObject> ModelList = new List<GameObject>();
    private int CurrentPosition = 0; //目前model的位置

    void Start()
    {

        //scan UI 
        if (UIRoot != null)
        {
            int childCount = UIRoot.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GameObject child = UIRoot.transform.GetChild(i).gameObject;
                if (child.name.Equals("Buttonleft"))
                {
                    Button button = child.GetComponent<Button>();
                    button.onClick.AddListener(ButtonleftOnClick);
                }

                if (child.name.Equals("Buttonright"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(ButtonrightOnClick);
                }

                if (child.name.Equals("back"))
                {
                    (child.GetComponent<Button>())
                        .onClick
                        .AddListener(backOnClick);
                }
            }
        }


        //scan pool root ,put model into list
        if (PoolRoot != null)
        {
            int childCount = PoolRoot.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                ModelList.Add(PoolRoot.transform.GetChild(i).gameObject);
            }
        }

        Display();

    }
    private void Display()
    {
        foreach (GameObject g in ModelList)
        {
            g.transform.parent = PoolRoot.transform; //all reset
        }
        Debug.Log("cp = "+CurrentPosition);

        ModelList[CurrentPosition].transform.parent = DispRoot.transform;  //瞬移
        ModelList[CurrentPosition].transform.localPosition = Vector3.zero; //reset
    }
    public void ButtonleftOnClick()
    {
        Debug.Log("ButtonleftOnClick");

        CurrentPosition--;
        if (CurrentPosition < 0)
        {
            CurrentPosition = 0;
        }
        Display();
    }
    public void ButtonrightOnClick()
    {
        Debug.Log("ButtonrightOnClick");

        CurrentPosition++;
        if (CurrentPosition >= ModelList.Count)
        {
            CurrentPosition = ModelList.Count - 1;
        }
        Display();
    }

    public void backOnClick()
    {
        Debug.Log("backOnClick");
    }

}


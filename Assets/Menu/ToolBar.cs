using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBar : MonoBehaviour
{

    public GameObject selected_tower;

    public int tower1_price;
    GameObject tower1;

    public int tower2_price;
    GameObject tower2;

    // Start is called before the first frame update
    void Start()
    {
        tower1 = FindObjectOfType<Basic_Tower>().gameObject;
        tower2 = FindObjectOfType<Ice_Tower>().gameObject;
    }

    public void Buy_Tower1()
    {
        Buy(tower1, tower1_price);
    }

    public void Buy_Tower2()
    {
        Buy(tower2, tower2_price);
    }

    private void Buy(GameObject tower, int price)
    {
        Player p = FindObjectOfType<Player>();
        if (p.money >= price)
        {
            p.money -= price;
            selected_tower = tower;
        }
    }
}

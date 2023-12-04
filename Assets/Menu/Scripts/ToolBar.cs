using UnityEngine;

/// <summary>
/// Toolbar controller
/// </summary>
public class ToolBar : MonoBehaviour
{

    public GameObject selected_tower = null;

    public int tower1_price = 10;
    GameObject tower1;

    public int tower2_price = 15;
    GameObject tower2;

    Player p;
    // Start is called before the first frame update
    void Start()
    {
        tower1 = FindObjectOfType<BasicTower>().gameObject;
        tower2 = FindObjectOfType<IceTower>().gameObject;
        p = FindObjectOfType<Player>();
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
        
        if (p.money >= price && selected_tower == null)
        {
            p.money -= price;
            selected_tower = tower;
        }
    }
}
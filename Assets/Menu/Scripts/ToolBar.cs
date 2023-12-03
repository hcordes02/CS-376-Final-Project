using UnityEngine;

/// <summary>
/// Toolbar controller
/// </summary>
public class ToolBar : MonoBehaviour
{

    public GameObject selected_tower = null;

    public int tower1_price;
    GameObject tower1;

    public int tower2_price;
    GameObject tower2;

    // Start is called before the first frame update
    void Start()
    {
        tower1 = FindObjectOfType<BasicTower>().gameObject;
        tower2 = FindObjectOfType<IceTower>().gameObject;
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

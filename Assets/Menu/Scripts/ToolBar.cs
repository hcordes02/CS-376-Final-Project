using UnityEngine;

/// <summary>
/// Toolbar controller
/// </summary>
public class ToolBar : MonoBehaviour
{
    public int tower1 = 10;
    public int tower2 = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy_Tower1()
    {
        BuyItem(tower1);
    }

    public void Buy_Tower2()
    {
        BuyItem(tower2);
    }

    private void BuyItem(int price)
    {
        Player p = FindObjectOfType<Player>();
        if (p.money >= price)
        {
            p.money -= price;
        }
    }
}

using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int healthKits = 3;
    public int _healthKits
    {
        get
        {
            return healthKits;
        }
        set
        {
            healthKits = value;
        }
    }

}


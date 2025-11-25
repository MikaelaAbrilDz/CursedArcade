using UnityEngine;

public class ObjectOnGround : MonoBehaviour
{
    public string objectName;
    public int amount;

    // Constructor para crear el objeto fácilmente
    public ObjectOnGround(string name, int qty)
    {
        objectName = name;
        amount = qty;
    }
}

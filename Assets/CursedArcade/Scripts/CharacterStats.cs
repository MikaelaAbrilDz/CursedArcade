using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //STATS BÁSICAS DE CUALQUIER PERSONAJE
    private int life = 75;
    private int lifeMax = 100;
    private int speed = 1;
    private int attack = 1;

    public int _life
    {
        get
        {
            return life;
        }

        set
        {
            life = Mathf.Clamp(value, 0, lifeMax);

            if (life == 0)
            {
                //MORIR
            }

        }

    }

    public int _lifeMax
    {
        get
        {
            return lifeMax;
        }

        set
        {
            lifeMax = value;
        }
    }

    public int _attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int _speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int GetCurrentAttack()
    {
        Inventory inv = GetComponent<Inventory>();
        if (inv == null) return _attack;

        // Contar cuántos Punch hay en el inventario
        int punchCount = 0;
        foreach (var item in inv.items)
        {
            if (item != null && item.objectName == "Punch") // o por tipo, tag, etc.
            {
                punchCount++;
            }
        }

        // Multiplicador: 1 + (nPunch * multiplierPorPunch)
        float multiplierPerPunch = 0.2f; // DEBE coincidir con PunchEntity
        float totalMultiplier = 1f + punchCount * multiplierPerPunch;

        return Mathf.RoundToInt(_attack * totalMultiplier);
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int life = 75;
    private int lifeMax = 100;
    private int speed  = 1;
    private float attack = 1f;

    public int _life
    {
        get
        {
            return life;
        }

        set
        {
            life = Mathf.Clamp(value, -1, lifeMax);

            if (life == -1)
            {
                //MORIR
            }
            if(life < 100)
            {
              Debug.Log(life);
            }
            else
            {
              Debug.Log("ya tienes la vida al maximo");
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

    public float _attack
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

  
        public int baseAttack = 10;

        public int GetCurrentAttack()
        {
            Inventory inv = GetComponent<Inventory>();
            if (inv == null) return baseAttack;

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

            return Mathf.RoundToInt(baseAttack * totalMultiplier);
        }
    }




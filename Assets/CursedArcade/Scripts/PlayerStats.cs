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

}

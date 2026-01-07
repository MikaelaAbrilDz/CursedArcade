using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CambiarEscena()
    {
        SceneManager.LoadScene("MikaTests");
    }


}

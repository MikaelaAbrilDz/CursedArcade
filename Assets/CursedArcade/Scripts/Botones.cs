using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void CambiarEscena(string scene)
    {
        SceneManager.LoadScene(scene);
    }


}

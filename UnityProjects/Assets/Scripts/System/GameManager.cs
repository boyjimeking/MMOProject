using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public void OnPlayerDeath()
    {
        SceneManager.LoadScene("Main");
    }
}

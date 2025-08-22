using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> Утилита для кнопок UI: загрузка сцены по индексу. </summary>
public class SceneLoader : MonoBehaviour
{
    public void Load(int buildIndex) => SceneManager.LoadScene(buildIndex);
}
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        SceneLoader.LoadNextScene();
    }
}

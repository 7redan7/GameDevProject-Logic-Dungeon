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

        Debug.Log($"Player entrato in {name}, carico la scena successiva");
        SceneLoader.LoadNextScene();
    }
}

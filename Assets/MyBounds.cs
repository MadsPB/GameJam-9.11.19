
using UnityEngine;

public class MyBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.HandleLose();

    }
}

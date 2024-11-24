using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        winScreen.SetActive(true);
        Destroy(gameObject);
    }
}

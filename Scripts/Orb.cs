using UnityEngine;

public class Orb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoints(10);
            gameObject.SetActive(false);
        }
    }
}
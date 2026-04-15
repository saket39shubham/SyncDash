using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    public float lifeTime = 5f;

    void OnEnable()
    {
        Invoke(nameof(Disable), lifeTime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float smoothSpeed = 10f;

    private Vector3 targetPosition;

    void Update()
    {
        var state = SyncManager.Instance.GetState();

        if (state.HasValue)
        {
            targetPosition = state.Value.position;
        }

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * smoothSpeed
        );
    }
}
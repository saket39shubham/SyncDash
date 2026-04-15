using UnityEngine;

[System.Serializable]
public struct PlayerState
{
    public Vector3 position;
    public Vector3 velocity;
    public bool isJumping;
    public float timeStamp;
}
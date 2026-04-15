using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class SyncManager : MonoBehaviour
{
    public static SyncManager Instance;
    public Queue<PlayerState> stateQueue = new Queue<PlayerState>();

    public float delay = 0.2f;

    void Awake()
    {
        Instance = this;
    }

    public void SendState(PlayerState state)
    {
        stateQueue.Enqueue(state);
    }

    public PlayerState? GetState()
    {
        if (stateQueue.Count == 0) return null;

        if (Time.time - stateQueue.Peek().timeStamp >= delay)
        {
            return stateQueue.Dequeue();
        }

        return null;
    }
}
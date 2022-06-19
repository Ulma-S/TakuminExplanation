using Ulma;

public class MyShareData : SceneManager.ShareData
{
    public PlayerStatus Status { get; private set; }
    public UnityEngine.Vector3 SpawnPosition { get; private set; }

    public MyShareData(PlayerStatus status, UnityEngine.Vector3 spawnPos)
    {
        Status = status;
        SpawnPosition = spawnPos;
    }
}

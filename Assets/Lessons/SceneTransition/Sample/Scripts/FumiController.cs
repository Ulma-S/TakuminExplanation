using UnityEngine;

public class FumiController : MonoBehaviour
{
    public PlayerStatus Status { get; private set; }

    private void Start()
    {
        Status = new PlayerStatus(10, 0, false);
    }
}

using UnityEngine;
using Ulma;

public class FromSceneManager : MonoBehaviour
{
    private void Start()
    {
        var shareData = SceneManager.Instance.CurrentShareData as MyShareData;

        if (shareData != null)
        {
            Debug.Log(shareData.Status.HP);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var player = FindObjectOfType<FumiController>();
            SceneManager.Instance.LoadStage(StageType.Game, new MyShareData(player.Status, new Vector3(0, 0, 0)));
        }
    }
}

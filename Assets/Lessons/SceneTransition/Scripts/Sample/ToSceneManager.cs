using UnityEngine;
using Ulma;

public class ToSceneManager : MonoBehaviour
{
    private void Start()
    {
        var shareData = SceneManager.Instance.CurrentShareData as MyShareData;

        if (shareData != null)
        {
            Debug.Log(shareData.Message);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.Instance.LoadStage(StageType.Title, new MyShareData("Hello, FromScene!"));
        }
    }
}

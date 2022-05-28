using UnityEngine;
using Ulma;

public class MyShareData : SceneManager.ShareData
{
    public string Message { get; private set; }

    public MyShareData(string message)
    {
        Message = message;
    }
}


public class FromSceneManager : MonoBehaviour
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
            SceneManager.Instance.LoadStage(StageType.Game, new MyShareData("Hello, ToScene!"));
        }
    }
}

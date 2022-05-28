using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Ulma
{
    public static class RutimeInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadPermanentScene()
        {
            //常駐シーンがロードされていなければロードする.
            for (int i = 0; i < UnitySceneManager.sceneCount; i++)
            {
                if (UnitySceneManager.GetSceneAt(i).name == "Resident")
                {
                    break;
                }

                if (i == UnitySceneManager.sceneCount - 1)
                {
                    UnitySceneManager.LoadScene("Resident", UnityEngine.SceneManagement.LoadSceneMode.Additive);
                }
            }
        }
    }
}
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Ulma
{
    public static class RuntimeInitializer
    {
        private const string ResidentSceneName = "Resident";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void LoadPermanentScene()
        {
            //常駐シーンがロードされていなければロードする.
            for (int i = 0; i < UnitySceneManager.sceneCount; i++)
            {
                if (UnitySceneManager.GetSceneAt(i).name == ResidentSceneName)
                {
                    break;
                }

                if (i == UnitySceneManager.sceneCount - 1)
                {
                    UnitySceneManager.LoadScene(ResidentSceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                }
            }
        }
    }
}
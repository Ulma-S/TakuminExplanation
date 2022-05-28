using System.Collections.Generic;
using UnityEngine;

namespace Ulma
{
    public class SceneListProvider : MonoBehaviour
    {
        [System.Serializable]
        public class SceneSet
        {
            [Tooltip("�X�e�[�W�̎��")]
            public StageType StageType;

            [Tooltip("�X�e�[�W�ɑΉ�����V�[�����̃��X�g")]
            public List<string> SceneNameList;
        }

        private static SceneListProvider instance = null;
        public static SceneListProvider Instance {
            get {
                if (instance == null)
                {
                    instance = FindObjectOfType<SceneListProvider>();
                    if (instance == null)
                    {
                        throw new System.NullReferenceException();
                    }
                }
                return instance;
            }
        }

        [SerializeField]
        private List<SceneSet> _SceneSets;

        public IReadOnlyList<string> GetSceneNames(StageType stageType)
        {
            var sceneSet = _SceneSets.Find(set => set.StageType == stageType);
            if(sceneSet == null)
            {
                throw new System.NullReferenceException();
            }

            return sceneSet.SceneNameList.AsReadOnly();
        }
    }
}
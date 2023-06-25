using UnityEngine;

namespace Main
{
    public class SceneLoadAction : MonoBehaviour
    {
        public void LoadMain()
        {
            SceneLoader.Instance.LoadMain();
        }
        public void LoadVariant_1()
        {
            SceneLoader.Instance.LoadVariant_1();
        }
        public void LoadVariant_2()
        {
            SceneLoader.Instance.LoadVariant_2();
        }
        public void LoadVariant_3()
        {
            SceneLoader.Instance.LoadVariant_3();
        }
    }
}

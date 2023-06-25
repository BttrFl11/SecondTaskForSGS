using UnityEngine.SceneManagement;

namespace Main
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        private void Start()
        {
            LoadMain();
        }

        public void Load(int id)
        {
            SceneManager.LoadScene(id);
        }

        public void LoadMain()
        {
            Load((int)Scenes.Main);
        }

        public void LoadVariant_1()
        {
            Load((int)Scenes.Variant_1);
        }

        public void LoadVariant_2()
        {
            Load((int)Scenes.Variant_2);
        }

        public void LoadVariant_3()
        {
            Load((int)Scenes.Variant_3);
        }
    }
}
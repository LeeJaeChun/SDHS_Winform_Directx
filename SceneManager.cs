using System;
using System.Collections.Generic;
using System.Text;

namespace winformTest
{
    public class SceneManager
    {
        private static SceneManager instance = null;
        public IDictionary<int, Scene> SceneMap = null;
        private int ActiveIndex;

        public static SceneManager Get
        {
            get
            {
                if (instance == null) instance = new SceneManager();
                return instance;
            }
        }

        public void AddScene(Scene scene,int index)
        {
            if(!SceneMap.ContainsKey(index))
                SceneMap.Add(index, scene);
        }

        public void LoadScene(int index)
        {
            if (SceneMap.ContainsKey(index))
            {
                ActiveIndex = index;
                SceneMap[index].ActiveScene();
            }
        }

        public void Update()
        {
            SceneMap[ActiveIndex].Update();
        }

        public void Render()
        {
            SceneMap[ActiveIndex].Render();
        }
    }
}

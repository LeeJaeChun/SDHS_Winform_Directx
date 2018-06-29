using System.Collections.Generic;
using Microsoft.DirectX.Direct3D;

namespace winformTest
{
    public class ResourcesManager
    {
        private static ResourcesManager instance = null;
        private Dictionary<string, Texture> dicTexture = new Dictionary<string, Texture>();

        public static ResourcesManager Get
        { get { if (instance == null) instance = new ResourcesManager(); return instance; } }

        public Texture GetTexture(string path)
        {
            if (dicTexture.ContainsKey(path)) return dicTexture[path];

            Texture tex = TextureLoader.FromFile(GameManager.Get.device, path);
            dicTexture[path] = tex;
            return tex;
        }
    }
}

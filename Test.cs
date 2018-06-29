using System;
using System.Drawing;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace winformTest
{
    public class Test
    {
        private Texture tex;

        public void Init()
        {
            tex = TextureLoader.FromFile(GameManager.Get.device, "../Resources/player.png");
        }

        public void Render()
        {
            GameManager.Get.sprite.Draw(tex, new Vector3(), new Vector3(100, 100, 0), Color.White.ToArgb());
        }
    }
}

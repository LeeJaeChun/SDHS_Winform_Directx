using System.Drawing;
using Microsoft.DirectX;

namespace winformTest
{
    public class SpriteRender:BaseComponent
    {
        public string path = string.Empty;
        public Color color = Color.White;
        public Vector3 pivot = new Vector3();

        public override void Render()
        {
            GameManager.Get.sprite.Transform = transform.matrix;
            GameManager.Get.sprite.Draw(ResourcesManager.Get.GetTexture(path), pivot, new Vector3(), color.ToArgb());
        }
    }
}

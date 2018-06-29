using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace winformTest
{
    public class GameManager :IDisposable
    {
        private static GameManager instance = null;
        public Form1 form = null;
        public Device device = null;
        public PresentParameters presentParameters = null;
        public Sprite sprite = null;
        public Color clearColor = Color.Aquamarine;
        public GameObject gameObject;

        public static GameManager Get
        {
            get
            {
                if (instance == null) instance = new GameManager();
                return instance;
            }
        }

        public bool Init(Form1 mainForm)
        {
            form = mainForm;

            presentParameters = new PresentParameters();
            presentParameters.SwapEffect = SwapEffect.Discard;
            presentParameters.EnableAutoDepthStencil = true;
            presentParameters.AutoDepthStencilFormat = DepthFormat.D16;

            bool ret = InitGraphics();

            sprite = new Sprite(device);

            gameObject = new GameObject();
            var renderer = gameObject.AddComponent<SpriteRender>();
            renderer.path = "../Resources/player.png";
            renderer.pivot = new Vector3(0, 0, 0);
            gameObject.transform.position = new Vector3(10.0f, 10.0f, 0.0f);



            return ret;
        }

        private bool InitGraphics()
        {
            try
            {
                presentParameters.Windowed = true;
                presentParameters.FullScreenRefreshRateInHz = 0;
                presentParameters.PresentationInterval = PresentInterval.Default;
                CreateDevice();
            }
            catch (DirectXException ex)
            {
                MessageBox.Show(ex.ToString(), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void CreateDevice()
        {
            presentParameters.BackBufferHeight = 0;
            presentParameters.BackBufferWidth = 0;

            presentParameters.DeviceWindow = form;
            presentParameters.DeviceWindowHandle = form.Handle;

            presentParameters.BackBufferFormat = Format.Unknown;
            presentParameters.BackBufferCount = 0;

            presentParameters.MultiSample = MultiSampleType.None;
            presentParameters.MultiSampleQuality = 0;

            presentParameters.ForceNoMultiThreadedFlag = false;
            presentParameters.PresentFlag = PresentFlag.None;

            try
            {
                device = new Device(0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, presentParameters);
            }
            catch (DirectXException)
            {
                device = new Device(0, DeviceType.Reference, form.Handle, CreateFlags.HardwareVertexProcessing, presentParameters);
            }
        }

        public void Update()
        {
            gameObject.Update();
        }

        public void Render()
        {
            if (device == null) return;
            if (!device.CheckCooperativeLevel()) return;

            device.Clear(ClearFlags.Target, clearColor, 1.0f, 0);
            device.BeginScene();
            {
                sprite.Begin(SpriteFlags.AlphaBlend);
                gameObject.Render();
                sprite.End(); 
            }
            device.EndScene();
            device.Present();
        }

        public void Dispose()
        {
            sprite?.Dispose();
            device?.Dispose();
        }
    }
}

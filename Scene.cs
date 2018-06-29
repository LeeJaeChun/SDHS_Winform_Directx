using System;
using System.Collections.Generic;
using System.Text;

namespace winformTest
{
    abstract public class BaseScene
    {
        public GameObject parentObj;

        public virtual void ActiveScene()
        {
            Init();
        }

        public virtual void Init()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Render()
        {
        }
    }
}

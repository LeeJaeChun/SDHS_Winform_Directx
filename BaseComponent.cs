namespace winformTest
{
    public class BaseComponent
    {
        public GameObject gameObject { get; internal set; }
        public Transform transform => gameObject.transform;

        public virtual void Update() { }
        public virtual void Render() { }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}

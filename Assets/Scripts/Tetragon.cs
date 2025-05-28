using UnityEngine;

namespace Geometry
{
    public class Tetragon
    {
        protected float a;
        protected float b;
        protected float angle;

        public Tetragon(float a, float b, float angle)
        {
            this.a = a;
            this.b = b;
            this.angle = angle;
        }

        public virtual float CountPerimeter()
        {
            return 2 * (a + b);
        }

        public virtual float CountArea()
        {
            float angleRad = angle * Mathf.Deg2Rad;
            return a * b * Mathf.Sin(angleRad);
        }
    }

    public class ConvexTetragon : Tetragon
    {
        public ConvexTetragon(float a, float b, float angle) : base(a, b, angle) { }
    }

    public class Parallelogram : ConvexTetragon
    {
        public Parallelogram(float a, float b, float angle) : base(a, b, angle) { }

        public override float CountPerimeter()
        {
            return 2 * (a + b);
        }

        public override float CountArea()
        {
            float angleRad = angle * Mathf.Deg2Rad;
            return a * b * Mathf.Sin(angleRad);
        }
    }

    public class Rhombus : Parallelogram
    {
        public Rhombus(float a, float angle) : base(a, a, angle) { }

        public override float CountPerimeter()
        {
            return 4 * a;
        }

        public override float CountArea()
        {
            float angleRad = angle * Mathf.Deg2Rad;
            return a * a * Mathf.Sin(angleRad);
        }
    }

    public class Rectangle : Parallelogram
    {
        public Rectangle(float a, float b) : base(a, b, 90f) { }

        public override float CountArea()
        {
            return a * b;
        }
    }

    public class Square : Rectangle
    {
        public Square(float a) : base(a, a) { }

        public override float CountPerimeter()
        {
            return 4 * a;
        }

        public override float CountArea()
        {
            return a * a;
        }
    }

    public class TetragonTester : MonoBehaviour
    {
        void Start()
        {
            Tetragon tetragon = new Tetragon(3, 4, 60);
            Debug.Log($"Tetragon: P={tetragon.CountPerimeter()}, S={tetragon.CountArea()}");

            Parallelogram parallelogram = new Parallelogram(3, 4, 60);
            Debug.Log($"Parallelogram: P={parallelogram.CountPerimeter()}, S={parallelogram.CountArea()}");

            Rhombus rhombus = new Rhombus(5, 60);
            Debug.Log($"Rhombus: P={rhombus.CountPerimeter()}, S={rhombus.CountArea()}");

            Rectangle rectangle = new Rectangle(3, 4);
            Debug.Log($"Rectangle: P={rectangle.CountPerimeter()}, S={rectangle.CountArea()}");

            Square square = new Square(5);
            Debug.Log($"Square: P={square.CountPerimeter()}, S={square.CountArea()}");
        }
    }
}
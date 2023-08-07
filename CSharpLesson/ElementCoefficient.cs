namespace CSharpLesson
{
    public class ElementCoefficient
    {
        private float[,] _elementsCoefficient =
        {
        {1.0f, 1.65f, 0.8f, 0.6f },
        {0.3f, 1.0f,  0.8f, 1.8f },
        {0.5f, 1.6f,  1.0f, 0.8f },
        {0.9f, 1.1f,  0.4f, 1.0f }
        };

        public float GetElementCoefficient(Element attacking, Element defensive)
            => _elementsCoefficient[(int)attacking, (int)defensive];
    }

}

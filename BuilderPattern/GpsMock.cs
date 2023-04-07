namespace BuilderPattern
{
    internal class GpsMock : IGps
    {
        public GpsMock()
        {
        }

        public int steps;

        public void SetSteps(int steps)
        {
            this.steps = steps;
        }

        public int GetSteps()
        {
            return steps;
        }
    }
}
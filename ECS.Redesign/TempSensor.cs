using System;

namespace ECS.Redesign
{
    public interface ITempSensor
    {
        public int GetTemp();
        public bool RunSelfTest();
    }

    public class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;

        }
    }

   public class FakeTempSensor : ITempSensor
    {
        private int _gen;

        public int GetTemp()
        {
            return (_gen);
        }

        public void SetTemp(int gen)
        {
            _gen = gen;
        }

        public bool RunSelfTest()
        {
            return (true);
        }
    }
}

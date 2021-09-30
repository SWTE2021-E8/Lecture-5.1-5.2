using System;

namespace ECS.Redesign
{
    public interface IHeater
    {
        public bool IsHeating();
        public void TurnOn();
        public void TurnOff();
        public bool RunSelfTest();
    }

    public class Heater:IHeater
    {
        public bool heating { private set; get; } = false;
        public void TurnOn()
        {
            heating = true;
            System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            System.Console.WriteLine("Heater is off");
            heating = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
        public bool IsHeating()
        {
            return heating;
        }
    }
    public class fakeHeater : IHeater
    {
        public bool heating { private set; get; }

        public fakeHeater(bool heatingcon)
        {
            heating = heatingcon;
        }
        public bool IsHeating()
        {
            return heating;
        }

        public void TurnOn()
        {
            heating = true;
        }

        public void TurnOff()
        {
            heating = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}

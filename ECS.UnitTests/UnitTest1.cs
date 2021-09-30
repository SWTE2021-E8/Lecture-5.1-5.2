using NUnit.Framework;
using ECS.Redesign;
using Microsoft.VisualBasic;
using NUnit.Framework.Constraints;
using NSubstitute;

namespace ECS.UnitTests
{
    public class Tests
    {
        ITempSensor fakeTempSensor;
        IHeater fakeHeater;
        ECSystem control;

        [SetUp]
        public void Setup()
        {
            fakeHeater = Substitute.For<Heater>();
            fakeTempSensor = Substitute.For<ITempSensor>();
            control = new ECSystem(23, fakeTempSensor, fakeHeater);
        }

        //Heater Tests
        [Test]
        public void ESC_overthreshold()
        {
            fakeTempSensor.GetTemp().Returns(24);

            control.Regulate();
            Assert.IsFalse(fakeHeater.IsHeating());
        }

        [Test]
        public void ESC_underthreshold()
        {
            var tempSensor = Substitute.For<ITempSensor>();
            tempSensor.GetTemp().Returns(23);

            control.Regulate();
            Assert.IsTrue(fakeHeater.IsHeating());
        }

        [Test]
        public void ESC_Atthreshold()
        {
            var tempSensor = Substitute.For<ITempSensor>();
            tempSensor.GetTemp().Returns(23);

            control.Regulate();
            Assert.IsTrue(fakeHeater.IsHeating());
        }


        [Test]
        public void ESC_changetreshold()
        {
            control.SetThreshold(25);
            Assert.AreEqual(25, control.GetThreshold());

        }
    }
}
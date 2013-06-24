using System.Linq;

using ConcreteWall;

using Glass;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SysAssembly = System.Reflection.Assembly;

namespace GlassCrashTest
{
    [TestClass]
    public class GlassApiTest
    {
        private Assembly assembly;
        private SysAssembly sysAssembly;

        [TestInitialize]
        public void Initialize()
        {
            sysAssembly = SysAssembly.Load("ConcreteWall");
            assembly = new Assembly(sysAssembly);
        }

        [TestMethod]
        public void TestLinqApi()
        {
            var mscorlibAssembly = new Assembly(SysAssembly.GetAssembly(typeof (string)));
            var typesInMscorlib = from Type t in mscorlibAssembly.Types
                                  orderby t.Name
                                  where !t.IsStatic
                                  select t;
            var b = from t in typesInMscorlib
                    where t.Name.StartsWith("_")
                    select t.Name;
            Assert.IsTrue(typesInMscorlib.Contains(new Type(typeof (string))));

        }

        [TestMethod]
        public void ShouldCheckIfATypeIsStatic()
        {
            var someStaticClass = new Type(typeof (SomeStaticClass));
            var enumerable = assembly.Types.Where(type => type.IsStatic);
            Assert.IsTrue(enumerable.Contains(someStaticClass));
        }
    }
}

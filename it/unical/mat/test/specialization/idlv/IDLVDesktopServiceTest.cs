using Microsoft.VisualStudio.TestTools.UnitTesting;
using it.unical.mat.embasp.@base;
using it.unical.mat.embasp.languages.datalog;
using it.unical.mat.embasp.platforms.desktop;
using System;
using System.Text;
using it.unical.mat.embasp.specializations.idlv.desktop;
using it.unical.mat.embasp.specializations.idlv;
using it.unical.mat.test.specialization.idlv;

namespace it.unical.mat.test
{
    [TestClass]
    public class IDLVDesktopServiceTest
    {

        [TestMethod]
        public void TransitiveClosureTest()
        {
            try
            {
                DesktopHandler handler = new DesktopHandler(new IDLVDesktopService(GetPath()));

                DatalogMapper.Instance.RegisterClass(typeof(UnweightedPath));

                InputProgram input = new DatalogInputProgram();
                input.AddObjectInput(new UnweightedEdge(1,2));
                input.AddObjectInput(new UnweightedEdge(2,3));
                input.AddObjectInput(new UnweightedEdge(2,4));
                input.AddObjectInput(new UnweightedEdge(3,5));
                input.AddObjectInput(new UnweightedEdge(3,6));    

                input.AddProgram("path(X,Y) :- edge(X,Y).");
                input.AddProgram("path(X,Y) :- path(X,Z), path(Z,Y).");

                handler.AddProgram(input);

                IDLVMinimalModels minimalModels = (IDLVMinimalModels)handler.StartSync();

                Assert.IsNotNull(minimalModels);
                Assert.IsTrue(minimalModels.Minimalmodels.Count == 1);
                Assert.IsTrue(minimalModels.ErrorsString == "", "Found error:\n" + minimalModels.ErrorsString);

                foreach (MinimalModel m in minimalModels.Minimalmodels)
                {
                    foreach (object a in m.Atoms)
                    {
                        if (typeof(UnweightedPath).IsInstanceOfType(a))
                        {
                            Console.WriteLine(a);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Exception " + e.Message);
            }
        }

        
        public string GetPath()
        {

            string OS = Environment.OSVersion.ToString();

            StringBuilder path = new StringBuilder();

           
            path.Append("C:\\Users\\Giorgio\\Desktop\\");

            if (OS.IndexOf("win", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                if (System.Environment.Is64BitOperatingSystem)
                    path.Append("idlv.win.64");
                else
                    path.Append("idlv.win.32");
            }
            else if (OS.IndexOf("nux", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                if (System.Environment.Is64BitOperatingSystem)
                    path.Append("idlv.linux.64");
                else
                    path.Append("idlv.linux.32");
            }
            else if (OS.IndexOf("mac", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                path.Append("idlv.mac");
            }

            return path.ToString();

        }

    }

}
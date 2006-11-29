using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using libsecondlife;
using libsecondlife.Packets;

namespace libsecondlife.TestClient
{
    public class LoadCommand: Command
    {
		public LoadCommand()
		{
			Name = "load";
			Description = "Loads commands from a dll. (Usage: load AssemblyNameWithoutExtension)";
		}

		public override string Execute(SecondLife Client, string[] args, LLUUID fromAgentID)
		{
			if (args.Length < 1)
				return "Usage: load AssemblyNameWithoutExtension";

			string filename = AppDomain.CurrentDomain.BaseDirectory + args[0] + ".dll";
			TestClient.RegisterAllCommands(Assembly.LoadFile(filename));
            return "Assembly " + filename + " loaded.";
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Finiox.DeveloperConsole.Commands
{
    [CreateAssetMenu(fileName = "cmd_help", menuName = "DeveloperConsole/HelpCommand")]
    public class HelpCommand : ConsoleCommand
    {
        public override CommandResponse Process(string[] args)
        {
            if (args.Length > 1)
            {
                return Fail("Too many arguments");
            }

            if (args.Length == 0)
            {
                return Fail($"Type `{CommandUsage}`");
            }

            string commandWord = args[0];

            var command = DeveloperConsole.Instance.ActiveCommands.FirstOrDefault(i => i.CommandWord.Equals(commandWord, StringComparison.OrdinalIgnoreCase));

            if (command == null)
            {
                return Fail("Command not found");
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Name: {command.CommandName}");
            builder.AppendLine($"Description: {command.CommandDescription}");
            builder.AppendLine($"Usage: `{command.CommandUsage}`");

            return Succes(builder.ToString());
        }
    }
}

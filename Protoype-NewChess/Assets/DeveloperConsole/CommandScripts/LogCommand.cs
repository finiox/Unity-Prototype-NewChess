using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Finiox.DeveloperConsole.Commands
{
    [CreateAssetMenu(fileName = "cmd_log", menuName = "DeveloperConsole/LogCommand")]
    public class LogCommand : ConsoleCommand
    {
        public override CommandResponse Process(string[] args)
        {
            string message = string.Join(" ", args);

            return Succes(message);
        }
    }
}

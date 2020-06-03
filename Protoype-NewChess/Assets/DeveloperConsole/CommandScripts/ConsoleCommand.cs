using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Finiox.DeveloperConsole.Commands
{
    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField] string commandName = default;
        [SerializeField] string commandWord = default;
        [SerializeField] string commandDescription = default;
        [SerializeField] string commandUsage = default;

        public string CommandName => commandName;

        public string CommandWord => commandWord;

        public string CommandDescription => commandDescription;

        public string CommandUsage => commandUsage;

        public abstract CommandResponse Process(string[] args);


        protected CommandResponse Succes(string message = "")
        {
            return new CommandResponse(true, message);
        }

        protected CommandResponse Fail(string message)
        {
            return new CommandResponse(false, message);
        }
    }
}

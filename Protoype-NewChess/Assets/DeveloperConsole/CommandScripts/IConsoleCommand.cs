using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finiox.DeveloperConsole.Commands
{
    public interface IConsoleCommand
    {
        string CommandName { get; }

        string CommandWord { get; }

        string CommandDescription { get; }

        string CommandUsage { get; }

        CommandResponse Process(string[] args);

    }
}

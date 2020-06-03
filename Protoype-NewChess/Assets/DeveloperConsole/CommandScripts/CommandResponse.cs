using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finiox.DeveloperConsole.Commands
{
    public class CommandResponse
    {
        public CommandResponse(bool succeeded, string message = "")
        {
            this.Message = message;
            this.Succeeded = succeeded;
        }

        public string Message { get; }

        public bool Succeeded { get; }
    }
}

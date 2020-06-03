using Finiox.DeveloperConsole.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Finiox.DeveloperConsole
{
    public class DeveloperConsole : MonoBehaviour
    {
        [Header("UI Components")]
        [SerializeField] Canvas consoleCanvas = default;
        [SerializeField] ScrollRect scrollView = default;
        [SerializeField] Text consoleText = default;
        [SerializeField] Text inputText = default;
        [SerializeField] InputField consoleInput = default;

        [Header("Commands")]
        [SerializeField] List<ConsoleCommand> commands = new List<ConsoleCommand>();

        public List<ConsoleCommand> ActiveCommands => commands;
        public bool IsVisible { get => consoleCanvas.gameObject.activeInHierarchy; }

        DeveloperControls controls;

        //
        // END UNITY COMPONENTS
        //

        public static DeveloperConsole Instance { get; private set; }

        void Awake()
        {
            controls = new DeveloperControls();

            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void OnEnable() {
            if (Debug.isDebugBuild)
            {
                controls.DeveloperConsole.Enable();
            }
        }

        void OnDisable() => controls.DeveloperConsole.Disable();

        void Start()
        {
            if (consoleCanvas)
            {
                CloseWindow();
            }

            controls.DeveloperConsole.Toggle.performed += (context) => ToggleWindowVisibility();
            controls.DeveloperConsole.Enter.performed += (context) => OnInputEnter();
        }

        public void OpenWindow()
        {
            if (!IsVisible)
                ToggleWindowVisibility();
        }

        public void CloseWindow()
        {
            if (IsVisible)
                ToggleWindowVisibility();
        }

        public void ToggleWindowVisibility()
        {
            consoleCanvas.gameObject.SetActive(!IsVisible);
        }

        public void OnInputEnter()
        {
            if (!IsVisible) return;

            string input = inputText.text;

            WriteToConsole($"> {input}", ConsoleColor.Yellow);
            ProcessCommandRaw(input);

            consoleInput.Select();
            consoleInput.ActivateInputField();
        }

        //
        // END UNITY METHODS
        //

        void WriteToConsole(string message)
        {
            WriteToConsole(message, ConsoleColor.White);
        }

        void WriteToConsole(string message, string color)
        {
            consoleText.text += $"<color={color}>{message}</color>\n";
            scrollView.verticalNormalizedPosition = 0f;
        }

        public void ProcessCommandRaw(string rawInput)
        {
            try
            {
                if (rawInput.Contains(" "))
                {
                    string[] splitInput = rawInput.Split(' ');

                    string command = splitInput[0];
                    string[] args;

                    if (splitInput.Length > 1)
                    {
                        args = splitInput.Skip(1).ToArray();
                    }
                    else
                    {
                        args = new string[0];
                    }

                    ProcessCommand(command, args);
                }
                else
                {
                    ProcessCommand(rawInput, new string[0]);
                }
            }
            catch (Exception)
            {
                WriteToConsole("Error while executing the command", ConsoleColor.Red);
            }
            finally
            {
                consoleInput.text = string.Empty;
            }
        }

        public void ProcessCommand(string commandWord, params string[] args)
        {
            IConsoleCommand command = commands.FirstOrDefault(i => i.CommandWord.Equals(commandWord, StringComparison.OrdinalIgnoreCase));

            if (command != null)
            {
                CommandResponse response = command.Process(args);

                if (!string.IsNullOrWhiteSpace(response.Message))
                {
                    string color = response.Succeeded ? ConsoleColor.White : ConsoleColor.Red;

                    WriteToConsole(response.Message, color);
                }
            }
            else
            {
                // TODO: Give suggestions?
                WriteToConsole("Command not found", ConsoleColor.Red);
            }
        }

        //
        // END OF METHODS
        //

        class ConsoleColor
        {
            public static readonly string White = "white";
            public static readonly string Red = "red";
            public static readonly string Yellow = "Yellow";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedConsoleMenu
{
    class UserInterface
    {

        //Class for setting the options
        private class Options {
            //Properties
            public string [] Choices { get; set; }

            public void MainMenu() {
                Choices = new string [] {"BASE", "Start Game", "Options", "Exit"};
            }
        }

        private Options opt = new Options();


        /// <summary>
        /// Output for outputting information from one place in case the output is changed later.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="newLine"></param>
        public void Output(string value, bool newLine = true) {
            if (newLine)
                Console.WriteLine(value);
            else
                Console.Write(value);
        }

        /// <summary>
        /// Input for taking in information from one place in case teh input is changed later.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="newLine"></param>
        public string Input(string message, bool newLine = false) {
            if(newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);

            return Console.ReadLine();
        }

        //Displays the main menu from the opt variable.
        public void DisplayMainMenu() {
            opt.MainMenu(); //Sets the choices to main menu choices.
            int totalOptions = opt.Choices.Length-1; //Gets total options.
            int currentOption = 1; //Sets current position.

            //O(N^2) for this here, but it helps with interfacing the options.
            while (currentOption != -3) { //For repeating.
                //For parsing out the menu options onto the screen
                for (int i = 1; i < opt.Choices.Length; i++) {
                    if (currentOption == i)
                        HighlightOption(opt.Choices[i]); //Call Method
                    else
                        Output(opt.Choices[i]);
                }

                currentOption = KeyListener(Console.ReadKey(), currentOption, totalOptions);
                
            }
        }

        /// <summary>
        /// Highlights the selected item.
        /// </summary>
        /// <param name="option"></param>
        private void HighlightOption(string option) {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Output(option);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Listens for a keystroke then delegates what the user is doing. If the user presses 'W' then the 
        /// method substracts from nextOption suggesting a move up the list. If 'S' then the method adds to
        /// nextOption suggesting a move down the list.  Checks to see if the enter key is pressed and submits
        /// a -1.  Also checks to see if the nextOption variable is out of the bounds set by the max and zero, and 
        /// resets the variable accordingly.
        /// </summary>
        /// <param name="keyStroke"></param>
        /// <param name="currentOption"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int KeyListener(ConsoleKeyInfo keyStroke, int currentOption, int max) {
            Console.Clear(); //Clears Console Immediately.
            int nextOption = currentOption;

            //Checking for certain keystroke.
            if (keyStroke.Key == ConsoleKey.W || keyStroke.Key == ConsoleKey.UpArrow)
                nextOption -= 1;
            else if (keyStroke.Key == ConsoleKey.S || keyStroke.Key == ConsoleKey.DownArrow)
                nextOption += 1;
            //Enter condition - Returns the negative of the currentPosition for further event handling.
            else if (keyStroke.Key == ConsoleKey.Enter)
                return currentOption * -1;

            //Checking if nextOption is out of bounds.
            if (nextOption < 1)
                nextOption = max;
            else if (nextOption > max)
                nextOption = 1;

            //Returning nextOption.
            return nextOption;


        }
    }
}

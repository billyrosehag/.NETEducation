using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace NetProgrammeringsTest
{
    class Program
    {
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;
        static void Main(string[] args)
        {
            Console.ForegroundColor = DefaultColor;

            Intro();//The introduction to the program starts
        }

        //Intro to the program/game
        static void Intro()
        {
            Console.Clear();
   
            // Stores the different options presented to the player
            string[] options = new string[] { "1.  Print out 'Hello World'", "2.  Ask about your info", "3.  Change text color", "4.  Print out today's date",
            "5.  Take two values, and return the one with the highest value","6.  The Guessing Game","7.  Input string, and store in txt.file", "8.  Retrive txt.file created in option 7",
            "9.  Give a number and retrive square root, power of 2 and power of 10","10. Multiplication table 1-10","11. Creates a random array, and another that presents the values from low to high",
            "12. Asks for a word, then checks if that word is a palindrome","13. Asks for a low and high number, and then prints out all numbers between those two values",
            "14. Asks for a set of values, than checks which are even and which are odd","15. Asks for a set of values, then adds them together","16. Player goes on a quest, and is tasked to name the hero and the villain"
            };

            Console.WriteLine("------------------------------------BILLYS-PROGRAM---------------------------------------\n\n");
            Console.WriteLine("-------Welcome to my program. Below you will find a selection of things you can do-------\n\n");

            //Presents the options to the player           
            foreach (string option in options)
            {
                Console.WriteLine(option);
                Thread.Sleep(50);
            }
            //0 hardcoded since it will never change!
            Console.Write("0.  Exit Program"+
                           "\n\n---------Choose program by inputting the corresponding number and pressing Enter-----------\n" +
                "\nWhat program would you like to run: ");

            //Player choice
            int playerChoice = CheckIfOperatorIsInt();

            Console.WriteLine("\n\n\n\n-----------------------------------LOADING-------------------------------------\n\n\n\n");
            Thread.Sleep(500);
            Console.Clear();
            //Checks player answer
            switch (playerChoice)
            {
                case 1:
                    GetHello();
                    break;
                case 2:
                    PlayerInfo();
                    break;
                case 3:
                    PlayerColor();
                    break;
                case 4:
                    PlayerDate();
                    break;
                case 5:
                    PlayerBiggestNumber();
                    break;
                case 6:
                    PlayerRandomNumber();
                    break;
                case 7:
                    PlayerRetriveFile();
                    break;
                case 8:
                    PlayerSaveFile();
                    break;
                case 9:
                    PlayerValues();
                    break;
                case 10:
                    PlayerMultiTable();
                    break;
                case 11:
                    PlayerArray();
                    break;
                case 12:
                    PlayerPalindrome();
                    break;
                case 13:
                    PlayerNumberRange();
                    break;
                case 14:
                    PlayerOddEven();
                    break;
                case 15:
                    PlayerAddNumbers();
                    break;
                case 16:
                    PlayerQuest();
                    break;
                case 0:
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("invalid number. Returning to main menu.");
                    Thread.Sleep(1000);
                    Intro();
                    break;


            }
                               
        }

        //1 Prints out hello
        static void GetHello()
        {
            Console.WriteLine("####Hello World####\n\nPress enter to continue.");
            Console.ReadLine();

            PlayerChoose();

            GetHello();
        }

        //2 Ask for info
        static void PlayerInfo()
        {
            // Gets player first name
            Console.Write("####PLAYER INFO####\n\nI'd like to get yo know you better. \nWhat is your first name: ");
            string firstName = RemoveWhiteSpaces();

            // Gets player last name
            Console.Write("I see. What is your last name: ");
            string lastName = RemoveWhiteSpaces();

            // Gets player age 
            Console.Write("Great. Lastly, what is your current age: ");
            double age = CheckIfOperatorIsDouble();

            //Prints it out to the player
            Console.WriteLine("\n\nHello {0} {1}. You current age is {2}", firstName, lastName, age);

            PlayerChoose();
            PlayerInfo();   
        }

        //3 Can change color between red and white
        static void PlayerColor()
        {

            Console.Write("####COLOR CHANGE####\n\nWould you like to change the text color?" +
                "\nYes/No?: ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")//Player wants to change color
            {
                if (Console.ForegroundColor == ConsoleColor.White)//Checks current forground color
                {
                    TextColor("5");
                }
                else
                {
                    TextColor("4");
                }
                Console.WriteLine("The textcolor has been changed to " + Console.ForegroundColor);
            }
            else if (answer == "no")//Player does not want to change color
            {
                Console.WriteLine("Okay, we'll let the text color remain unchanged to " + Console.ForegroundColor);   
            }
            else//If player answers anything other than yes or no
            {
                Console.WriteLine("Invalid input. text color remains unchanged.");
            }
            PlayerChoose();
            PlayerColor();
        }

        //4 Prints out todays date
        static void PlayerDate()
        {
            // Stores the current date
            string currentDate = DateTime.UtcNow.ToString("dd") + "/" + DateTime.UtcNow.ToString("MM");

            // Prints it out to the player
            Console.WriteLine("####DATE####\n\nToday's date is: " + currentDate);


            PlayerChoose();
            PlayerDate();
        }

        //5 Asks for two numbers, and sees which is bigger
        static void PlayerBiggestNumber()
        { 
            string isBigger = " is the bigger number";
            
            Console.Write("####NUMBER COMPARE PROGRAM####\n\nWhat is the first number you want to compare: ");
            double numb1 = CheckIfOperatorIsDouble();

            Console.Write("\n\nAnd the second number: ");
            double numb2 = CheckIfOperatorIsDouble();
            Console.WriteLine("\n");

            //Checks which value is bigger
            string compareResult = numb1 > numb2 ? numb1 + isBigger : numb1 < numb2 ? numb2 + isBigger : "They are of equal value";

            Console.WriteLine(compareResult);

            PlayerChoose();
            PlayerBiggestNumber();

        }

        //6 Player guesses between a random number ranging from 1-100
        static void PlayerRandomNumber()
        {
            Random randnumb = new Random();
            int secretNumb = randnumb.Next(1, 100);

            int playerGuess = 0;
            int guessCount = 0;
            string gameResponse = "";

            Console.Write("####THE GUESSING GAME####\n\n" +
                "I will think of a number between 1-100, and you will try to figure\n" +
                "out what that number is. Good Luck!" +
                "\nWhat is your guess: ");
            

            while (playerGuess != secretNumb)
            {
                playerGuess = CheckIfOperatorIsInt();
                //Checks if player is too high or too low compared to the correct value.
                gameResponse = playerGuess > secretNumb ? "Too high, try again: " : playerGuess < secretNumb ? "Too low, try again: " : "";
                Console.WriteLine(gameResponse);
                guessCount++;
            }
            
            Console.WriteLine("\nAwesome, you solved the number game. The correct number was " + secretNumb
              + ". \nIt took you " + guessCount + " guesses to figure it out.");
            
            PlayerChoose();
            PlayerRandomNumber();
        }

        // 7 Stores a value in a txt file
        static void PlayerSaveFile()
        {
            Console.WriteLine("####FILE RETRIVE####" +
               
               "\nIn this function we'll retrive text information that has been stored in a text(txt) file at the following location;" +
               "\nC:\\test\\test.txt" +
               "\nIf you've done function nr. 7, then that should be the info we'll retrieve, " +
               "\notherwise we will create the folder and file as well.");

            Console.ReadLine();

            string filePath = DirandTextExist();

            try
            {
                string readFiles = File.ReadAllText(filePath);
                Console.Write("Let's see what we retrive from the file: '" + readFiles + "'\nPress Enter to continue.");
            }
            catch (Exception)
            {
                Console.WriteLine("Could not locate file. Please check to see that the directory to your text file matches with the one described" +
                                "\nin the beginning of the function");
            }
            Console.ReadLine();

            PlayerChoose();
            PlayerSaveFile();
        }

        // 8 Retrieves a value from a txt file
        static void PlayerRetriveFile()
        {

            Console.WriteLine("####SAVE STRING####"+
                "\n\nIn this function we will store a written text inside a text(txt) file. If the text file" +
                "\ndoes not exist, we will also create that file in the directory C:\\test\\test.txt");
            Console.Write("What would you like to print to the document: ");

            try
            {
                string filePath = DirandTextExist();

                string playerWriteToFile = Console.ReadLine();

                File.WriteAllText(filePath, playerWriteToFile);

                string testfile = File.ReadAllText(filePath);

                Console.WriteLine("The text: " + testfile + " has been stored at location C:\\test\\test.txt." +
                    "\nPress Enter to continue.");
            }
            catch(Exception)
            {
                Console.WriteLine("Could not locate file. Please check to see that the directory to your text file matches with the one described" +
                       "\nin the beginning of the function");
            }

            Console.ReadLine();

            PlayerChoose();
            PlayerRetriveFile();
        }

        // 9 Gives out square root, power of 2 and power of 10
        static void PlayerValues()
        {
            Console.Write("####ROOT and POWER####\n\nThe number you input will be returned in root, the power of 2 and 10." +
                "\nWhat number will it be: ");

            double playerNumb = CheckIfOperatorIsDouble();

            Values(playerNumb);

            PlayerChoose();
            PlayerValues();
        }
        // Function found inside function 9. Gives out square root, power of 2 and power of 10
        public static void Values(double numb1)
        {
            double[] Result = new double[10];

            double numbRoot = Math.Sqrt(numb1);
            Result[0] = numbRoot;
            double numbPowTwo = Math.Pow(numb1, 2);
            Result[1] = numbPowTwo;
            double numbPowTen = Math.Pow(numb1, 10);
            Result[2] = numbPowTen;
            Console.WriteLine("Square Root: " + Result[0]);
            Console.WriteLine("Power of two: " + Result[1]);
            Console.WriteLine("Power of ten: " + Result[2]);

        }

        //10 Multiplication table 1-10
        static void PlayerMultiTable()
        {
            // Asks the player to insert a number and stores it as a int
            Console.Write("####MULTIPLICATION TABLE####\n\nWhat number do you want to multiply: ");
            double baseNumb = CheckIfOperatorIsDouble();

            

            // The for loop creates that creates the multiplication table from 1-10
            for (double i = 1; i <= 10; i++)
            {
                //Writes out the table to the player
                Console.Write("|" + baseNumb + "*" + i + "=" + (baseNumb * i));
                RepeatString(" \\", i);
                Console.WriteLine();
            }

            PlayerChoose();
            PlayerMultiTable();            
        }

        //11 Creates array filled with random numbers and then stores these values from low to high in a new array
        static void PlayerArray()
        {
            Random randPart = new Random();
            int[] randArray = new int[randPart.Next(1, 40)];

            Console.WriteLine("####ARRAY CRAFTER####\n\nFirst, here is an array filled with random values\n");
            TextColor("1");
            for (int i = 0; i < randArray.Length; i++)// Creates the random array where randpart decides its length and what is stored in each index
            {
                randArray[i] = randPart.Next(1, 1000);
                Console.Write(randArray[i] + " ");

            }
            TextColor("2");

            Console.ReadLine();
            Console.WriteLine("\nNow we will those values in a new array were the values go from low to high\n");

            int[] orgArray = new int[randArray.Length];
            

            TextColor("1");
            for (int i = 0; i < randArray.Length; i++)//The structured array is created, where the values from the ranArray are stored from low to high. 
            {
                int minValue = randArray.Min();

                randArray[Array.IndexOf(randArray, minValue)] = randArray.Max()+1;

                orgArray[i] = minValue;

                Console.Write(orgArray[i] + " ");
            }
            TextColor("2");
            Console.WriteLine("");

            PlayerChoose();
            PlayerArray();
        }

        //12 Checks if an input is a palindrome
        static void PlayerPalindrome()
        {
            //The player inputs the word they want to check
            Console.Write("####PALINDROME CHECKER####\n\nLet us check if your word is in fact a palindrome." +
                "\nInput word: ");
            string playerWord = Console.ReadLine().ToLower();

            // Their word gets split into an array
            char[] wordSplit = playerWord.ToCharArray();

            // Creates a new array and reverses its order
            char[] splitReversed = wordSplit;
            Array.Reverse(splitReversed);

            // Joins the reversed order into a string
            string newWord = string.Join("", splitReversed);

            // Displays the new word that is reversed and the one inputted by the player
            Console.WriteLine(newWord + " " + playerWord);

            // Checks to to see if the reveresed word is the same as the one inputted by the player
            string palOrNot = playerWord == newWord ? "The word is indeed a palindrome" : "That word is not a palindrome";
            Console.WriteLine(palOrNot);

            PlayerChoose();
            PlayerPalindrome();
        }

        //13 Asks for a low and high value, and prints out all the values between those two values
        static void PlayerNumberRange()
        {
            int numb1;
            int numb2;

            Console.WriteLine("####RANGING NUMBERS####\n\nWhat span of whole numbers do you want to see?");
            Console.Write("From: ");
            //Checks to see that the player has inputted a whole number
            numb1 = CheckIfOperatorIsInt(); 

            Console.Write("\nTo: ");
            numb2 = CheckIfOperatorIsInt();
            if (numb1+1 >= (numb2))
            {
                Console.WriteLine("The requested input for the lower value is higher or equal to the requested higher value.");
            }
            else
            {
                int currentNumb = ++numb1;
                TextColor("3");
                Console.WriteLine("");
                while (currentNumb < numb2)
                {
                    Console.Write(currentNumb + " ");
                    currentNumb++;
                }
                TextColor("2");

                Console.WriteLine("\n\nThat is all the numbers");

            }
            PlayerChoose();
            PlayerNumberRange();
        }

        //14 Asks for set of values and seperates the even and odd in two arrays
        static void PlayerOddEven()
        {
            Console.Write("####ODD and EVEN####\n\n" +
                "In this function you are tasked to insert a set of numbers, afterwhich odd and even numbers " +
                "\nwill be seperated." +
                "\nPlease insert a set of numbers seperated by commas(,): ");

            //Player input 
            string answerTrim = RemoveWhiteSpaces();

            //Changes input to string and places 
            string [] playerNumbers = answerTrim.Split(',');

            //Lists that will store the even and odd values
            List<double> listEven = new List<double>();
            List<double> listOdd = new List<double>();

            double numbcheck;

            try
            {
                for (int i = 0; i < playerNumbers.Length; i++)
                {
                    playerNumbers[i] = playerNumbers[i].Replace(".", ",");
                    numbcheck = Convert.ToDouble(playerNumbers[i]);

                    if (IsEven(numbcheck) == true)
                    {
                        listEven.Add(numbcheck);
                    }
                    else
                    {
                        listOdd.Add(numbcheck);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nYou entered in the numbers in a non-correct manner, try again.\n");
              
                PlayerOddEven();
            }

            // First displays the even ones, and then the odd ones.
            Console.WriteLine("\nFirst, the even ones: ");
            TextColor("1");
               foreach(double even in listEven)
                {
                    Console.Write(even + " ");
                }
            TextColor("2");
            Console.ReadLine();

            Console.WriteLine("\nnow, the odd ones: ");
            TextColor("1");
               foreach(double odd in listOdd)
                {
                    Console.Write(odd + " ");
                }
            TextColor("2");
            Console.ReadLine();

            PlayerChoose();
            PlayerOddEven();
        }

        //Removes the white spaces within a string
        static string RemoveWhiteSpaces()
        {
            string playerString = Console.ReadLine();
            string spacesRemoved = Regex.Replace(playerString, @"\s+", "");

            return spacesRemoved;
        }

        // Function used inside of task 14
        public static bool IsEven(double numb)
        {//Checks if a value is even or odd

           bool result = numb % 2 == 0 ? true : false;
            return result;
        }

        //15 Asks for a set of numbers, than adds those numbers together
        static void PlayerAddNumbers()
        {

            Console.Write("####ADDING NUMBERS####\n\nWhich numbers do you want to add together? " +
                "\nUse commas(',') to seperate numbers: ");
            string answerTrim = RemoveWhiteSpaces();
            string[] playerNumbers = answerTrim.Split(',');
                  
            double sum = 0;

            try
            {
                for (int i = 0; i <= playerNumbers.Length - 1; i++)
                {
                    playerNumbers[i] = playerNumbers[i].Replace(".", ",");
                    sum = sum + Convert.ToDouble(playerNumbers[i]);
                }
                Console.WriteLine("\nThe added sum is: " + sum);
                Console.ReadLine();
           }
            
            catch
            {
                Console.WriteLine("\nYou entered in the numbers in a non-correct manner, try again.\n");
                PlayerAddNumbers();
            }
           
            PlayerChoose();
            PlayerAddNumbers();
        }

        //16 Player is asked to give their character and enemy a name, and gives the player character a random values for health, luck and power
        static void PlayerQuest()
        {
            //Used to check what choices the player makes along the, albeit rather short, quest.
            int Playerchoice;
            //Dice used in game
            Dice myDice = new Dice();

            //Name Dialogue
            Console.WriteLine("####THE GRAND QUEST####\n\nAs you get ready to set off on some big grand adventure, your mother says that the village elder\n" +
                               "is wating for you near the bridge. You give your mother a big old hug, afterwards go and see what " +
                               "\nthe elder wants.");
            Dialogue("Elder", "Ah, yes, there you are. Good... good...eh. What, what was your name again: ");
            //Initiates Main character(MC) and the player is asked to give him/her a name
            Character MC = new Character(true);
            MC.CurrentStats();

            //Presentation and enemy name dialogue
            Dialogue("Elder", MC.name + 
                ", mmm. So it was, yes. I understand that you are sick of our little town, that you seek adventure. " +
                "\nAh, felt the same way when I was your age. What I wouldn't give... Anyhow,alas, in order to venture" +
                "\nout onto the great unknown, you must first conquer the mighty bool beast that has occupied the town" +
                "\nbridge. What did it call itself? I forget.");
            Dialogue(MC.name, "It's name is: ");
            //Initiates enemy1 and the player is asked to give it a name
            Character enemy1 = new Character();
            enemy1.Luck = 1; enemy1.Health = 20; enemy1.Power = 2;

            //Some advice and then the player is off to face the bool beast
            Dialogue("Elder", "That's right. " + enemy1.name + ", that was the monster's name. You could try fighting him." +
                    "\nOr, just  yell 'fight equals false' as you approach. That will confuse the sucker. That is all, " +
                    "\nremember to drink lots of water, eat plenty of food and be carful of strangers. Good luck.");
            Console.Write("Press enter to continue: ");
            Console.ReadLine();

            Console.Clear();

            Console.WriteLine("\nAs you approach the bridge, you see " + enemy1.name + " in the distance.");

             if(myDice.DiceRollagainstTreshold(10, MC.Luck, 12) == true)//makes a luck check to see if bool beast is sleeping
                {
                Console.WriteLine("\nYou slowly make your way towards the beast, when you hear a snooring sound. As the distance between you " +
                                "\nand " + enemy1.name + "shortens, the sound gets louder. When only a few meters remain, you realize that " +
                                "\nthe snooring is coming from the bool beast itself. It is sound asleep. You exhale. No need to fight it." +
                                "\nYou can just sneak past it and be on your merry way. ");
                Console.ReadLine();
            }
            else
            {   // Otherwise you have to face it
                Console.WriteLine("\nYou slowly make your way towards the bool beast standing on the other side of the bridge, it's gaze dead set on you." +
                                "\nMoments later you're only a few steps away from " + enemy1.name + " and it shouts; ");
                Dialogue(enemy1.name, "ANGRY EQUALS TRUE!");
                Console.WriteLine("\nIt seems to be getting ready to fight you. What do you do?" +
                    "\n1 = Fight (Tutorial)" +
                    "\n2= Shout 'Fight equals false' and Skip fight");
                
                Playerchoice = CheckIfOperatorIsInt();

                if (Playerchoice == 1)//If player chooses to fight it
                {
                    while (MC.Health > 0 && enemy1.Health > 0)//Fight goes on until one of them has lost all their health
                    {
                        Console.WriteLine("You attack " + enemy1.name);
                        enemy1.Health -= (MC.Power+ myDice.DiceToss(6));
                            Console.WriteLine(enemy1.name + "'s health is down to: " + enemy1.Health);
                            Console.ReadLine();
                            if (enemy1.Health <= 0)
                            {
                                Console.WriteLine("You are victorious!");
                            }
                        else
                            {
                                Console.WriteLine("The beast leaps and attack you.");
                                MC.Health -= (enemy1.Power + myDice.DiceToss(6));
                                Console.WriteLine("Your remaining health is: " + MC.Health);
                                Console.ReadLine();
                            }
                        if(MC.Health <= 0){
                            Console.WriteLine("The beast defeats you. GAME OVER!");
                            PlayerChoose();
                        }  
                    }
                }
                else if(Playerchoice == 2)//Player chooses to skip tutorial
                {
                    Console.WriteLine("You stare into " + enemy1.name + "'s eyes and yell out: ");
                    Dialogue(MC.name, "Fight equals false!");
                    Console.WriteLine("\nUpon hearing the words, bool beast slowly steps aside, letting you through. As you walk past it, " + enemy1.name + " says: ");
                    Dialogue(enemy1.name, "You equal coward.");
                    
                }
                else//Player does not input a valid response(1 or 2)
                {
                    Console.WriteLine("\nThat wasn't a valid response. Oh, well, let's just skip ahead then, shall we.");
                }
                Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine("\n\nSo, now you are off. What grand quests await you beyond? What perils shall you have to overcome?" +
                "\n How will your story end? That, dear reader, is a tale for another time.");
            Console.ReadLine();

            PlayerChoose();
            PlayerQuest();
        }

        //The dialogue structure used in PlayerQuest()
        public static void Dialogue(string name, string dialogue)
        {


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n" + name);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dialogue);

            Console.ForegroundColor = DefaultColor;
        }

        //Checks to see that the player has inputted a int number
        public static int CheckIfOperatorIsInt() 
        {
            int result = 0;

            bool test = false;

            while (test == false)
            {

                string playerinput = Console.ReadLine();

                test = Int32.TryParse(playerinput, out result);

                if (test == false)
                {
                    Console.WriteLine("Invalid input. Try again: ");

                }
            

            }
            return result;

        }
        //Checks to see that the player has inputted a double number
        public static double CheckIfOperatorIsDouble()
        {
            double result = 0;

            bool test = false;

            while (test == false)
            {

                string playerinput = Console.ReadLine();

                test = Double.TryParse(playerinput, out result);

                if (test == false)
                {
                    Console.WriteLine("\nInvalid input. Try again: ");
                    
                }

            }
            return result;

        }

        //Function found at the end of all the main functions, where the player gets to choose how to proceed
        public static void PlayerChoose()
        {        
            Console.WriteLine("-----------------------------------------------------------------------------" +
                "\nWould you like to;" +
                "\nrun the function again: Input 1 " +
                "\nReturn to main menu: Input 2" +
                "\nExit program: Input 3" +
                "\nRemember! After number input, confirm by pressing 'Enter'.");
            string playerChoice = Console.ReadLine();

            while(playerChoice != "1" && playerChoice != "2" && playerChoice != "3")
            {                  
                Console.Write("Invalid input, try again: ");
                playerChoice = Console.ReadLine();
            }

           if (playerChoice == "1")
            { // Play the function again
                //Run what is written below in the function PlayerChoose is initiated
                Console.WriteLine("");// Creates a line, just to make it more readable.

            }
            else if (playerChoice == "2")
            {// Return to main menu
                Intro();
            }
            else if (playerChoice == "3")
            {// Exit the program
                System.Environment.Exit(1);
            }
            Console.Clear();

        }

        //Change between different colors, adding a bit of juiciness to the program style
        public static void TextColor(string color)
        {
            // 1 = yellow, 2 = DefaultColor, 3 = green, etc

               Console.ForegroundColor = color == "1" ? ConsoleColor.Yellow : color == "2" ? DefaultColor : color == "3" ? ConsoleColor.Green : color == "4" ? ConsoleColor.White: color == "5" ? ConsoleColor.Blue: DefaultColor;
        }
       
        //Creates directory and text file in case it does not exist

        public static string DirandTextExist()
        {
            string directoryPath = @"C:\test";
            string filePath = @"C:\test\test.txt";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("This is a default text");

                }
            }
            return filePath;
        }

        //Repeats a string a certain amount of times
        public static void RepeatString(string repeatedWord, double i) {
            double start = 0;
            while(start < i)
            {
                Console.Write(repeatedWord);
                start++;
            }
        }

      
        
    }
}
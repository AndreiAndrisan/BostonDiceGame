//Author:Andrei Andrisan
//Student number:17644224
//Starting date: 28.11.2017 - Created the classes(Choose,Game,Player,Die)
//Date: 30.11.2017 - Created the MatchPlay method
//Date: 01.12.2017 - Created the PlayerTurn method
/*Date: 02.12.2017 - Created the AI - AITurn method
                                    - bool variable vs(if the bool is truth the player will play against the AI)
                                    - Added a AI version of Match Play
                   - Created the class TableScore with the methods CreateTable, ShowTable,RoundLine,NameLine,ScoreLine,PointsLine
                   - Added a new method in Game class named ClearCurrentConsoleLine which clear the current line written*/
//Date: 03.12.2017 - Added new methods in the TableScore class named UpdateNameLine, UpdateScoreLine,UpdatePointsLine 
/*Date: 04.12.2017 - Added a new method in Game class named ScorePlay
                   - Changed the name of method ShowTable in ShowTableM ( letter M coming from the type of match play)
                   - Added a new method in TableScore class named ShowTableS ( letter S coming from the type of match play)*/
/*Date: 05.12.2017 - Added a new method in Choose class named Restart
                   - Added a new method in Game class named downMeniu
                   - Added a restart and exit option after each throw
                   - Added a back option for the second question*/
//Date: 06.12.2017 - Added new methods in the Game class named winnerPanel
//Date: 07.12.2017 - Added more information about the game at the start of the Main and created the Information.txt file
//   ' = '  Class limitator
//   ' - '  Method limitator
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Assessment3
{
class Choose //===========================================================================================================================================================this is the class where the player chose what type of game and against who he wants to play
{                                                                                                                                                                       
    static void Main(string[] args)      //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    {
            ConsoleKeyInfo x;                                                                                                                                           //this is the key which it's modified each time the player make a choise
            Console.WriteLine("‘GOING TO BOSTON’ dice game. \n1. Continue \n2. More Information \n3. Exit");                                                            //write in the console the name of the game and the choises
            Console.WriteLine("IMPORTANT: To select an option from the meniu you must press number situated in the left side of it.");                                  //write in the console an important information about what you must press to chose between the options 
            do                                                                                                                                                          //we enter a loop in which we force the player to press one of the numbers in front of the options
            {                                                                                                                                                           // I WILL NOTE THIS LOOP WITH THE WORD "L O O P" IN THE NEXT LINES
                x = Console.ReadKey();
                Console.Write("\b \b"); //this is a backspace
            }
            while (x.KeyChar != '2' && x.KeyChar != '1' && x.KeyChar != '3');                                                                                           //if the player press something else beside the numbers in front of the options the loop will start again
            if (x.KeyChar == '2')                                                                                                                                       //if the player press '2'
            {
                Console.Clear();                                                                                                                                        //clear the console to help the player see more clearly the information
                string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "Information.txt");                                                                     //find the file named "Information.txt" in which I stored optional information about the game and put the path in a string
                string aboutGame = File.ReadAllText(pathFile);                                                                                                          //read all the text in a string using the path that we found earlier
                Console.WriteLine(aboutGame);                                                                                                                           //write the text from the file in the console
                Console.WriteLine("1. Continue \n2. Exit");                                                                                                             //write the options
                do                                                                                                                                                      //L O O P
                {
                    x = Console.ReadKey();
                    Console.Write("\b \b");
                }
                while (x.KeyChar != '2' && x.KeyChar != '1');
                if (x.KeyChar == '2')                                                                                                                                   //if the player press 2 exit the program
                    Environment.Exit(0);
            }
            Console.Clear();                                                                                                                                            //clear the console
            if (x.KeyChar == '3')                                                                                                                                       //if the player press 2 exit the program              
                Environment.Exit(0);
            bool vsAI;                                                                                                                                                  //creating a bool val which becomes true when the player chose to play against AI
            do
            {
                vsAI = false;                                                                                                                                           // at the start the bool value is false
                Console.WriteLine("Do you want to play with a player or with the AI? \n1. Player \n2. AI");
                do                                                                                                                                                      //L O O P
                {
                    x = Console.ReadKey();
                    Console.Write("\b \b");
                }
                while (x.KeyChar != '2' && x.KeyChar != '1') ;
                if (x.KeyChar == '2')                                                                                                                                   //if the player press 2 bool value becomes true
                    vsAI = true;
                Console.Clear();
                Console.WriteLine("Which mode do you want to play? \n1. Match play \n2. Score play \nIf you want to go back to the first question press 3.");
               do                                                                                                                                                       //L O O P
               {
                    x = Console.ReadKey();
                    Console.Write("\b \b");
               }
               while (x.KeyChar != '2' && x.KeyChar != '1' && x.KeyChar != '3');
               Console.Clear();
            }
            while (x.KeyChar == '3');
            switch (x.KeyChar)                                                                                                                                          //chose between the 2 types of game
            {
                case '1':
                    Game.MatchPlay(vsAI);
                    break;
                case '2':
                    Game.ScorePlay(vsAI);
                    break;
            }
            Console.WriteLine("Do you want to play again? \n1. Yes \n2. No ");                                                                                          //ask the player if he wants to continue 
            do                                                                                                                                                          //L O O P
            {
                x = Console.ReadKey();
                Console.Write("\b \b");
            }
            while (x.KeyChar != '1' && x.KeyChar != '2');
            if (x.KeyChar == '1')                                                                                                                                       //if the player press 1
            {
                Console.Clear();                                                                                                                                        //clear the console
                Main(null);                                                                                                                                             //recall the Main method to restart the game
            }
            else
                Environment.Exit(0);                                                                                                                                    //if not close the program
        }
    public static void Restart()        //--------------------------------------------------------------------------------------------------------------------------------a method to restart the program to use it later in the program
    {
        Console.Clear();                                                                                                                                                
        Main(null);
    }
}
    class Game   //======================================================================================================================================================the class where the selected modes are played 
    {
        public static void MatchPlay(bool y)    //-----------------------------------------------------------------------------------------------------------------------the method which contains the match play mode that have as parameter the bool which tell us if the player wants to play against the AI or not
        {
            if (y == false)                                                                                                                                             //if the player want to play against another player
            {
                Player player1 = new Player();                                                                                                                          //i created a player1 instance from class player 
                Console.WriteLine("Please enter a name for player 1:");                                                                                                 //ask the player1 for a name
                player1.name = Console.ReadLine();                                                                                                                      //read the name in player1.name string 
                Console.Clear();                                                                                                                                        //clear the console
                Player player2 = new Player();                                                                                                                          //i created a player2 instance from class player 
                Console.WriteLine("Please enter a name for player 2:");                                                                                                 
                bool same = false;                                                                                                                                      //bool var that helps me to check if player2 entered the same name as player1 
                do
                {
                    if (same == true)                                                                                                                                   //if it's true ask him to enter another name
                        Console.WriteLine("Please enter a different name than player 1:");                                                                              //write the question in the console
                    player2.name = Console.ReadLine();      
                    same=true;                                                                                                                                          //make the bool true after the first 
                    Console.Clear();                                                                                                                                    //clear the console
                }
                while (player1.name == player2.name);   
                int round = 1;                                                                                                                                          //int value that indicates the number of rounds at the start it's initialised with 1
                Console.SetCursorPosition((Console.WindowWidth - "Match Mode Starting".Length) / 2, Console.CursorTop);                                                 //moving the cursor in the middle of the screec
                Console.WriteLine("Match Mode Starting");                                                                                                               //writing the type of match
                TableScore.showTableM(player1, player2, round);                                                                                                         //calling from class TableScore the method showTableM who write in the console the table for the 'match play' mode 
                while (player1.points != 5 && player2.points != 5)                                                                                                      //enter the loop which decide when the match play mode ends
                {
                    Console.SetCursorPosition((Console.WindowWidth - ("Roll the dice (press r).".Length)) / 2, Console.CursorTop);                                      //se the cursot in the middle of the screen
                    Console.WriteLine("Roll the dice (press r).");                                                                                          //tell the player when to roll the dice and which key to press to do it
                    while (player1.dice.number != 0 || player2.dice.number != 0)                                                                                        //this loop decide when a round ends more exactly when both players have 0 dice left
                    {
                        if (player1.dice.number == player2.dice.number)                                                                                                 //if the number of dice owned by the players is equal, it's player1's turn
                        {
                            player1.turn = true;                                                                                                                        //the bool value of the player1 instance become true
                            player2.turn = false;                                                                                                                       //player2's bool value becomes false
                            TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 0);                                                       //method from class TableScore that updates the arrow in the right of the name that show's which player turn is( I WILL NOTE THIS METHOD WITH THE WORD 'UPDATE NAMES' )
                            PlayerTurn(player1, 27);                                                                                                                    //method from the current class that shows the face of the dice updates the score and substract a die from the current player at the end of the throw
                            TableScore.UpdateScoreLine(player1, player2, 0);                                                                                            //method from class TableScore that updates the ponts from the table
                            for (int i = 0; i < 5 * (player1.dice.number + 1) + 2; i++)                                                                                 //with this loop i'm moving the cursor back to the inital position after the faces of the dice appeared
                                Console.SetCursorPosition(0, Console.CursorTop - 1);                                                                                    //i will explain this number    5 * (player1.dice.number + 1) + 2
                        }                                                                                                                                                      // 5 - a face of a die is formed from 5 lines      (player1.dice.number + 1) - we multiply it with the number of dice that the current player had this round(beacuse the number of dice was substrated in playerTurn method we added 1)
                        else                                                                                                                                                   // 2 - one endline come from the UpdateScoreLine and one from the last face of the die wrote in the console                                                                                                                                                             
                        {
                            player1.turn = false;                                                                                                                        //player1's bool value becomes false
                            player2.turn = true;                                                                                                                         //player2's bool value becomes true(because it's player2's turn)
                            TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 0);                                                        //UPDATE NAMES
                            PlayerTurn(player2, -9);                                                                                                                     //same as player1
                            TableScore.UpdateScoreLine(player1, player2, 0);                                                                                             //same as player1
                            int downMeniuAppear = 1;                                                                                                                     //int value helps me to go back one more line (more exactly the current line)
                            if (!(player2.dice.number==0 && ((player1.points == 4 && player2.points == 4) || (player1.points == 4 && player1.score > player2.score) || (player2.points == 4 && player2.score > player1.score))))
                            {                                                               //the condition above check if it's not the final throw  
                                downMeniu();                                                //because it's not the final throw after both player throw their dice a down meniu will appear in which the players can select if they want to continue or not
                                downMeniuAppear = 3;                                        //because the down meniu contain 2 more lines the number of lines i must clear after the throw ends rise by 2
                            }
                            else                                                                                                                                          //if it's the final throw and the program must show the winner 
                            {
                                Console.SetCursorPosition((Console.WindowWidth - ("Press any key to see the winner.".Length)) / 2, Console.CursorTop);
                                Console.WriteLine("Press any key to see the winner.");                                                                                    //i've created this line because the last die rolled by the second player will be cleared immediately even if the score will be updated
                                Console.ReadKey();
                                Console.Write("\b \b");
                            }
                            for (int i = 0; i < 5 * (player2.dice.number + 1) + 2 + downMeniuAppear; i++)                                                                 //with this loop i'm clearing the console until the bottom of the Table Score
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                ClearCurrentConsoleLine();                                                                                                                 //this is a method that clears the current line
                            }
                        }
                    }
                    if (player1.score > player2.score)                                                                                                                      //with the nested if-else from below i'm rising tthe number of points of the winner by 1 and
                    {                                                                                                                                                       //i'm updateing the line in the Score Table where the points for each player are written and 
                        player1.points++;                                                                                                                                   //i'm updateing the lines which contains the names by pointing the arrow to the player who won the round
                        player1.turn = true;
                        player2.turn = false;
                        TableScore.UpdatePointsLine(player1, player2, 0);
                        TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 0);               
                    }
                    else
                    {
                        if (player1.score < player2.score)                                                  
                        {
                            player2.points++;
                            player1.turn = false;
                            player2.turn = true;
                            TableScore.UpdatePointsLine(player1, player2, 0);
                            TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 0);
                        } else
                             if (player1.score == player2.score)                                                                                                           //if it's a draw no one get points
                             {
                                player1.turn = false;
                                player2.turn = false;
                                TableScore.UpdatePointsLine(player1, player2, 0);
                                TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 0);
                             }
                    }
                    round++;                                                                                                                                                //the number of rounds rise by 1 
                    player1.score = 0;                                                                                                                                      //both players score becomes 0 for the next round
                    player2.score = 0;
                    player1.dice.number = 3;                                                                                                                                //both players have again the 3 dice
                    player2.dice.number = 3;
                    Console.SetCursorPosition(0, Console.CursorTop - 2);                                                                                                    //writing a new stage without clearing the old one
                    if (player1.points != 5 && player2.points != 5)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        TableScore.showTableM(player1, player2, round);
                    }
                }
                if (player1.points == 5)                                                                                                                                    //which one of the players wins will be written in the console with the help of winnerPanel method
                {
                    winnerPanel(player1.name);
                }
                else
                {
                    winnerPanel(player2.name);
                }
            }
            else                                                                                                                                                            //if the player selected AI
            {
                Player player1 = new Player();                                                                                                                              //a lot of lines are the same but the difference is that we don't ask the player for a second name
                Console.WriteLine("Please enter your name:");                                                                                                               //and the AI throw automatically with a special method AI Turn
                player1.name = Console.ReadLine();                                                                                                                          
                Console.Clear();                                                                                                                                            
                Player AI = new Player();                                                                                                                                   //created an AI instance using the class player
                AI.name = "AI";
                int round = 1;
                Console.SetCursorPosition((Console.WindowWidth - "Match Mode Starting".Length) / 2, Console.CursorTop);
                Console.WriteLine("Match Mode Starting");
                TableScore.showTableM(player1, AI, round);
                while (player1.points != 5 && AI.points != 5)
                {
                    Console.SetCursorPosition((Console.WindowWidth - ("Roll the dice (press r).".Length)) / 2, Console.CursorTop);
                    Console.WriteLine("Roll the dice (press r).");                                                                                                          //tell the player when to roll the dice and which key to press to do it
                    while (player1.dice.number != 0 || AI.dice.number != 0)
                    {
                        if (player1.dice.number == AI.dice.number)
                        {
                            player1.turn = true;
                            AI.turn = false;
                            TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 0);
                            PlayerTurn(player1, 27);
                            TableScore.UpdateScoreLine(player1, AI, 0);
                            for (int i = 0; i < 5 * (player1.dice.number + 1) + 2; i++)
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                        }
                        else
                        {
                            player1.turn = false;
                            AI.turn = true;
                            TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 0);
                            AITurn(AI);                                                                                                                                      //this is the AI method
                            TableScore.UpdateScoreLine(player1, AI, 0);
                            int downMeniuAppear = 1;
                            if (!(AI.dice.number == 0 && ((player1.points == 4 && AI.points == 4) || (player1.points == 4 && player1.score > AI.score) || (AI.points == 4 && AI.score > player1.score))))           //this is condition that verifies if it's not the last round
                            {
                                downMeniu();
                                downMeniuAppear = 3;
                            }
                            else
                            {
                                Console.SetCursorPosition((Console.WindowWidth - ("Press any key to see the winner.".Length)) / 2, Console.CursorTop);
                                Console.WriteLine("Press any key to see the winner.");
                                Console.ReadKey();
                                Console.Write("\b \b");
                            }
                            for (int i = 0; i < 5 * (player1.dice.number + 1) + 2 + downMeniuAppear; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                ClearCurrentConsoleLine();
                            }
                        }
                    }
                    if (player1.score > AI.score)
                    {
                        player1.points++;
                        player1.turn = true;
                        AI.turn = false;
                        TableScore.UpdatePointsLine(player1, AI, 0);
                        TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 0);                                                                     //with this i'm trying to point the arrow to the player who won the round
                    }
                    else
                    {
                        if (player1.score < AI.score)
                        {
                            AI.points++;
                            player1.turn = false;
                            AI.turn = true;
                            TableScore.UpdatePointsLine(player1, AI, 0);
                            TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 0);
                        } else
                        {
                            if (player1.score == AI.score)
                            {
                                player1.turn = false;
                                AI.turn = false;
                                TableScore.UpdatePointsLine(player1, AI, 0);
                                TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 0);
                            }
                        }
                    }
                    round++;
                    player1.score = 0;
                    AI.score = 0;
                    player1.dice.number = 3;
                    AI.dice.number = 3;
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    if (player1.points != 5 && AI.points != 5)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        TableScore.showTableM(player1, AI, round);
                    }
                }
                if (player1.points == 5)
                {
                    winnerPanel(player1.name);
                }
                else
                {
                    winnerPanel(AI.name);
                }
            }

        }
        public static void ScorePlay(bool y) //--------------------------------------------------------------------------------------------------------------------the method which contains the score play mode that have as parameter the bool which tell us if the player wants to play against the AI or not
        {
            if (y == false)
            {
                Console.WriteLine("How many rounds do you want to play?/nMaximum number is 50.");                                                                      // the first difference is that mode we ask the player how many rounds he wants to play    
                string number;
                int n;
                do
                {
                    number = Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
                while (int.TryParse(number, out n) == false || Convert.ToInt32(number) > 50 || Convert.ToInt32(number) < 1);                                            //this is the condition where we check if the number introduced it's not a string or it's a number bigger than 50(the maximum number of rounds) or smaller than 1
                Console.Clear();                                                                                                                                        //from here the code it's the same as match play mode with some differences for example:
                Player player1 = new Player();                                                                                                                          //          -in this mode the score doesn't reset at the final of each round
                Console.WriteLine("Please enter a name for player 1:");                                                                                                 //          -in this mode points doesn't exist and i'm comparing the scores at the end of the game to determin the winner
                player1.name = Console.ReadLine();                                                                                                                      //          -the Table doesn't have the points line
                Console.Clear();                                                                                                                                        //          -in this mode the result can be a draw
                Player player2 = new Player();
                Console.WriteLine("Please enter a name for player 2:");
                int run = 0;
                do
                {
                    if(run>0)
                        Console.WriteLine("Please enter a different name than player 1:");
                    player2.name = Console.ReadLine();
                    run++;
                    Console.Clear();
                }
                while (player1.name == player2.name);
                int round = 1;
                Console.SetCursorPosition((Console.WindowWidth - "Score Mode Starting".Length) / 2, Console.CursorTop);
                Console.WriteLine("Score Mode Starting");
                TableScore.showTableS(player1, player2, round);                                                                                                         // the method which write the special table for score play mode
                while (round <= n)
                {
                    Console.SetCursorPosition((Console.WindowWidth - ("Roll the dice (press r).".Length)) / 2, Console.CursorTop);
                    Console.WriteLine("Roll the dice (press r).");                                                                                          //tell the player when to roll the dice and which key to press to do it
                    while (player1.dice.number != 0 || player2.dice.number != 0)
                    {
                        if (player1.dice.number == player2.dice.number)
                        {
                            player1.turn = true;
                            player2.turn = false;
                            TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 1);
                            PlayerTurn(player1, 27);
                            TableScore.UpdateScoreLine(player1, player2, 1);
                            for (int i = 0; i < 5 * (player1.dice.number + 1) + 2; i++)
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                        }
                        else
                        {
                            player1.turn = false;
                            player2.turn = true;
                            TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 1);
                            PlayerTurn(player2, -9);
                            TableScore.UpdateScoreLine(player1, player2, 1);
                            int downMeniuAppear = 1;
                            if (!(player2.dice.number == 0 && round==n))
                            {
                                downMeniu();
                                downMeniuAppear = 3;
                            }
                            else
                            {
                                Console.SetCursorPosition((Console.WindowWidth - ("Press any key to see the winner.".Length)) / 2, Console.CursorTop);
                                Console.WriteLine("Press any key to see the winner.");
                                Console.ReadKey();
                                Console.Write("\b \b");
                            }
                            for (int i = 0; i < 5 * (player2.dice.number + 1) + 2 + downMeniuAppear; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                ClearCurrentConsoleLine();
                            }
                        }
                    }
                    round++;
                    player1.dice.number = 3;
                    player2.dice.number = 3;
                    if (player1.score > player2.score)
                    {
                        player1.turn = true;
                        player2.turn = false;
                        TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 1);                                                //with this i'm pointing the arrow to the player who won the round
                    }
                    else
                        if (player1.score > player2.score)
                        {
                            player1.turn = false;
                            player2.turn = true;
                            TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 1);                                           //with this i'm pointing the arrow to the player who won the round
                        }
                        else
                            if (player1.score == player2.score)
                            {
                                player1.turn = false;
                                player2.turn = false;
                                TableScore.UpdateNameLine(player1.name, player2.name, player1.turn, player2.turn, 1);
                            }
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    if (round <= n)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        TableScore.showTableS(player1, player2, round);
                    }
                }
                if (player1.score > player2.score)
                    winnerPanel(player1.name);
                else
                     if (player1.score < player2.score)
                     {
                         Console.SetCursorPosition(0, Console.CursorTop + 1);
                         winnerPanel(player2.name);
                     }
                     else
                         if (player1.score == player2.score)
                         {
                             Console.SetCursorPosition((Console.WindowWidth - "| It's a draw!!! |".Length) / 2, Console.CursorTop);
                             for (int i = 0; i < "| It's a draw!!! |".Length; i++)
                                 if (i < "| It's a draw!!! |".Length / 2)
                                     Console.Write('/');
                                 else
                                     Console.Write('\\');
                             Console.WriteLine();
                             Console.SetCursorPosition((Console.WindowWidth - "| It's a draw!!! |".Length) / 2, Console.CursorTop);
                             Console.WriteLine("| It's a draw!!! |");
                             Console.SetCursorPosition((Console.WindowWidth - "| It's a draw!!! |".Length) / 2, Console.CursorTop);
                             for (int i = 0; i < "| It's a draw!!! |".Length; i++)
                                 if (i < "| It's a draw!!! |".Length / 2)
                                     Console.Write('\\');
                                 else
                                     Console.Write('/');
                            Console.WriteLine();
                         }
            }
            else                                                                                                                        //the same as the one from before but instead of player2 the player plays against the AI
            {
                Console.WriteLine("How many rounds do you want to play?");
                string number;
                int n;
                do
                {
                    number =Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
                while (int.TryParse(number,out n) == false || Convert.ToInt32(number)>50 || Convert.ToInt32(number) < 1);
                Console.Clear();
                Player player1 = new Player();
                Console.WriteLine("Please enter your name:");
                player1.name = Console.ReadLine();
                Console.Clear();
                Player AI = new Player();
                AI.name = "AI";
                int round = 1;
                Console.SetCursorPosition((Console.WindowWidth - "Score Mode Starting".Length) / 2, Console.CursorTop);
                Console.WriteLine("Score Mode Starting");
                TableScore.showTableS(player1, AI, round);
                while (round <= n)
                {
                    Console.SetCursorPosition((Console.WindowWidth - ("Roll the dice (press r).".Length)) / 2, Console.CursorTop);
                    Console.WriteLine("Roll the dice (press r).");              //tell the player when to roll the dice and which key to press to do it
                    while (player1.dice.number != 0 || AI.dice.number != 0)
                    {
                        if (player1.dice.number == AI.dice.number)
                        {
                            player1.turn = true;
                            AI.turn = false;
                            TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 1);
                            PlayerTurn(player1, 27);
                            TableScore.UpdateScoreLine(player1, AI, 1);
                            for (int i = 0; i < 5 * (player1.dice.number + 1) + 2; i++)
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                        }
                        else
                        {
                            player1.turn = false;
                            AI.turn = true;
                            TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 1);
                            AITurn(AI);
                            TableScore.UpdateScoreLine(player1, AI, 1);
                            int downMeniuAppear = 1;
                            if (!(AI.dice.number == 0 && round == n))
                            {
                                downMeniu();
                                downMeniuAppear = 3;
                            }
                            else
                            {
                                Console.SetCursorPosition((Console.WindowWidth - ("Press any key to see the winner.".Length)) / 2, Console.CursorTop);
                                Console.WriteLine("Press any key to see the winner.");
                                Console.ReadKey();
                                Console.Write("\b \b");
                            }
                            for (int i = 0; i < 5 * (player1.dice.number + 1) + 2 + downMeniuAppear; i++)
                            {
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                ClearCurrentConsoleLine();
                            }
                        }
                    }
                    if (player1.score > AI.score)
                    {
                        player1.turn = true;
                        AI.turn = false;
                        TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 1);    //with this i'm trying to point the arrow to the player who won the round
                    }
                    else
                    {
                        if (player1.score < AI.score)
                        {
                            player1.turn = false;
                            AI.turn = true;
                            TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 1);
                        }
                        else
                        {
                            if (player1.score == AI.score)
                            {
                                player1.turn = false;
                                AI.turn = false;
                                TableScore.UpdateNameLine(player1.name, AI.name, player1.turn, AI.turn, 1);
                            }
                        }
                    }
                    round++;
                    player1.dice.number = 3;
                    AI.dice.number = 3;
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    if (round <= n)
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        TableScore.showTableS(player1, AI, round);
                    }
                }
                if (player1.score > AI.score)
                    winnerPanel(player1.name);
                else
                     if (player1.score < AI.score)
                        winnerPanel(AI.name);
                     else
                         if (player1.score == AI.score)
                         {
                              ClearCurrentConsoleLine();
                              Console.SetCursorPosition((Console.WindowWidth - "| It's a draw!!! |".Length) / 2, Console.CursorTop);
                              for (int i = 0; i < "| It's a draw!!! |".Length; i++)
                                    if(i < "| It's a draw!!! |".Length / 2)
                                      Console.Write('/');
                                    else
                                      Console.Write('\\');
                              Console.WriteLine();
                              Console.SetCursorPosition((Console.WindowWidth - "| It's a draw!!! |".Length) / 2, Console.CursorTop);
                              Console.WriteLine("| It's a draw!!! |");
                              Console.SetCursorPosition((Console.WindowWidth - "| It's a draw!!! |".Length) / 2, Console.CursorTop);
                              for (int i = 0; i < "| It's a draw!!! |".Length; i++)
                                   if (i < "| It's a draw!!! |".Length / 2)
                                      Console.Write('\\');
                                  else
                                      Console.Write('/');
                             Console.WriteLine();
                         }
            }

        }

    public static void ClearCurrentConsoleLine()   //------------------------------------------------------------------------------------------------------------this method helps me to clear the current line 
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
    public static void winnerPanel(string x)    //---------------------------------------------------------------------------------------------------------------this is the method who write the name of the winner in a panel
        {
            ClearCurrentConsoleLine();
            Console.SetCursorPosition((Console.WindowWidth - (x.Length + " is the winner!!!".Length + 4)) / 2, Console.CursorTop);
            Console.Write('o');
            for (int i = 0; i < x.Length + " is the winner!!!".Length + 2; i++)
                Console.Write('=');
            Console.WriteLine('o');
            Console.SetCursorPosition((Console.WindowWidth - (x.Length + " is the winner!!!".Length + 4)) / 2, Console.CursorTop);
            Console.WriteLine("H " + x + " is the winner!!! H");
            Console.SetCursorPosition((Console.WindowWidth - (x.Length + " is the winner!!!".Length + 4)) / 2, Console.CursorTop);
            Console.Write('o');
            for (int i = 0; i < x.Length + " is the winner!!!".Length + 2; i++)
                Console.Write('=');
            Console.WriteLine('o');
        }
    public static void downMeniu()          //-----------------------------------------------------------------------------------------------------------------this method creates a meniu after both players throw their dice
    {
            Console.SetCursorPosition((Console.WindowWidth - "1. Continue".Length) / 2, Console.CursorTop);
            Console.WriteLine("1. Continue");
            Console.SetCursorPosition((Console.WindowWidth - "2. Restart".Length) / 2, Console.CursorTop);
            Console.WriteLine("2. Restart");
            Console.SetCursorPosition((Console.WindowWidth - "3. Exit".Length) / 2, Console.CursorTop);
            Console.WriteLine("3. Exit");
            ConsoleKeyInfo r;
            do
            {
                r = Console.ReadKey();
                Console.Write("\b \b");
            }
            while (r.KeyChar != '1' && r.KeyChar != '2' && r.KeyChar != '3');
            if (r.KeyChar == '2')
                Choose.Restart();
            if (r.KeyChar == '3')
                Environment.Exit(0);
    }
    public static void PlayerTurn(Player x, int d)      //---------------------------------------------------------------------------------------------------this method makes the changes for the player's score,output the face of the die on the screen and the number of dice
    {
        ConsoleKeyInfo r = Console.ReadKey();                                                               //create a key that helps us to roll the dice
        Console.Write("\b \b");                                                                             //created a backspace that helps us to delete the last character written
        while (r.KeyChar != 'r')
        {
            r = Console.ReadKey();
            Console.Write("\b \b");
        }
        int i = x.dice.number;                                                                        //an integer that is modified instide of the number of the dice of the player
        int max = 0;                                                                                  //the maximum number between the dice rolled at the start of the turn is 0
        Random rndnumber = new Random();                                                              //random number that generate the face of the die
        while (i != 0)                                                                                //while the current number of dice of the player in the current turn is not 0
        {                                                                                             
            x.dice.shownumber = rndnumber.Next(1, 7);                                                 //giving the new number showed on the face of the die
            if (max < x.dice.shownumber)                                                              //if the number on the die is bigger than the last one
                max = x.dice.shownumber;                                                              //this number will become the max
            Console.SetCursorPosition((Console.WindowWidth - d) / 2, Console.CursorTop);              //positioning the three dice depending which player turn is
            for (int j = 0; j < x.dice.facedice[x.dice.shownumber - 1].Length; j++)                   //this for loop helps us to choose between the faces of the die from the die class and write it in the console
                {
                Console.Write(x.dice.facedice[x.dice.shownumber - 1][j]);
                if (j > 0 && (j + 1) % 9 == 0)
                {
                    Console.WriteLine();
                    Console.SetCursorPosition((Console.WindowWidth - d) / 2, Console.CursorTop);
                }
            }
            i--;
        }
        x.score += max;                                                                               //add to the player score the max number that turned up on one of the 3 dice
        x.dice.number--;                                                                              //the player lose a die at the final of it's turn
        }
    public static void AITurn(Player x)             //---------------------------------------------------------------------------------------------------this method makes the changes for the AI's score,output the face of the die on the screen and the number of dice
        {
        Stopwatch timer = new Stopwatch();                                                          //creating a stopwatch to stop any input from keyboard while the for loop is executing
            timer.Start();                                                                               
        int i = x.dice.number;                                                                      //an integer that is modified instide of the number of the dice of the AI
        int max = 0;                                                                                //the maximum number between the dice rolled at the start of the turn is 0
        Console.SetCursorPosition((Console.WindowWidth + 9) / 2, Console.CursorTop);                //positioning the throwing loading to the right
        Console.Write("Throwing");
        for(int j=0;j<3;j++)                                                                        //this is the loop for the three dots that gives the feeling that AI is throwing the dice
        {
            System.Threading.Thread.Sleep(250);                                                     //slow down the for loop for 250 ms each times 
            Console.Write(".");                                                                     //write the dot on the console
        }
        while (Console.KeyAvailable && timer.IsRunning==true)                                       //this while loop is helping me clear any key the user is pressing while the for loop is executing by checking if any key it's pressed and if the stopwatch is still running
        {
            ConsoleKeyInfo key = Console.ReadKey();                                                 //writing the key pressed 
            Console.Write("\b \b");                                                                 //this is a "backspace" created by going back one spot rewriting the key with a space and going again(i explained it better here because here was the first time when i used it)
        }
        for (int j = 0; j < 3; j++)                                                                 //cleaning the 3 dots 
        {
            Console.Write("\b \b");
        }
        timer.Stop();                                                                               //the stopwatch stops
        Random rndnumber = new Random();                                                            //random number that generate the face of the die
        while (i != 0)                                                                              //while the current number of dice of the AI in the current turn is not 0
        {                                                                                           //that means that the AI didn't throw all the dice yet
            x.dice.shownumber = rndnumber.Next(1, 7);                                               //giving the new number showed on the face of the die
            if (max < x.dice.shownumber)                                                            //if the number on the die is bigger than the last one 
                max = x.dice.shownumber;                                                            //this number will become the max
            Console.SetCursorPosition((Console.WindowWidth + 9) / 2, Console.CursorTop);            //positioning the three dice to the right
                for (int j = 0; j < x.dice.facedice[x.dice.shownumber - 1].Length; j++)             //this for loop helps us to choose between the faces of the die from the die class
            {
                Console.Write(x.dice.facedice[x.dice.shownumber - 1][j]);
                if (j > 0 && (j + 1) % 9 == 0)
                {
                    Console.WriteLine();
                    Console.SetCursorPosition((Console.WindowWidth + 9) / 2, Console.CursorTop);
                }
            }
            i--;
        }
        x.score += max;                                                                             //add to the AI score the max number that turned up on one of the 3 dice
        x.dice.number--;                                                                            //AI lose a die at the final of it's turn
    }
}
class Player   //======================================================================================================================================================the player class
    {
    public string name;                                                                             //the name of the player introduced by the user
    public int score = 0, points = 0;                                                               //the score and points of the player
    public Die dice = new Die();                                                                    //the dice of the player created with the help of the die class
    public bool turn = false;                                                                       //a bool that becomes true when it's the respective player turn
}
class Die     //======================================================================================================================================================the die class
    {
    public int number = 3;                      //number of dice , for the moment is 3
    public int shownumber;                      //the number you see on the die
    public string[] facedice = new string[]  { " _______ |       ||   o   ||       | ------- ",     //faces of the die starting from 1
                                               " _______ | o     ||       ||     o | ------- ",     //2
                                               " _______ | o     ||   o   ||     o | ------- ",     //3
                                               " _______ | o   o ||       || o   o | ------- ",     //4
                                               " _______ | o   o ||   o   || o   o | ------- ",     //5
                                               " _______ | o   o || o   o || o   o | ------- ",};   //6
    }
class TableScore  //======================================================================================================================================================the TableScore class where the table and all changes in it happens
    {
    static int tableLength = 0;                                                                     //length of the table, for the moment is 0
    static int Longer = 0;                                                                          // an integer that helps me to create the table by receving the longest word from the table
    public static void CreateTable(Player x, Player y) //---------------------------------------------------------------------------------------------------this method creates the length of the table
        {
        if (x.name.Length < "POINTS :  ".Length)                                                    //the length of the table is determined by comparing the 2 names and the "POINTS :  " string and takes the longest values between those 3
            if (y.name.Length < "POINTS :  ".Length)                                                //the length is calculated this way longer * 2 for the table to be equal in both parts
            {                                                                                       //   +  the length of the string "ROUND :  " from middle + 6( 2 from the frame of the table nad 4 spaces(2 after the left part of the frame,2 before the right frame of the table))
                tableLength = 2 * "POINTS :  ".Length + "ROUND :   ".Length + 6;
                Longer = "POINTS :  ".Length;
            }
            else
            {
                tableLength = 2 * y.name.Length + "ROUND :   ".Length + 6;
                Longer = y.name.Length;
            }
        else
            if (x.name.Length < y.name.Length)
            {
                tableLength = 2 * y.name.Length + "ROUND :   ".Length + 6;
                Longer = y.name.Length;
            }
            else
            {
                tableLength = 2 * x.name.Length + "ROUND :   ".Length + 6;
                Longer = x.name.Length;
            }
    }
    public static void showTableM(Player x, Player y, int currentRound)    //---------------------------------------------------------------------------------------------------this method creates the table for the match play mode
        {
        CreateTable(x, y);                                                                        //i'm using the previous method to determine the length
        StringBuilder createTop = new StringBuilder();                                            //creating the top frame of the table
        string top;
        createTop.Append('+');
        for (int i=1;i<tableLength-1;i++)
            createTop.Append('-');
        createTop.Append('+');
        top = createTop.ToString();
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        Console.WriteLine(top);
        RoundLine(currentRound);                                                                  // creating the round line using the method RoundLine
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        EmptyLine('-');                                                                           //an empty line that can be used as a line between the round and the rest of the table
        NameLine(x.name, y.name,x.turn,y.turn);                                                   //the line with the names of the players
        EmptyLine(' ');                                                                           //this time and empty line
        ScoreLine(x.score, y.score);                                                              //the score line where the score for both player is shown
        PointsLine(x.points, y.points);                                                           // the points line
        EmptyLine(' ');                                                                           //another emty line
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        Console.WriteLine(top);                                                                   // the end of the table

    }
    public static void showTableS(Player x, Player y, int currentRound)  //---------------------------------------------------------------------------------------------------this method creates the table for the score play mode
        {                                                                                                                                                                    //the same table but without the points line
            CreateTable(x, y);
            StringBuilder createTop = new StringBuilder();
            string top;
            createTop.Append('+');
            for (int i = 1; i < tableLength - 1; i++)
                createTop.Append('-');
            createTop.Append('+');
            top = createTop.ToString();
            Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
            Console.WriteLine(top);
            RoundLine(currentRound);
            Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
            EmptyLine('-');
            NameLine(x.name, y.name, x.turn, y.turn);
            EmptyLine(' ');
            ScoreLine(x.score, y.score);
            EmptyLine(' ');
            Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
            Console.WriteLine(top);

        }
    public static void EmptyLine(char c)    //---------------------------------------------------------------------------------------------------this method creates the empty line
        {
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        Console.Write("|");
        for (int i = 0; i < (tableLength - 2); i++)
            Console.Write(c);
        Console.WriteLine('|');
    }
    public static void RoundLine(int currentRound)  //---------------------------------------------------------------------------------------------------this method creates the round line
        {
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        Console.Write('|');
        for (int i = 0; i < (tableLength - 2 - "ROUND :   ".Length) / 2; i++)
            Console.Write(' ');
        int d = 0;
        if (currentRound > 9)
            d = 1;
        Console.Write("ROUND : " + currentRound);
        for (int i = 0; i < (tableLength - "ROUND :   ".Length) / 2-d; i++)
            Console.Write(' ');
        Console.WriteLine('|');
    }
    public static void NameLine(string name1, string name2, bool x, bool y)  //---------------------------------------------------------this method creates the name line and helps with the updating the same line
        {
        int arrow=0;
        if(x==true)
        {
            arrow = 2;                                                                                                  //int value that helps me with the positioning of the name(when it's one's player turn the arrow will move in the right of his name)
            Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
            Console.Write("|  " + name1+"<|");
        }
        else
        {
            Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
            Console.Write("|  " + name1);
        }
        for (int i = 0; i < ("ROUND :   ".Length + Longer-name1.Length-arrow) ; i++)
            Console.Write(' ');
        if (y == true)
        {
            Console.Write(name2 + "<|");
        }
        else
        {
            Console.Write(name2);
            arrow = 2;
        }
        for (int i = 0; i < (Longer-name2.Length+arrow); i++)
            Console.Write(' ');
        Console.WriteLine('|');
    }
    public static void UpdateNameLine(string x, string y , bool x1,bool y2, int d) //---------------------------------------------------------this method creates the name line and helps with the updating the same line
        {
        Console.SetCursorPosition(0, Console.CursorTop - 7 + d);
        Game.ClearCurrentConsoleLine();
        NameLine(x,y,x1,y2);
        Console.SetCursorPosition(0, Console.CursorTop + 7 - d);
    }
    public static void ScoreLine(int score1, int score2)   //-----------------------------------------------------------------------------this method creates the score line depending of the score number( if the number contain 1 or 2 digits )
    {
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        int digits = "SCORE :   ".Length;
        if (score1 <= 9)
            Console.Write("|  SCORE :  " + score1);
        else
            Console.Write("|  SCORE : " + score1);
        for (int i = 0; i < ("ROUND :   ".Length + Longer - digits); i++)
            Console.Write(' ');
        digits = "SCORE :   ".Length-2;
        if (score2 <= 9)
            Console.Write("SCORE :  " + score2);
        else
            Console.Write("SCORE : " + score2);
        for (int i = 0; i < (Longer - digits); i++)
            Console.Write(' ');
        Console.WriteLine('|');
    }
    public static void UpdateScoreLine(Player x, Player y,  int d)   //--------------------------------------------------------------------depenting of the number of dice that the player had and who's turn this method update the name line
    {                                                                                                                   
        int dice = 0;           
        if (x.turn == true)
            dice = x.dice.number + 1;
        else
            dice = y.dice.number + 1;
        Console.SetCursorPosition(0, Console.CursorTop - (5 * dice + 6) + d);                                                //d value helps me to determine which type of game the player choose (the values that d can take are 0 or 1 because the matchplay has a line in plus because of the points line )
        Game.ClearCurrentConsoleLine();
        ScoreLine(x.score, y.score);
        Console.SetCursorPosition(0, Console.CursorTop + (5 * dice + 6) -d);
    }
    public static void PointsLine(int points1, int points2)  //-----------------------------------------------------------------------------this method creates the points line 
        {
        Console.SetCursorPosition((Console.WindowWidth - tableLength) / 2, Console.CursorTop);
        Console.Write("|  POINTS : " + points1);
        for (int i = 0; i < ("ROUND :   ".Length + Longer - "POINTS :  ".Length); i++)
            Console.Write(' ');
        Console.Write("POINTS : " + points2);
        for (int i = 0; i < (Longer - "POINTS :  ".Length + 2); i++)
            Console.Write(' ');
        Console.WriteLine('|');
    }
    public static void UpdatePointsLine(Player x, Player y, int d)  //-----------------------------------------------------------------------------this method creates the points line depending this time of how's turn is AI's or player's
        {
            Console.SetCursorPosition(0, Console.CursorTop - 4 + d);
            Game.ClearCurrentConsoleLine();
            PointsLine(x.points, y.points);
            Console.SetCursorPosition(0, Console.CursorTop + 3 - d);
    }
}
}

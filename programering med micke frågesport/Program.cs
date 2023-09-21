int points = 0;
int questionNum = 0;
string answer;

var random = new Random();

//Creates an array of questions with their answers. Makes it much easier to use a question and to check if the player's answer is correct
//Also makes it a lot easier to add a question
string[][] questions = {
    new string[] {"\n    Which city is the capital of sweden? \na) Malmö \nb) Stockholm \nc) Gothenburg", "b"},
    new string[] {"\n2+2? \na) 1 \nb) 2 \nc) 4", "c"},
    new string[] {"\nWhat does NTI stand for? \na) Nordic Institute of Technology or in Swedish 'Nordens Teknikerinstitut' \nb) National tea institute \nc) No one knows", "a"},
    new string[] {"\nHow many people live in Sweden \na) 1 million \nb) 10 million \nc) 100 million", "b"}
};

//Randomizes the questions
questions = questions.OrderBy(x => random.Next()).ToArray();

Console.WriteLine(" Hello and welcome to my quiz.\n\n Press a, b, or c and enter to answer/continue");
Console.ReadLine();
//The actual quiz game. Uses an integer to select the question and the answer it should be checking for (question & correct)
void askQuestion(string question, string correct)
{
    answer = null;


    //Asks the question and reads the player's answer. Repeats if the player's input isn't a, b, c or d
    do
    {
        Console.WriteLine($"\nQuestion {questionNum + 1}. {question}");
        answer = Console.ReadLine().Trim().ToLower(); //Saves the answer and removes whitespaces before and after the actual answer
    } while (answer != "a" && answer != "b" && answer != "c");

    if (answer == correct)
    {
        Console.WriteLine("\nRight answer +1 point");
        points += 1;
    }
    else
    {
        Console.WriteLine("wrong answer, better luck on the next one");
    }

    questionNum += 1;


    //Ends the game if questionNum is bigger than the amount of questions 
    if (questionNum >= questions.Count())
    {
        Console.WriteLine($"\nHow many points did you get... \n\n{points} points!");

        if (points == 0)
        {
            Console.WriteLine("Better luck next time");
        }else if (points == 1)
        {
            Console.WriteLine($"You did get one right at least");
        }else if (points == 2)
        {
            Console.WriteLine($"You got 50% right");
        }else if (points == 3)
        {
            Console.WriteLine("More than half at lest");
        }else if (points == 4)
        {
            Console.WriteLine("Full pot");
        }

        
    }
    else
    {
        //Continues if it isn't
        askQuestion(questions[questionNum][0], questions[questionNum][1]);
    }
}

//Asks the first question
askQuestion(questions[questionNum][0], questions[questionNum][1]);



Console.ReadLine();

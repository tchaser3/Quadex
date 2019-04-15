using System;

namespace QuadexTest
{
    class Program
    {
        //setting up the global variables
        private static int gintNumberOfTries = 0;
        private static string gstrNewNumber;
        private static bool gblnFirstTime = true;
        private static bool gblnAnswerCorrect = false;
        private static string gstrUserInput;
        private static string gstrProgramOutput;

        static void Main(string[] args)
        {
            //setting local variables
            bool blnFatalError = true;
                        
            while (gblnAnswerCorrect == false)
            {
                //creating the random number by calling the method
                if (gblnFirstTime == true)
                {
                    GenerateRandomNumber();
                }

                //getting input from user
                while(blnFatalError == true)
                {
                    Console.WriteLine("Please Enter a 4 Digit Number with Each Character having the value of \n between 0 and 6");
                    gstrUserInput = Console.ReadLine();

                    //validationg that the inputted number is correct
                    blnFatalError = ValidateNumber(gstrUserInput);

                    if(blnFatalError == true)
                    {
                        Console.WriteLine(gstrUserInput + " Contains Numbers that are not between 1 and 6");
                    }
                }

                //setting global variable
                gstrProgramOutput = "";

                //calling method
                CheckAnswer();
                
                //checking to see if the answer is correct
                if(gblnAnswerCorrect == true)
                {
                    Console.WriteLine("Your Answer Is correct");
                }
                else
                {
                    Console.WriteLine("Your Answer Is Incorrect " + gstrProgramOutput);

                    gintNumberOfTries++;

                    if(gintNumberOfTries == 10)
                    {
                        Console.WriteLine("You Have Reached Your Max Number Of Tries");
                        gblnAnswerCorrect = true;
                    }

                    Console.WriteLine("This Was Try Number " + Convert.ToString(gintNumberOfTries));

                    blnFatalError = true;
                }
            }
        }
        private static void CheckAnswer()
        {
            //this method checks the answer.
            //setting local variables
            int intCounter;
            int intNumberForVerification;
            int intNumberFromRandomGenerator;
            int intSecondCounter;

            //checking answer
            if(gstrUserInput == gstrNewNumber)
            {
                gblnAnswerCorrect = true;
            }
            else
            {
                for(intCounter = 0; intCounter < 4; intCounter++)
                {
                    intNumberForVerification = Convert.ToInt32(gstrUserInput.Substring(intCounter, 1));

                    intNumberFromRandomGenerator = Convert.ToInt32(gstrNewNumber.Substring(intCounter, 1));

                    if(intNumberFromRandomGenerator == intNumberForVerification)
                    {
                        gstrProgramOutput += "+";
                    }
                    else
                    {
                        for(intSecondCounter = 0; intSecondCounter < 4; intSecondCounter++)
                        {
                            intNumberFromRandomGenerator = Convert.ToInt32(gstrNewNumber.Substring(intSecondCounter, 1));

                            if (intNumberFromRandomGenerator == intNumberForVerification)
                            {
                                gstrProgramOutput += "-";
                            }
                        }
                    }
                }
            }
        }
        private static bool ValidateNumber(string strUserInput)
        {
            bool blnFatalError = false;
            int intNumberForChecking;
            int intCounter;

            try
            {
                for (intCounter = 0; intCounter < 4; intCounter++)
                {
                    intNumberForChecking = Convert.ToInt32(strUserInput.Substring(intCounter, 1));

                    if ((intNumberForChecking < 1) || (intNumberForChecking > 6))
                    {
                        blnFatalError = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private static void GenerateRandomNumber()
        {
            Random intRandomNumber = new Random();
            int intFirstNumber;
            int intSecondNumber;
            int intThirdNumber;
            int intForthNumber;

            intFirstNumber = intRandomNumber.Next(1, 6);
            intSecondNumber = intRandomNumber.Next(1, 6);
            intThirdNumber = intRandomNumber.Next(1, 6);
            intForthNumber = intRandomNumber.Next(1, 6);

            gstrNewNumber = Convert.ToString(intFirstNumber) + Convert.ToString(intSecondNumber) + Convert.ToString(intThirdNumber) + Convert.ToString(intForthNumber);

            gblnFirstTime = false;
        }
    }
}
 
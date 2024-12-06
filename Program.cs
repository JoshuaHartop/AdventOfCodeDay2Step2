using System;
using System.Globalization;

class AdventOfCodeDay2
{
    List<string> listOfInputs = [];
    string listPath = @"..\..\..\TextFile\LIST.txt";
    List<string> currentLine = [];
    List<int> splitCurrentLine = [];
    List<string> currentDigits = [];
    int previousNum;
    int safeReports = 0;

    int problemDampener = 0;
    bool descendAscend; // false = down true = up
    static void Main()
    {
        AdventOfCodeDay2 program = new AdventOfCodeDay2();
        program.CheckLevelSafety();
        Console.WriteLine("Total safe reports: " + program.safeReports);
    }

    void CheckLevelSafety()
    {
        listOfInputs = new List<string>(File.ReadAllLines(listPath));
        for (int i = 0; i < listOfInputs.Count; i++)
        {
            
            currentLine.Add(listOfInputs[i]);
            
            foreach (string value in currentLine[0].Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                splitCurrentLine.Add(Int32.Parse(value));
            }
            Console.WriteLine("current line: " + splitCurrentLine[0] + ", " + splitCurrentLine[1]);
            previousNum = splitCurrentLine[1];
            if (CheckFirstTwo(splitCurrentLine))
            {
                for (int j = 2; j < splitCurrentLine.Count; j++)
                {
                    
                    if(problemDampener <= 1) 
                    {
                        if (splitCurrentLine[j] < previousNum && descendAscend == false && 1 <= Math.Abs(previousNum - splitCurrentLine[j]) && Math.Abs(previousNum - splitCurrentLine[j]) <= 3)
                        {
                            previousNum = splitCurrentLine[j];
                        }
                        else if (splitCurrentLine[j] > previousNum && descendAscend == true && 1 <= Math.Abs(previousNum - splitCurrentLine[j]) && Math.Abs(previousNum - splitCurrentLine[j]) <= 3)
                        {
                            previousNum = splitCurrentLine[j];

                        }
                        else
                        {
                            problemDampener++;
                        }
                        if (j == splitCurrentLine.Count - 1)
                        {
                            safeReports++;
                        }
                    }
                    else {
                        problemDampener = 0;
                        break;
                    }
                       
                    
                }
                
            }
            splitCurrentLine.Clear();
            currentLine.Clear();
        }
        
    }

    bool CheckFirstTwo(List<int> list)
    {
        if (splitCurrentLine[0] < splitCurrentLine[1] && 1 <= Math.Abs(splitCurrentLine[0] - splitCurrentLine[1]) && Math.Abs(splitCurrentLine[0] - splitCurrentLine[1]) <= 3)
        {
            
            descendAscend = true;
            return true;
        }
        else if (splitCurrentLine[0] > splitCurrentLine[1] && 1 <= Math.Abs(splitCurrentLine[0] - splitCurrentLine[1]) && Math.Abs(splitCurrentLine[0] - splitCurrentLine[1]) <= 3)
        {
            
            descendAscend = false;
            return true;
        }
        else
        {
            
            return false;
        }
    }
}
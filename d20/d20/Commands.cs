using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace d20
{
    class Commands : Program
    {
        SyntaxValidation sv = new SyntaxValidation();

        

        public void save()
        {
            for (int i = 0; i < sv.sytaxReader.Count - 1; i++)
                if (sv.sytaxReader[i].Equals("s") && sv.sytaxReader[i + 1].Equals("{"))
                {
                    sv.sytaxReader.RemoveAt(i + 1);
                    sv.sytaxReader.RemoveAt(i);
                }
                else if (sv.sytaxReader[i].Equals("s{"))
                {
                    sv.sytaxReader.RemoveAt(i);
                }
            sv.sytaxReader.RemoveAt(sv.sytaxReader.Count);

            int count = 0;
            //regex???            
        }

        public int getDiceRoll(int input)
        {
            int result = 0;
            try
            {
                //fix this
                int i = 0;
                i = Convert.ToInt32(input);
                switch (i)
                {
                    case 4:
                        int max = random.Next(1, 5);
                        result = max;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    case 6:
                        int max1 = random.Next(1, 7);
                        result = max1;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max1);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    case 8:
                        int max2 = random.Next(1, 9);
                        result = max2;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max2);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    case 10:
                        int max3 = random.Next(1, 11);
                        result = max3;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max3);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    case 12:
                        int max4 = random.Next(1, 13);
                        result = max4;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max4);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    case 20:
                        int max5 = random.Next(1, 21);
                        result = max5;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max5);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    case 100:
                        int max6 = random.Next(0, 101);
                        result = max6;
                        if (!cancel_Log)
                        {
                            listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " was used and got a Natural: " + max6);
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                    default:
                        if (i > 1)
                        {
                            string str;
                            Console.WriteLine("would you to make this a coustom dice?");
                            while (true)
                            {
                                str = Console.ReadLine();
                                if (sv.ValInput_YN(str))
                                {
                                    if (sv.get_YN(str))
                                    {
                                        int maxU = random.Next(1, i);
                                        result = maxU;
                                        listDiceResults.Add(listDiceResults.Count + 1 + ":d" + i + " (Custom Dice) was used and got a Natural: " + maxU);
                                        listInputLog.Add(listInputLog.Count + 1 + ":" + input);

                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Input, try n/no or y/yes");
                                    Console.WriteLine("\n\nwould you to make this a coustom dice?");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            listInputLog.Add(listInputLog.Count + 1 + ":" + input);
                        }
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Input...\n");
                listInputLog.Add(listInputLog.Count + 1 + ":" + input);
            }
            return result;
        }

        public int addEquation(string input)
        {
            int modifier, diceRoll, result, count = 0;
            string str1 = "", str2 = "";
            char[] ch = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (ch[i] == '+') { count++; continue; }
                if (count == 0) str1 += ch[i];//dice
                if (count == 1) str2 += ch[i];//modifer
            }
            modifier = Convert.ToInt32(str2);
            diceRoll = Convert.ToInt32(str1);
            cancel_Log = true;
            diceRoll = getDiceRoll(diceRoll);
            cancel_Log = false;

            if (diceRoll > 0)
            {

                result = diceRoll + modifier;

                Console.WriteLine("The orgional dice roll: " + diceRoll);

                listDiceResults.Add(listDiceResults.Count + 1 + ":d" + str1 + " was used and got a Natural: " + diceRoll + "[" + listDiceResults.Count + 1 + ":with the modifier of: " + result + "]");
            }
            else
            {
                result = 0;
                Console.WriteLine("Equation Cancellrd, result dice: " + result);
            }
            return result;
        }

        public int subEquation(string input)
        {
            int modifier, diceRoll, result, count = 0;
            string str1 = "", str2 = "";
            char[] ch = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (ch[i] == '-') { count++; continue; }
                if (count == 0) str1 += ch[i];//dice
                if (count == 1) str2 += ch[i];//modifier
            }
            modifier = Convert.ToInt32(str2);
            diceRoll = Convert.ToInt32(str1);
            diceRoll = -diceRoll;
            cancel_Log = true;
            diceRoll = getDiceRoll(diceRoll);
            cancel_Log = false;

            if (diceRoll > 0)
            {
                Console.WriteLine("The orgional dice roll: " + diceRoll);

                result = diceRoll - modifier;
                listDiceResults.Add(listDiceResults.Count + 1 + ":d" + str1 + " was used and got a Natural: " + diceRoll + "[" + listDiceResults.Count + 1 + ":with the modifier of: " + result + "]");
            }
            else
            {
                result = 0;
                Console.WriteLine("Equation Cancellrd, result dice: " + result);
            }

            return result;
        }

    }
}

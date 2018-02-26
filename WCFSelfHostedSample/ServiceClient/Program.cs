using ServiceClient.VariableServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceClient
{
    class Program
    {
        private static VariableServiceClient _variableServiceClient;

        static void Main(string[] args)
        {
            _variableServiceClient = new VariableServiceClient();

            var timer = new Timer
            {
                Interval = 2000
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Console.ReadLine();

            timer.Stop();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            
            VariableData[] allVariableData = _variableServiceClient.GetAllVariables();
            Array.Sort(allVariableData, (x, y) => string.Compare(x.Name, y.Name));
            Console.WriteLine("{0} --- {1} --- {2} --- {3}", FormatString("VariableID", 10, true), FormatString("Name", 30, true), FormatString("Value",20, true), FormatString("Timestamp",10, true));

            foreach (VariableData elem in allVariableData)
            {
                Console.WriteLine("{0}     {1}     {2}     {3} ", FormatString(elem.VariableId, 10), FormatString(elem.Name, 30), FormatString(elem.Value.ToString(), 20), FormatString(elem.TimestampSeconds.ToShortDateString(), 10));
            }

        }

        private static string FormatString(string text, int maxLength, bool center = false)
        {
            if (text.Length <= maxLength)
            {
                if (center == true)
                {
                    var paddingLeft = (maxLength - text.Length) / 2;
                    var paddingRight = maxLength - text.Length - paddingLeft;
                    return string.Format("{0," + paddingLeft + "}{1}{2," + paddingRight + "}", "", text, "");
                }
                else
                {
                    return string.Format("{0," + maxLength + "}", text);
                }
            }
            else
            {
                var lengthPart = (maxLength - 2) / 2;
                return string.Format("{0," + lengthPart + "}..{1," + lengthPart + "}", text.Substring(0, lengthPart), text.Substring(text.Length - lengthPart));
            }

        }

    }
}

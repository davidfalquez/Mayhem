using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mayhem.DTO;

namespace Mayhem.Logic
{
    public class PointSystem
    {
        static string _Correct = "Correct";
        static string _Minor = "Minor";
        static string _Yes = "Yes";
        static int _TotalFormAPoints = 180;
        static int _TotalFormBPoints = 189;
        
        public static decimal PointTabulation(PrimaryFormPoints input)
        {
            decimal formScore = PointTabulationTotalScore(input);

            formScore = ConvertToPercentage(formScore, _TotalFormAPoints);

            return formScore;
        }

        public static int PointTabulationTotalScore(PrimaryFormPoints input)
        {
            int formScore = 0;

            if (input.ToneAlertUsed)
            {
                formScore += 10;
            }
            if (input.Priority)
            {
                formScore += 10;
            }
            if (input.SunstarThreeDigitUnit)
            {
                formScore += 10;
            }
            if (input.Location)
            {
                formScore += 10;
            }
            if (input.MapGrid)
            {
                formScore += 20;
            }
            if (input.NatureOfCall)
            {
                formScore += 20;
            }
            if (input.SsTacChannel)
            {
                formScore += 20;
            }
            if (input.DisplayedServiceAttitude == _Correct)
            {
                formScore += 25;
            }
            if (input.DisplayedServiceAttitude == _Minor)
            {
                formScore += 10;
            }
            if (input.UsedCorrectVolTone == _Correct)
            {
                formScore += 25;
            }
            if (input.UsedCorrectVolTone == _Minor)
            {
                formScore += 10;
            }
            if (input.UsedProhibitedBehavior)
            {
                formScore += 30;
            }
            return formScore;
        }
        
        public static decimal PointTabulation(SecondaryFormPoints input)
        {
            decimal formScore = PointTabulationTotalScore(input);

            formScore = ConvertToPercentage(formScore, _TotalFormBPoints);

            return formScore;
        }

        public static int PointTabulationTotalScore(SecondaryFormPoints input)
        {
            int formScore = 0;

            if (input.SunstarThreeDigitUnit)
            {
                formScore += 10;
            }
            if (input.NatureOfCall)
            {
                formScore += 10;
            }
            if (input.Location)
            {
                formScore += 10;
            }
            if (input.MapGrid)
            {
                formScore += 10;
            }
            if (input.FdUnitAndTacCh)
            {
                formScore += 5;
            }
            if (input.Documented1)
            {
                formScore += 5;
            }
            if (input.SevMin)
            {
                formScore += 8;
            }
            if (input.TwelveMin)
            {
                formScore += 8;
            }
            if (input.EtaLocationAsked)
            {
                formScore += 8;
            }
            if (input.Documented2)
            {
                formScore += 5;
            }
            if (input.ProactiveRoutingGiven == _Yes)
            {
                formScore += 5;
            }
            if (input.CorrectRouting == _Yes)
            {
                formScore += 5;
            }
            if (input.Documented3)
            {
                formScore += 5;
            }
            if (input.PreArrivalGiven)
            {
                formScore += 10;
            }
            if (input.Documented4)
            {
                formScore += 5;
            }
            if (input.DisplayedServiceAttitude == _Correct)
            {
                formScore += 25;
            }
            if (input.DisplayedServiceAttitude == _Minor)
            {
                formScore += 10;
            }
            if (input.UsedCorrectVolTone == _Correct)
            {
                formScore += 25;
            }
            if (input.UsedCorrectVolTone == _Minor)
            {
                formScore += 10;
            }
            if (input.UsedProhibitedBehavior)
            {
                formScore += 30;
            }
            return formScore;
        }

        public static decimal ConvertToPercentage(decimal formScore, int totalPoints)
        {
            formScore = (formScore * 100) / totalPoints;

            return formScore;
        }

    }
}

﻿using System;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Definitions;

namespace Microsoft.Recognizers.Text.Sequence.English
{
    public class GUIDParser : BaseSequenceParser
    {
        private static double scoreUpperLimit = 100;
        private static double scoreLowerLimit = 0;
        private static double baseScore = 100;
        private static double noBoundaryPenalty = 10;
        private static double noFormatPenalty = 10;
        private static double pureDigitPenalty = 15;
        private static string pureDigitRegex = @"^\d*$";
        private static string formatRegex = @"-";

        public GUIDParser()
        {

        }

        double ScoreGUID(string GUIDText)
        {
            double score = baseScore;

            Regex guidElementRegex = new Regex(BaseGUID.GUIDRegexElement);
            Match elementMatch = guidElementRegex.Match(GUIDText);
            if (elementMatch.Success)
            {
                int startIndex = elementMatch.Groups[1].Index;
                string elementGUID = elementMatch.Groups[1].Value;
                score -= startIndex == 0 ? noBoundaryPenalty : 0;
                score -= Regex.IsMatch(elementGUID, formatRegex) ? 0 : noFormatPenalty;
                score -= Regex.IsMatch(GUIDText, pureDigitRegex) ? pureDigitPenalty : 0;
            }
            return Math.Max(Math.Min(score, scoreUpperLimit), scoreLowerLimit) / (scoreUpperLimit - scoreLowerLimit);
        }

        public override ParseResult Parse(ExtractResult extResult)
        {
            var result = new ParseResult
            {
                Start = extResult.Start,
                Length = extResult.Length,
                Text = extResult.Text,
                Type = extResult.Type,
                ResolutionStr = extResult.Text,
                Value = ScoreGUID(extResult.Text)
            };
            return result;
        }
    }
}
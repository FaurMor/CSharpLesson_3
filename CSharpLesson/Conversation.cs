using System;

namespace CSharpLesson
{
    public static class Conversation
    {
        private const float MaxDiff = 9.0f;
        public static bool GetConservateResult(IConversate conversator, IConversate conversatable)
        {
            float conversatorDiff = conversator.Outlook.GetOutlookEquivalent();
            float conversatableDiff = conversatable.Outlook.GetOutlookEquivalent();
            double chance = 1 - GetDifferenceBetween(conversatorDiff, conversatableDiff) / MaxDiff;
            Random random = new Random();
            double randomDouble = random.NextDouble();
            return randomDouble < chance;
        }

        private static float GetDifferenceBetween(float first, float second)
            => Math.Abs(first - second);
    }
}

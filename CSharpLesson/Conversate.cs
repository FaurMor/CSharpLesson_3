using System;

namespace CSharpLesson
{
    public class Conversate
    {
        private const float MaxDiff = 9.0f;
        public bool GetConversateResult(IConversator conversator, IConversatable conversatable)
        {
            float conversatorDiff = conversator.Outlook.OutlookEquivalent;
            float conversatableDiff = conversatable.Outlook.OutlookEquivalent;
            double chance = 1 - GetDifferenceBetween(conversatorDiff, conversatableDiff) / MaxDiff;
            Random random = new Random();
            double randomDouble = random.NextDouble();
            return randomDouble < chance;
        }

        private float GetDifferenceBetween(float first, float second)
            => Math.Abs(first - second);
    }
}

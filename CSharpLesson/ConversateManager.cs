using System;

namespace CSharpLesson
{
    public class ConversateManager
    {
        private const float MaxDiff = 9.0f;
        public bool GetConversateResult(IConversate conversator, IConversate conversatable)
        {
            float conversatorDiff = conversator.Outlook.GetOutlookEquivalent();
            float conversatableDiff = conversatable.Outlook.GetOutlookEquivalent();
            double chance = 1 - GetDifferenceBetween(conversatorDiff, conversatableDiff) / MaxDiff;
            Random random = new Random();
            double randomDouble = random.NextDouble();
            return randomDouble < chance;
        }

        private float GetDifferenceBetween(float first, float second)
            => Math.Abs(first - second);
    }
}

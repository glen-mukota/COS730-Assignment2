using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    internal class EvaluationManager
    {
        private Database database = new Database();
        private DecisionEngine decisionEngine = new DecisionEngine();

        public void StartEvaluation(List<Reviewer> reviewers)
        {
            List<int> scores = new List<int>();

            // loop each reviewer → ONLY responsibility
            foreach (var reviewer in reviewers)
            {
                int score = reviewer.SubmitScore();

                database.SaveScore(score);

                scores.Add(score);
            }

            // delegate decision-making (OPTIMISED)
            decisionEngine.EvaluateOutcome(scores);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Assignment2_Optimized
{
    internal class SubmissionController
    {
        private Validator validator = new Validator();
        private Database database = new Database();
        private ReviewerManager reviewerManager = new ReviewerManager();
        private EvaluationManager evaluationManager = new EvaluationManager();

        public void Submit(string data)
        {
            // Validation
            bool isValid = validator.ValidateFormat(data);

            if (!isValid)
            {
                new UI().ReturnError();
                return;
            }

            // Persistence
            database.SaveSubmission(data);

            // Reviewer selection (OPTIMISED)
            List<Reviewer> reviewers = reviewerManager.GetEligibleReviewers();

            // Assign reviewers
            foreach (var reviewer in reviewers)
            {
                reviewer.AssignReview();
            }

            // Start evaluation (delegates decision)
            evaluationManager.StartEvaluation(reviewers);
        }
    }
}
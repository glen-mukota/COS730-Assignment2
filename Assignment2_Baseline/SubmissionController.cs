using System.Collections.Generic;

namespace Assignment2_Baseline
{
    internal class SubmissionController
    {
        private Validator validator = new Validator();
        private Database database = new Database();
        private ReviewerManager reviewerManager = new ReviewerManager();
        private EvaluationManager evaluationManager = new EvaluationManager();

        public void Submit(string data)
        {
            // validateFormat(data)
            bool isValid = validator.ValidateFormat(data);

            // alt [invalid]
            if (!isValid)
            {
                new UI().ReturnError();
                return;
            }

            // saveSubmission(data)
            database.SaveSubmission(data);

            // getAvailableReviewers()
            List<Reviewer> reviewers = reviewerManager.GetAvailableReviewers();

            // loop assign reviewers
            foreach (var reviewer in reviewers)
            {
                reviewer.AssignReview();
            }

            // startEvaluation()
            evaluationManager.StartEvaluation(reviewers);
        }
    }
}
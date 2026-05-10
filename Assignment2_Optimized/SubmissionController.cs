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
            // 1. Validate.
            if (!validator.ValidateFormat(data))
            {
                new UI().ReturnError();
                return;
            }

            // 2. Persist.
            database.SaveSubmission(data);

            // 3. Obtain eligible reviewers (optimised single‑pass filtering).
            List<Reviewer> reviewers = reviewerManager.GetEligibleReviewers();

            // 4. Assign reviewers.
            foreach (var reviewer in reviewers)
            {
                reviewer.AssignReview();
            }

            // 5. Launch evaluation.
            evaluationManager.StartEvaluation(reviewers);
        }
    }
}
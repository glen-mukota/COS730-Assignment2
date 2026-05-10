using System.Collections.Generic;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Orchestrates the entire submission workflow: validation, persistence,
    /// reviewer assignment, and evaluation.
    /// </summary>
    internal class SubmissionController
    {
        private Validator validator = new Validator();
        private Database database = new Database();
        private ReviewerManager reviewerManager = new ReviewerManager();
        private EvaluationManager evaluationManager = new EvaluationManager();

        /// <summary>
        /// Processes a raw research output string.
        /// </summary>
        /// <param name="data">The submission data to validate and process.</param>
        public void Submit(string data)
        {
            // 1. Validate the input format.
            if (!validator.ValidateFormat(data))
            {
                new UI().ReturnError();
                return;
            }

            // 2. Persist the valid submission.
            database.SaveSubmission(data);

            // 3. Obtain a conflict‑free, workload‑checked list of reviewers.
            List<Reviewer> reviewers = reviewerManager.GetAvailableReviewers();

            // 4. Assign the selected reviewers.
            foreach (var reviewer in reviewers)
            {
                reviewer.AssignReview();
            }

            // 5. Run the evaluation process.
            evaluationManager.StartEvaluation(reviewers);
        }
    }
}
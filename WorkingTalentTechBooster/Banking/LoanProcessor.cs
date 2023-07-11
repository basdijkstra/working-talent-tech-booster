namespace WorkingTalentTechBooster.Banking
{
    public class LoanProcessor
    {
        public static LoanApplicationResult ProcessLoanApplication(LoanApplication loanApplication)
        {
            if (loanApplication.DownPayment < 0)
            {
                throw new ArgumentException("You cannot provide a negative down payment");
            }

            if (loanApplication.Amount > 1000000)
            {
                throw new ArgumentException("You cannot apply for a loan over $1,000,000");
            }

            if (loanApplication.Amount / loanApplication.DownPayment > 10)
            {
                return LoanApplicationResult.Denied;
            }

            return LoanApplicationResult.Approved;
        }
    }
}

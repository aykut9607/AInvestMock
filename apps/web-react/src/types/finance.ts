export interface FinancialProfileFormData {
  //Inputs
  monthlyIncome: string;
  monthlyExpenses: string;
  monthlyDebtPayment: string;
  totalDebt: string;
  cashReserve: string;
  investmentAmount: string;
  riskPreference: "LOW" | "MEDIUM" | "HIGH";
}


export interface FinancialScoreResult {
//Outputs
  score: number;
  segment: "STRONG" | "BALANCED" | "NEEDS_IMPROVEMENT" | "HIGH_RISK";
  warnings: string[];
  factors: string[];
}

/*80-100 → STRONG
60-79  → BALANCED
40-59  → NEEDS_IMPROVEMENT
0-39   → HIGH_RISK */
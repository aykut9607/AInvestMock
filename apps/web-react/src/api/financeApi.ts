import type {
  FinancialProfileFormData,
  FinancialScoreResult,
} from "../types/finance";

export async function calculateFinancialScore(
  form: FinancialProfileFormData
): Promise<FinancialScoreResult> {
  const monthlyIncome = Number(form.monthlyIncome);
  const monthlyExpenses = Number(form.monthlyExpenses);
  const monthlyDebtPayment = Number(form.monthlyDebtPayment);
  const totalDebt = Number(form.totalDebt);
  const cashReserve = Number(form.cashReserve);
  const investmentAmount = Number(form.investmentAmount);

  if (monthlyIncome <= 0) {
    return {
      score: 0,
      segment: "HIGH_RISK",
      warnings: ["Monthly income must be greater than zero."],
      factors: [],
    };
  }

  const debtPaymentRatio = monthlyDebtPayment / monthlyIncome;
  const spendingRatio = monthlyExpenses / monthlyIncome;

  const monthlyRequiredAmount = monthlyExpenses + monthlyDebtPayment;

  const cashReserveMonths =
    monthlyRequiredAmount > 0 ? cashReserve / monthlyRequiredAmount : 0;

  const monthlyAvailableAmount =
    monthlyIncome - monthlyExpenses - monthlyDebtPayment;

  const totalDebtToAnnualIncomeRatio = totalDebt / (monthlyIncome * 12);

  let score = 70;
  const warnings: string[] = [];
  const factors: string[] = [];

  if (debtPaymentRatio > 0.4) {
    score -= 25;
    warnings.push("Debt payment ratio is high.");
  } else {
    factors.push("Debt payment ratio is manageable.");
  }

  if (spendingRatio > 0.7) {
    score -= 20;
    warnings.push("Monthly expenses are high compared to income.");
  } else {
    factors.push("Spending level is acceptable.");
  }

  if (cashReserveMonths < 2) {
    score -= 20;
    warnings.push("Cash reserve is low.");
  } else {
    factors.push("Cash reserve is acceptable.");
  }

  if (totalDebtToAnnualIncomeRatio > 1.5) {
    score -= 10;
    warnings.push("Total debt is high compared to annual income.");
  } else {
    factors.push("Total debt level is acceptable compared to annual income.");
  }

  if (investmentAmount > monthlyAvailableAmount) {
    score -= 10;
    warnings.push(
      "Planned investment amount is higher than monthly available amount."
    );
  } else if (investmentAmount > 0) {
    factors.push(
      "Planned investment amount is compatible with available monthly cash flow."
    );
  }

  if (form.riskPreference === "HIGH") {
    score -= 5;
    warnings.push("High risk preference requires careful planning.");
  }

  if (score < 0) {
    score = 0;
  }

  let segment: FinancialScoreResult["segment"];

  if (score >= 80) {
    segment = "STRONG";
  } else if (score >= 60) {
    segment = "BALANCED";
  } else if (score >= 40) {
    segment = "NEEDS_IMPROVEMENT";
  } else {
    segment = "HIGH_RISK";
  }

  await new Promise((resolve) => setTimeout(resolve, 700));

  return {
    score,
    segment,
    warnings,
    factors,
  };
}
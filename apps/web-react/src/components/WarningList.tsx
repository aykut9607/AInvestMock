import type { FinancialScoreResult } from "../types/finance";

interface WarningListProps {
  result: FinancialScoreResult | null;
}

function WarningList({ result }: WarningListProps) {
  if (result === null) {
    //strict null check.(5==="5"): return false for example
    return null;
  }

  return (
    <div>
      <h2>Analysis Details</h2>

      <div>
        <h3>Warnings</h3>

        {result.warnings.length === 0 ? (
          <p>No major warnings.</p>
        ) : (
          <ul>
            {result.warnings.map((warning) => (
              <li key={warning}>{warning}</li>
            ))}
          </ul>
        )}
      </div>

      <div>
        <h3>Positive Factors</h3>

        {result.factors.length === 0 ? (
          <p>No positive factors detected.</p>
        ) : (
          <ul>
            {result.factors.map((factor) => (
              <li key={factor}>{factor}</li>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
}

export default WarningList;
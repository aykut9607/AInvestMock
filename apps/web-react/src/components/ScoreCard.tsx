import type { FinancialScoreResult } from "../types/finance";

interface ScoreCardProps {
  result: FinancialScoreResult | null;
}

function ScoreCard({ result }: ScoreCardProps) {
  if (result === null) {
    return null;
  }

  return (
    <div>
      <h2>Financial Score Result</h2>

      <p>
        <strong>Score:</strong> {result.score}
      </p>

      <p>
        <strong>Segment:</strong> {result.segment}
      </p>
    </div>
  );
}

export default ScoreCard;
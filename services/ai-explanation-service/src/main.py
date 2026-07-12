from fastapi import FastAPI
from pydantic import BaseModel
from datetime import datetime, timezone

app = FastAPI()

@app.get("/health")
def health():
    return {
        "service": "AI Explanation Service",
        "status": "Healthy",
        "timestamp": datetime.now(timezone.utc).isoformat()
    }

class ExplainRequest(BaseModel):
    score: int
    segment: str

class ExplainResponse(BaseModel):
    explanation: str
    disclaimer: str

@app.post("/ai/explain-financial-iq")
def explain(request: ExplainRequest):
    templates = {
        "STRONG": "Finansal durumunuz güçlü görünüyor, nakit rezerviniz giderlerinizi rahatça karşılıyor.",
        "NEEDS_IMPROVEMENT": "Nakit rezerviniz giderlerinize kıyasla düşük, birikiminizi artırmayı düşünebilirsiniz."
    }
    #"Here, you are passing two arguments to .get(): 
    # the first is the key to search for (request.segment), and the second is the default value to return if it is not found
    explanation = templates.get(request.segment, "Skorunuz hesaplandı, detaylı analiz için danışmanınıza başvurun.")
    return ExplainResponse(
        explanation=explanation,
        disclaimer="Bu bilgi eğitim amaçlıdır, yatırım tavsiyesi değildir."
    )
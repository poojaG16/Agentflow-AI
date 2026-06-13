from fastapi import FastAPI
from models.request import TextRequest
from services.execution_engine import ExecutionEngine

app = FastAPI()

@app.post("/summarize")
def summarize(request: TextRequest):

    return ExecutionEngine.execute(
        "summarizer",
        request.text
    )

@app.post("/extract-tasks")
def task_extract(request: TextRequest):

    return ExecutionEngine.execute(
        "task-extractor",
        request.text
    )

@app.post("/generate-email")
def email_generate(request: TextRequest):

    return ExecutionEngine.execute(
        "email-generator",
        request.text
    )
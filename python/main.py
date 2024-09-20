from fastapi import FastAPI

app = FastAPI()

def factorial(n: int) -> int:
    return 1 if n <= 1 else n * factorial(n - 1)

@app.get("/factorial/{n}")
def get_factorial(n: int):
    result = factorial(n)
    return {"factorial": result}

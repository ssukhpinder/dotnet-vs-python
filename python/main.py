from fastapi import FastAPI
from pydantic import BaseModel
import numpy as np
from typing import List

app = FastAPI()

def factorial(n: int) -> int:
    return 1 if n <= 1 else n * factorial(n - 1)

@app.get("/factorial/{n}")
def get_factorial(n: int):
    result = factorial(n)
    return {"factorial": result}

class Matrices(BaseModel):
    mat1: list
    mat2: list

@app.post("/multiply/")
def multiply_matrices(data: Matrices):
    mat1 = np.array(data.mat1)
    mat2 = np.array(data.mat2)
    
    try:
        result = np.dot(mat1, mat2).tolist()
        return {"result": result}
    except ValueError as e:
        return {"error": str(e)}

class Numbers(BaseModel):
    numbers: List[int]

@app.post("/average")
def post_average(numbers: Numbers):
    return {"average": sum(numbers.numbers) / len(numbers.numbers)}


@app.get("/cpu-task")
async def cpu_task():
    result = sum([i for i in range(1_000_000)])
    return {"result": result}

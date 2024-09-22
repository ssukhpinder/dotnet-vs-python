using Microsoft.AspNetCore.Mvc;
using Sample;
using static Sample.Test;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region  Part 1 Factorial Operation Comparison b/w .Net & Python
app.MapGet("/factorial", (int n) =>
{
    long Factorial(int number)
    {
        return number <= 1 ? 1 : number * Factorial(number - 1);
    }

    long result = Factorial(n);
    return result;
})
.WithName("GetFactorial")
.WithOpenApi();

#endregion

#region  Part 2 Matrix Multiplication Operation Comparison b/w .Net & Python

app.MapPost("/multiply", ([FromBody] Matrices data) =>
{
    try
    {
        var result = Sample.Test.MultiplyMatrices(data.Mat1, data.Mat2);
        return Results.Ok(new { result });
    }
    catch (Exception e)
    {
        return Results.BadRequest(new { error = e.Message });
    }
})
.WithName("GetMatrix")
.WithOpenApi();

#endregion

#region  Part 3 Average Operation Comparison b/w .Net & Pyhton
// Minimal API in C#
app.MapPost("/average", ([FromBody] AverageClass numbers) =>
{
    double Average(List<int> nums) => nums.Average();
    return Average(numbers.numbers);
})
.WithName("PostAverage")
.WithOpenApi();

#endregion

app.Run();

namespace Sample
{
    public class AverageClass
    {
        public required List<int> numbers {  get; set; }
    }
    public static class Test
    {
        public record Matrices(int[][] Mat1, int[][] Mat2);
        public static int[][] MultiplyMatrices(int[][] mat1, int[][] mat2)
        {
            int size = mat1.Length;
            int[][] result = new int[size][];
            for (int i = 0; i < size; i++)
            {
                result[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    result[i][j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        result[i][j] += mat1[i][k] * mat2[k][j];
                    }
                }
            }
            return result;
        }
    }
}

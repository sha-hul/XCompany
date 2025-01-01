// See https://aka.ms/new-console-template for more information
using XCompany;

Console.WriteLine("Hello, World!");
string inputFile = @"C:\Users\Shahul\OneDrive\Documents\Explore\XCompany\input.txt";
string outputFile = @"C:\Users\Shahul\OneDrive\Documents\Explore\XCompany\output.txt";
XCompanyApplication.CallMain(new string[] { $"inputFile={inputFile}", $"outputFile={outputFile}" });
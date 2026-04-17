using System;

class EmployeeSalaryCalculator
{
    static void Main()
    {
        // Taking user input for employee details
        Console.Write("Enter Employee Name: ");
        string employeeName = Console.ReadLine().Trim();

        int hoursWorked = GetValidIntegerInput("Enter Hours Worked: ");
        double hourlyRate = GetValidDoubleInput("Enter Hourly Rate: ");

        Console.Write("Has Health Insurance? (yes/no): ");
        string healthInput = Console.ReadLine().Trim().ToLower();
        bool hasHealthInsurance = (healthInput == "yes");

        // Compute Gross Salary
        double grossSalary = CalculateGrossSalary(hoursWorked, hourlyRate);

        // Compute Tax Deduction based on Gross Salary
        double taxDeduction = CalculateTaxDeduction(grossSalary);

        // Health Insurance Deduction
        double healthInsuranceDeduction = hasHealthInsurance ? 2500 : 0;

        // Compute Net Salary
        double netSalary = grossSalary - taxDeduction - healthInsuranceDeduction;

        // Display results
        Console.WriteLine("\n--- Salary Computation ---");
        Console.WriteLine($"Employee Name: {employeeName}");
        Console.WriteLine($"Gross Salary: {grossSalary:F2}");
        Console.WriteLine($"Tax Deduction: {taxDeduction:F2}");
        Console.WriteLine($"Health Insurance Deduction: {healthInsuranceDeduction:F2}");
        Console.WriteLine($"Net Salary: {netSalary:F2}");
    }

    // Function to calculate gross salary
    static double CalculateGrossSalary(int hoursWorked, double hourlyRate)
    {
        if (hoursWorked <= 40)
            return hoursWorked * hourlyRate;
        else
            return (40 * hourlyRate) + ((hoursWorked - 40) * 1.5 * hourlyRate);
    }

    // Function to calculate tax deduction
    static double CalculateTaxDeduction(double grossSalary)
    {
        double taxRate;

        if (grossSalary > 70000)
            taxRate = 0.25;
        else if (grossSalary > 50000)
            taxRate = 0.20;
        else if (grossSalary > 30000)
            taxRate = 0.15;
        else
            taxRate = 0.10;

        return grossSalary * taxRate;
    }

    // Function to get valid integer input
    static int GetValidIntegerInput(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;
            Console.WriteLine("Invalid input. Please enter a valid non-negative integer.");
        }
    }

    // Function to get valid double input
    static double GetValidDoubleInput(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                return value;
            Console.WriteLine("Invalid input. Please enter a valid non-negative number.");
        }
    }
}

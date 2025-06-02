// CalculatorWrapper.cpp
#include "pch.h"
#include "CalculatorWrapper.h"
#include <stdexcept>

// ����� �� ���������� ������������ ���� CalculatorCore, ���� ���� �������� ������� ���� � ���.
// �� ��� ��� � ��� extern "C", ��� � ���������� ������������ ����.

// ���������� ������� ������������ ������ Calculator
double CalculatorWrapper::Calculator::Add(double a, double b)
{
    return ::Add(a, b); // �������� �������� C++ ������� Add
}

double CalculatorWrapper::Calculator::Subtract(double a, double b)
{
    return ::Subtract(a, b); // �������� �������� C++ ������� Subtract
}

double CalculatorWrapper::Calculator::Multiply(double a, double b)
{
    return ::Multiply(a, b); // �������� �������� C++ ������� Multiply
}

double CalculatorWrapper::Calculator::Divide(double a, double b)
{
    // ��������� ���������� �� ��������� C++:
    // ���� �������� C++ ������� Divide ����������� std::runtime_error,
    // C++/CLI ����� ����������� �� � ������������� � .NET ����������.
    try
    {
        return ::Divide(a, b); // �������� �������� C++ ������� Divide
    }
    catch (const std::runtime_error& e)
    {
        // ����������� �������� C++ ���������� � .NET ����������
        throw gcnew System::Exception(gcnew String(e.what()));
    }
}
// CalculatorCore.cpp : ���������� ���������������� ������� ��� DLL.
#include "pch.h"
#include "framework.h"
#include "CalculatorCore.h"
#include <stdexcept> // ��� ��������� ���������� (��������, ������� �� ����)

// ������� ��������
CALCULATORCORE_API double Add(double a, double b)
{
    return a + b;
}

// ������� ���������
CALCULATORCORE_API double Subtract(double a, double b)
{
    return a - b;
}

// ������� ���������
CALCULATORCORE_API double Multiply(double a, double b)
{
    return a * b;
}

// ������� �������
CALCULATORCORE_API double Divide(double a, double b)
{
    if (b == 0) {
        // � C++ �� ����� ��������� ����������, ������� ����� ����� ����� ���������� � C#
        throw std::runtime_error("������� �� ���� ����������.");
    }
    return a / b;
}

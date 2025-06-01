// CalculatorCore.cpp : Определяет экспортированные функции для DLL.
#include "pch.h"
#include "framework.h"
#include "CalculatorCore.h"
#include <stdexcept> // Для обработки исключений (например, деление на ноль)

// Функция сложения
CALCULATORCORE_API double Add(double a, double b)
{
    return a + b;
}

// Функция вычитания
CALCULATORCORE_API double Subtract(double a, double b)
{
    return a - b;
}

// Функция умножения
CALCULATORCORE_API double Multiply(double a, double b)
{
    return a * b;
}

// Функция деления
CALCULATORCORE_API double Divide(double a, double b)
{
    if (b == 0) {
        // В C++ мы можем выбросить исключение, которое затем можно будет обработать в C#
        throw std::runtime_error("Деление на ноль невозможно.");
    }
    return a / b;
}

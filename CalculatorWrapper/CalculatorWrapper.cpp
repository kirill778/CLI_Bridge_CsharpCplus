// CalculatorWrapper.cpp
#include "pch.h"
#include "CalculatorWrapper.h"
#include <stdexcept>

// Здесь мы используем пространство имен CalculatorCore, если ваши нативные функции были в нем.
// Но так как у нас extern "C", они в глобальном пространстве имен.

// Реализация методов управляемого класса Calculator
double CalculatorWrapper::Calculator::Add(double a, double b)
{
    return ::Add(a, b); // Вызываем нативную C++ функцию Add
}

double CalculatorWrapper::Calculator::Subtract(double a, double b)
{
    return ::Subtract(a, b); // Вызываем нативную C++ функцию Subtract
}

double CalculatorWrapper::Calculator::Multiply(double a, double b)
{
    return ::Multiply(a, b); // Вызываем нативную C++ функцию Multiply
}

double CalculatorWrapper::Calculator::Divide(double a, double b)
{
    // Обработка исключений из нативного C++:
    // Если нативная C++ функция Divide выбрасывает std::runtime_error,
    // C++/CLI может перехватить ее и преобразовать в .NET исключение.
    try
    {
        return ::Divide(a, b); // Вызываем нативную C++ функцию Divide
    }
    catch (const std::runtime_error& e)
    {
        // Преобразуем нативное C++ исключение в .NET исключение
        throw gcnew System::Exception(gcnew String(e.what()));
    }
}
#pragma once

#ifdef CALCULATORCORE_EXPORTS
#define CALCULATORCORE_API __declspec(dllexport)
#else
#define CALCULATORCORE_API __declspec(dllimport)
#endif

// Объявления функций калькулятора
extern "C" {
    CALCULATORCORE_API double Add(double a, double b);
    CALCULATORCORE_API double Subtract(double a, double b);
    CALCULATORCORE_API double Multiply(double a, double b);
    CALCULATORCORE_API double Divide(double a, double b);
}
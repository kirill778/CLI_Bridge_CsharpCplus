// CalculatorWrapper.h
#pragma once

// Включаем заголовочный файл вашей нативной C++ DLL
// Убедитесь, что путь к этому файлу корректен.
// Если CalculatorCore.h находится в папке CalculatorCore,
// вам может понадобиться добавить путь к этой папке в "Дополнительные каталоги включения"
// (Additional Include Directories) в свойствах проекта CalculatorWrapper.
// Свойства проекта CalculatorWrapper -> Свойства конфигурации -> C/C++ -> Общие -> Дополнительные каталоги включения.
// Например: $(SolutionDir)CalculatorCore;
#include "../CalculatorCore/CalculatorCore.h" // Путь к файлу CalculatorCore.h

using namespace System; // Используем пространство имен System для базовых типов .NET

namespace CalculatorWrapper {

    // public ref class указывает, что это управляемый (Managed) класс,
    // который может быть использован из других .NET языков (например, C#).
    public ref class Calculator
    {
    public:
        // Методы, которые будут вызываться из C#
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
    };
}
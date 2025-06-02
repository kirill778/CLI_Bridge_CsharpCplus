using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
// using System.Runtime.InteropServices; // Этот using теперь не нужен

// Добавьте это:
using CalculatorWrapper; // Добавляем пространство имен нашей C++/CLI обертки

namespace CalculatorApp
{
    public sealed partial class MainWindow : Window
    {
        // Создаем экземпляр нашего C++/CLI калькулятора
        private Calculator _calculator = new Calculator(); // Создаем экземпляр обертки

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Калькулятор";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = string.Empty;
            ResultTextBlock.Text = "Результат: ";

            if (sender is Button clickedButton)
            {
                if (double.TryParse(Number1TextBox.Text, out double num1) &&
                    double.TryParse(Number2TextBox.Text, out double num2))
                {
                    double result = 0;
                    bool success = true;
                    string operation = clickedButton.Tag.ToString();

                    try
                    {
                        switch (operation)
                        {
                            case "Add":
                                result = _calculator.Add(num1, num2); // Вызываем метод обертки
                                break;
                            case "Subtract":
                                result = _calculator.Subtract(num1, num2); // Вызываем метод обертки
                                break;
                            case "Multiply":
                                result = _calculator.Multiply(num1, num2); // Вызываем метод обертки
                                break;
                            case "Divide":
                                result = _calculator.Divide(num1, num2); // Вызываем метод обертки
                                break;
                            default:
                                success = false;
                                ErrorTextBlock.Text = "Неизвестная операция.";
                                break;
                        }
                    }
                    catch (Exception ex) // Теперь мы ловим обычное .NET исключение из C++/CLI
                    {
                        ErrorTextBlock.Text = $"Произошла ошибка: {ex.Message}";
                        success = false;
                    }

                    if (success)
                    {
                        ResultTextBlock.Text = $"Результат: {result}";
                    }
                }
                else
                {
                    ErrorTextBlock.Text = "Пожалуйста, введите корректные числа в оба поля.";
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Number1TextBox.Text = string.Empty;
            Number2TextBox.Text = string.Empty;
            ResultTextBlock.Text = "Результат: ";
            ErrorTextBlock.Text = string.Empty;
        }
    }
}
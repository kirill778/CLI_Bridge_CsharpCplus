using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Runtime.InteropServices; // Важно: для DllImport

namespace CalculatorApp
{
    public sealed partial class MainWindow : Window
    {
        // Объявляем импортированные функции из нашей C++ DLL
        [DllImport("CalculatorCore.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double Add(double a, double b);

        [DllImport("CalculatorCore.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double Subtract(double a, double b);

        [DllImport("CalculatorCore.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double Multiply(double a, double b);

        [DllImport("CalculatorCore.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double Divide(double a, double b);

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Калькулятор";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем предыдущие ошибки
            ErrorTextBlock.Text = string.Empty;
            ResultTextBlock.Text = "Результат: ";

            if (sender is Button clickedButton)
            {
                // Пытаемся получить числа из текстовых полей
                if (double.TryParse(Number1TextBox.Text, out double num1) &&
                    double.TryParse(Number2TextBox.Text, out double num2))
                {
                    double result = 0;
                    bool success = true;
                    string operation = clickedButton.Tag.ToString(); // Получаем операцию из Tag кнопки

                    try
                    {
                        switch (operation)
                        {
                            case "Add":
                                result = Add(num1, num2); // Вызов C++ функции
                                break;
                            case "Subtract":
                                result = Subtract(num1, num2); // Вызов C++ функции
                                break;
                            case "Multiply":
                                result = Multiply(num1, num2); // Вызов C++ функции
                                break;
                            case "Divide":
                                result = Divide(num1, num2); // Вызов C++ функции (может выбросить исключение)
                                break;
                            default:
                                success = false;
                                ErrorTextBlock.Text = "Неизвестная операция.";
                                break;
                        }
                    }
                    catch (COMException ex) // Обработка исключений, выброшенных из C++ DLL
                    {
                        // COMException может быть выброшен, если неуправляемый код вызывает ошибку.
                        // В нашем случае, std::runtime_error из C++ может быть перехвачен как COMException.
                        ErrorTextBlock.Text = $"Ошибка C++: {ex.Message}";
                        success = false;
                    }
                    catch (Exception ex) // Общая обработка других исключений
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

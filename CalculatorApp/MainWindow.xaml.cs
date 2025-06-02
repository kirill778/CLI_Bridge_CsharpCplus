using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
// using System.Runtime.InteropServices; // ���� using ������ �� �����

// �������� ���:
using CalculatorWrapper; // ��������� ������������ ���� ����� C++/CLI �������

namespace CalculatorApp
{
    public sealed partial class MainWindow : Window
    {
        // ������� ��������� ������ C++/CLI ������������
        private Calculator _calculator = new Calculator(); // ������� ��������� �������

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "�����������";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = string.Empty;
            ResultTextBlock.Text = "���������: ";

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
                                result = _calculator.Add(num1, num2); // �������� ����� �������
                                break;
                            case "Subtract":
                                result = _calculator.Subtract(num1, num2); // �������� ����� �������
                                break;
                            case "Multiply":
                                result = _calculator.Multiply(num1, num2); // �������� ����� �������
                                break;
                            case "Divide":
                                result = _calculator.Divide(num1, num2); // �������� ����� �������
                                break;
                            default:
                                success = false;
                                ErrorTextBlock.Text = "����������� ��������.";
                                break;
                        }
                    }
                    catch (Exception ex) // ������ �� ����� ������� .NET ���������� �� C++/CLI
                    {
                        ErrorTextBlock.Text = $"��������� ������: {ex.Message}";
                        success = false;
                    }

                    if (success)
                    {
                        ResultTextBlock.Text = $"���������: {result}";
                    }
                }
                else
                {
                    ErrorTextBlock.Text = "����������, ������� ���������� ����� � ��� ����.";
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Number1TextBox.Text = string.Empty;
            Number2TextBox.Text = string.Empty;
            ResultTextBlock.Text = "���������: ";
            ErrorTextBlock.Text = string.Empty;
        }
    }
}
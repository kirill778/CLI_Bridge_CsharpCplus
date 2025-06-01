using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Runtime.InteropServices; // �����: ��� DllImport

namespace CalculatorApp
{
    public sealed partial class MainWindow : Window
    {
        // ��������� ��������������� ������� �� ����� C++ DLL
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
            this.Title = "�����������";
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            // ������� ���������� ������
            ErrorTextBlock.Text = string.Empty;
            ResultTextBlock.Text = "���������: ";

            if (sender is Button clickedButton)
            {
                // �������� �������� ����� �� ��������� �����
                if (double.TryParse(Number1TextBox.Text, out double num1) &&
                    double.TryParse(Number2TextBox.Text, out double num2))
                {
                    double result = 0;
                    bool success = true;
                    string operation = clickedButton.Tag.ToString(); // �������� �������� �� Tag ������

                    try
                    {
                        switch (operation)
                        {
                            case "Add":
                                result = Add(num1, num2); // ����� C++ �������
                                break;
                            case "Subtract":
                                result = Subtract(num1, num2); // ����� C++ �������
                                break;
                            case "Multiply":
                                result = Multiply(num1, num2); // ����� C++ �������
                                break;
                            case "Divide":
                                result = Divide(num1, num2); // ����� C++ ������� (����� ��������� ����������)
                                break;
                            default:
                                success = false;
                                ErrorTextBlock.Text = "����������� ��������.";
                                break;
                        }
                    }
                    catch (COMException ex) // ��������� ����������, ����������� �� C++ DLL
                    {
                        // COMException ����� ���� ��������, ���� ������������� ��� �������� ������.
                        // � ����� ������, std::runtime_error �� C++ ����� ���� ���������� ��� COMException.
                        ErrorTextBlock.Text = $"������ C++: {ex.Message}";
                        success = false;
                    }
                    catch (Exception ex) // ����� ��������� ������ ����������
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

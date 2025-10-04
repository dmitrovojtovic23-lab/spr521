#include <windows.h>
#include <iostream>
using namespace std;

int main()
{
    HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);
    int a, b;
    int color;
    cout << "Enter the first side : ";
    cin >> a;
    cout << "Enter the second side : ";
    cin >> b;
    cout << "Enter the color (number) : ";
    cin >> color;
    SetConsoleTextAttribute(h, color);
    for (int i = 0; i < a; i++)
    {
        cout << "* ";
    }
    cout << endl;
    for (int i = 0; i < b; i++)
    {
        cout << "* ";
        for (int k = 0; k < a - 2; k++)
        {
            cout << "  ";
        }
        cout << "*" << endl;
    }
    for (int i = 0; i < a; i++)
    {
        cout << "* ";
    }
    SetConsoleTextAttribute(h, 7);
}
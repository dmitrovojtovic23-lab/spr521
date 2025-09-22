#include <iostream>
using namespace std;

int main()
{
    // Task 1 
    int num1;
    cout << "Enter a number : ";
    cin >> num1;
    cout << (num1 % 2 == 0 ? "The number is even\n" : "The number is odd\n");

    // Task 2 
    int a, b;
    cout << "Enter two numbers (task 2): ";
    cin >> a >> b;
    cout << "Smaller number: " << (a < b ? a : b) << "\n";

    // Task 3 
    int num2;
    cout << "Enter a number (task 3): ";
    cin >> num2;
    if (num2 > 0) 
    {
        cout << "The number is positive\n";
    }
    else if (num2 < 0)
    {
        cout << "The number is negative\n";
    }
    else
    {
        cout << "The number is zero\n";
    }

    // Task 4 
    #include <iostream>
    using namespace std;

    int main() 
    {
        int a, b;
        cout << "Enter 2 numbers : ";
        cin >> a >> b;

        if (a == b) {
            cout << "Numbers are equal" << endl;
        }
        else {
            cout << "ascending numbers: ";
            if (a < b) {
                cout << a << " " << b << endl;
            }
            else {
                cout << b << " " << a << endl;
            }
        }

        return 0;
    }

}
    //________________________________________________________
    //Task2
    #include <iostream>
    using namespace std;

    int main() {
    double grades[5];
    double sum = 0;
    cout << "Enter  5 marks stydent:\n";
    for (int i = 0; i < 5; i++) {
        cin >> grades[i];
        sum += grades[i];
    }
    double average = sum / 5;
    if (average >= 4) {
        cout << "studenr admitted to the exam \n";
    }
    else {
        cout << "student is not  admitted to the exam \n";
    }
    return 0;
}

    //Task2
    #include <iostream>
    using namespace std;

    int main() {
        int num;
        cout << "Enter number: ";
        cin >> num;
        if (num % 2 == 0) {
            num = num * 3;
        }
        else {
            num = num / 2;
        }
        cout << "result: " << num << endl;
        return 0;
    }
    //Task3
    int main()
    {
        int a, b;
        char operation;
        cout << "Enter numbers : ";
        cin >> a >> b;
        cout << "Enter operation (*, /, +, -) : ";
        cin >> operation;
        switch (operation)
        {
        case '-':
            cout << a << " - " << b << " = " << a - b;
            break;
        default:
            break;
        }
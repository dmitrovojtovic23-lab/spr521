/// Part 1
#include <iostream>
using namespace std;


int main()
{

	int seconds;
	cout << "Enter how many seconds had passed since the start of the day : " << endl;
	cin >> seconds;
	int hours = seconds / 3600;
	int minutes = (seconds % 3600) / 60;
	int sec = seconds % 60;

	int left_seconds = 86400 - seconds;
	int left_hours = left_seconds / 3600;
	int left_minutes = (left_seconds % 3600) / 60;
	int left_sec = left_seconds % 60;
	cout << "Time left until the midnight : " << left_hours << " : " << left_minutes << " : " << left_sec << endl;
}

/// _________________________________


int main()
{
	double diameter;
	cout << "Enter the diameter of the circle in centimeters : ";
	cin >> diameter;
	double area{ 3.14 * (diameter / 2) * (diameter / 2) };
	double circumference{ 3.14 * diameter };
	cout << "the area of the circle is " << area << "cm" << endl;
	cout << "the area of the circle is " << circumference << "cm" << endl;
}

/// _________________________________
/// Part 2

int main()
{
	int a;
	cout << "Enter the first number : ";
	cin >> a;
	int b;
	cout << "Enter the second number : ";
	cin >> b;
	cout << "Sum: " << a + b << endl;
	cout << "Multiplication: " << a * b << endl;
	cout << "Average: " << (a + b) / 2.0 << endl;
}

/// _________________________________

int main()
{
	int a;
	cout << "Enter the first number :";
	cin >> a;
	int b;
	cout << "Enter the second number : ";
	cin >> b;
	int c;
	cout << "Enter the third number : ";
	cin >> c;
	cout << "Sum: " << a + b + c << endl;
	cout << "Multiplication: " << a * b * c << endl;
	cout << "Average: " << (a + b + c) / 3.0 << endl;
}

/// _________________________________

int main()
{
	int price;
	cout << "Enter how many one laptop cost in Dollars : ";
	cin >> price;
	int quantity;
	cout << "Enter how many laptop you want to buy : ";
	cin >> quantity;
	int discount;
	cout << "Enter discount percentage > ";
	cin >> discount;
	int total = price * quantity;
	int dis = (total * discount) / 100;
	int finalcost = total - dis;
	cout << "Total cost is $" << finalcost << endl;
}

/// _________________________________

int main()
{
	int sales;
	cout << "Enter mountly sales in dollars : ";
	cin >> sales;
	double percentage{ sales * 0.05 };
	double payment{ 100 + percentage };
	cout << "Managers pay is $" << payment << endl;
}

/// _________________________________

int main()
{
	double scale;
	cout << "Enter how many the file weigh in gigabytes : ";
	cin >> scale;
	double speed;
	cout << "Enter the speed of your modem in bits pes second : ";
	cin >> speed;
	int time = (scale * 1024 * 1024 * 1024 * 8) / speed;
	int hours = time / 3600;
	int minutes = (time % 3600) / 60;
	int seconds = time % 60;
	cout << "The  download time is " << hours << " Hours, " << minutes << " Minutes, and " << seconds << " Seconds." << endl;
}
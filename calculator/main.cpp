#include <iostream>
#include <vector>
#include <limits>

using namespace std;
//This program is, for all intents and purposes, just a calculator.
//I wanted to make sure that it was polished, however, and made sure to include
//Comprehensive error checking as to "cover all bases" so to speak

//error checking method so i dont have to manually do it every time
float promptFloat(const string& prompt) {
    while(true) {
        cout << prompt;
        float num;
        cin >> num;

        if(!cin.fail()) {
            return num;
        } else {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Invalid input! Please try again." << endl;
        }
    }
}

enum Options {
    ADD = 1,
    SUBTRACT = 2,
    MULTIPLY = 3,
    DIVIDE = 4,
    EXIT = 5
};

void Menu() {
    cout << "Welcome to the calculator!" "\n";
    cout << "1 -- Add" "\n";
    cout << "2 -- Subtract" "\n";
    cout << "3 -- Multiply" "\n";
    cout << "4 -- Divide" "\n";
    cout << "5 -- Exit" "\n";
    cout << "Please select an option (1-5): ";
}

vector<float> Results;

void Divide() {
    float num1 = promptFloat("Enter the first number: ");
    while(true){
        float num2 = promptFloat("Enter the second number: ");
        if(num2 != 0) {
            float quotient = num1 / num2;
            cout << num1 << " / " << num2 << " = " << quotient << "\n";
            Results.push_back(quotient);
            break;
        } else {
            cout << "Cannot divide by zero! Please try again.\n";
        }
    }
}

void Multiply() {
    float num1 = promptFloat("Enter the first number: ");
    float num2 = promptFloat("Enter the second number: ");
    float product = num1 * num2;
    cout << num1 << " x " << num2 << " = " << product << "\n";
    Results.push_back(product);
}

void Subtract() {
    float num1 = promptFloat("Enter the first number: ");
    float num2 = promptFloat("Enter the second number: ");
    float difference = num1 - num2;
    cout << num1 << " - " << num2 << " = " << difference << "\n";
    Results.push_back(difference);
}

void Add() {
    float num1 = promptFloat("Enter the first number: ");
    float num2 = promptFloat("Enter the second number: ");
    float sum = num1 + num2;
    cout << num1 << " + " << num2 << " = " << sum << "\n";
    Results.push_back(sum);
}

int main() {
    bool selecting = true;
    while(selecting){
        Menu();
        int option;
        cin >> option;
        //if the user inputs something other then an int, we don't want the program to explode
        if(cin.fail()) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Please enter an integer!" << "\n";
        }
        else {
            switch(option) {
                case ADD:
                    Add();
                break;
                case SUBTRACT:
                    Subtract();
                break;
                case MULTIPLY:
                    Multiply();
                break;
                case DIVIDE:
                    Divide();
                break;
                case EXIT:
                    selecting = false;
                break;
                default:
                    cout << "Invalid option! Please select an integer 1-5.\n";
                break;
            }
        }
    }
    if(!Results.empty()){
        for(size_t i = 0; i < Results.size(); i++) {
            cout << "Summary of result " << (i + 1) << ": " << Results[i] << "\n";
        }
    }
    return 0;
}

#include <iostream>
#include <vector>
#include "Student.h"

std::vector<Student> studentGrades;
int numStudents;

double calcAverage() {
    double totalGrade = 0.0;
    for(int i = 0; i < numStudents; i++) {
        totalGrade += studentGrades[i].getGrade();
    }
    double avgGrade = totalGrade / numStudents;
    std::cout << "Average grade: " << avgGrade << std::endl;
    return avgGrade;
}

std::pair<std::string, std::string> sortGrades() {
    Student highestGrade = studentGrades[0];
    Student lowestGrade = studentGrades[0];
    if(!studentGrades.empty()) {
        for(const auto &Student : studentGrades) {
            if (Student.getGrade() > highestGrade.getGrade()) highestGrade = Student;
            if (Student.getGrade() < lowestGrade.getGrade()) lowestGrade = Student;
        }
    }
    else {
        std::cout << "Student data does not exist!";
    }

    return std::make_pair(highestGrade.getName(), lowestGrade.getName());
}


int main() {
    std::cout << "How many students are in your class?";
    //declaring the number of students
    std::cin >> numStudents;

    std::string name;
    int grade;


    for(int i = 0; i < numStudents; i++) {

        std::cout << "Enter name for student " << std::to_string(i+1);
        std::cin >> name;
        std::cout << "Enter grade for student "  << std::to_string(i+1);
        std:: cin >> grade;
        studentGrades.emplace_back(name, grade);

    }

    for(int i = 0; i < numStudents; i++){
        std::cout << "Name: " << studentGrades[i].getName() << ", Grade: " << studentGrades[i].getGrade() << std::endl;
    }

    calcAverage();
    auto [highestGrade, lowestGrade] = sortGrades(); // calling sortGrades()
    std::cout << "Student with highest grade: " << highestGrade << std::endl;
    std::cout << "Student with lowest grade: " << lowestGrade << std::endl;

}



//
// Created by User on 9/28/2024.
//

#ifndef STUDENT_H
#define STUDENT_H
#include <string>

class Student {

public:
    //constructor
    Student(const std::string& name, int grade);
    [[nodiscard]] std::string getName() const;
    [[nodiscard]] int getGrade() const;

private:

    std::string name;
    int grade;

};


#endif //STUDENT_H

//
// Created by User on 9/28/2024.
//

#include "Student.h"
Student::Student(const std::string& name, int grade) : name(name), grade(grade) {
}

[[nodiscard]] std::string Student::getName() const {
    return name;
}

// getGrade function implementation
[[nodiscard]] int Student::getGrade() const {
    return grade;
}

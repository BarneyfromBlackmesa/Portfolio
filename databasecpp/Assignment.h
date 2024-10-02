//
// Created by User on 9/29/2024.
//

#ifndef ASSIGNMENT_H
#define ASSIGNMENT_H
#include <string>



class Assignment {

public:
    Assignment(const std::string& assignName, int maxPoints, int dueDate);


private:
    std::string assignName;
    int maxPoints;
    int dueDate;

};



#endif //ASSIGNMENT_H

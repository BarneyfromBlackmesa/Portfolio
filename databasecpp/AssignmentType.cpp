//
// Created by User on 9/29/2024.
//

#include "AssignmentType.h"


AssignmentType::AssignmentType(Type type): type(type) {}

AssignmentType::Type AssignmentType::getType() const {
    return type;
}
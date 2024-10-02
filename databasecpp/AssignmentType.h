//
// Created by User on 9/29/2024.
//

#ifndef ASSIGNMENTTYPE_H
#define ASSIGNMENTTYPE_H



class AssignmentType {
public:
    enum Type {
        HOMEWORK,
        QUIZ,
        EXAM,
        PROJECT
    };

    Type type;

    explicit AssignmentType(Type type);

    [[nodiscard]] Type getType() const;
};

#endif //ASSIGNMENTTYPE_H

cmake_minimum_required(VERSION 3.28)
project(untitled)

set(CMAKE_CXX_STANDARD 26)

add_executable(untitled main.cpp
        Student.cpp
        Student.h
        Assignment.cpp
        Assignment.h
        AssignmentType.cpp
        AssignmentType.h)

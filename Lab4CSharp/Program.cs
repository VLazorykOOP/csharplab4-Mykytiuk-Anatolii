﻿using Lab4CSharp;

Console.WriteLine("Lab 4 CSharp");
while (true)
{
    Console.WriteLine("Enter the task number:");
    string input = Console.ReadLine();
    int n;
    if (int.TryParse(input, out n))
    {
        switch (n)
    {
        case 1:

        Trapeze trapeze = new Trapeze();
        //get
        Console.WriteLine(trapeze[0]); 
        Console.WriteLine(trapeze[1]); 
        Console.WriteLine(trapeze[2]);
        Console.WriteLine(trapeze[3]); 
        //set
        trapeze[0] = 10; 
        Console.WriteLine(trapeze[0]);



        Console.WriteLine();
        Console.WriteLine("             Part 2");
        Console.WriteLine("             Operator ++ and operator --");
        Trapeze trapeze1 = new Trapeze(1, 7, 3, 4);
        Console.WriteLine("Original Trapeze:");
        trapeze1.DisplayLengths();

        trapeze1++; // Increment values of 'a' and 'b'
        Console.WriteLine("\nAfter ++ operator:");
        trapeze1.DisplayLengths();

        trapeze1--; // Decrement values of 'a' and 'b'
        Console.WriteLine("\nAfter -- operator:");
        trapeze1.DisplayLengths();


        Console.WriteLine();
        Console.WriteLine("             Operator false and operator true");
        Trapeze trapeze2 = new Trapeze(3, 8, 2, 0);
        if (trapeze2) 
            Console.WriteLine("True");
        else 
            Console.WriteLine("False");

        if (trapeze1) 
            Console.WriteLine("True");
        else 
            Console.WriteLine("False");


        Console.WriteLine();
        Console.WriteLine("             Operator * and scalar");
        int scalar = 3;
        Trapeze result = trapeze1 * scalar;

        Console.WriteLine("Original Trapeze:");
        trapeze1.DisplayLengths();

        Console.WriteLine($"\nTrapeze multiplied by {scalar}:");
        result.DisplayLengths();


        Console.WriteLine();
        Console.WriteLine("             To string and from string");
        string trapezeString = (string)trapeze1;
        Console.WriteLine("To string:" + trapezeString);


        trapezeString = "(1, 2, 3, 4)";
        Trapeze newTrapeze = (Trapeze)trapezeString;

        Console.WriteLine("\nConverted Trapeze from string:");
        newTrapeze.DisplayLengths();

        break;

case 2:
            VectorFloat vector1 = new VectorFloat(5);
            VectorFloat vector2 = new VectorFloat(5);

            Console.WriteLine("Demonstration of manual input");
            vector2.Fill();
            vector2.Print();

            Console.WriteLine("Demonstration of Filling with scalar(2)");
            vector2.Enter(2);
            vector2.Print();

            Console.WriteLine(vector2.Num);

            vector2.CodeError = 0;
            Console.WriteLine(vector2.CodeError);

            Console.WriteLine("Correct " + vector2[1] + " Incorrect " + vector2[10]);

            Console.WriteLine(vector2.CodeError);

            Console.WriteLine("Demonstration ++");
            vector2++;
            vector2.Print();

            Console.WriteLine("Demonstration --");
            vector2--;
            vector2--;
            vector2.Print();

            vector2.Fill();
            Console.WriteLine("Demonstration True/False");
            if (vector2) Console.WriteLine("Not equal to zero");
            else Console.WriteLine("Vector dimension or one of the elements equals 0 ");

            VectorFloat vectorNot = new VectorFloat(2);
            VectorFloat vector = new VectorFloat(vector1.Num);
            float scalar2 = 2;
            Console.WriteLine("Overloading +");
            vector = vector1 + vector2;
            vector.Print();
            //vector = vector1 + vectorNot;
            //vector.Print();
            vector = vector2 + scalar2;
            vector.Print();

            Console.WriteLine("Overloading -");
            vector = vector2 - vector1;
            vector.Print();
            //vector = vector1 - vectorNot;
            //vector.Print();
            vector = vector2 - scalar2;
            vector.Print();

            Console.WriteLine("Overloading *");
            vector = vector1 * vector2;
            vector.Print();
            vector = vector2 * scalar2;
            vector.Print();

            Console.WriteLine("Overloading /");
            vector = vector2 / vector1;
            vector.Print();
            vector = vector2 / scalar2;
            vector.Print();

            Console.WriteLine("Overloading %");
            vector = vector2 % vector1;
            vector.Print();
            vector = vector2 % scalar2;
            vector.Print();

            Console.WriteLine("Overloading |");
            vector = vector2 | vector1;
            vector.Print();
            vector = vector2 | scalar2;
            vector.Print();

            Console.WriteLine("Overloading >>");
            vector = vector2 >> (int)scalar2;
            vector.Print();

            Console.WriteLine("Overloading <<");
            vector = vector2 << (int)scalar2;
            vector.Print();

            Console.WriteLine("Overloading ==");
            Console.WriteLine(vector1 == vector);
            vector1 = vector2;
            Console.WriteLine(vector1 == vector2);

            Console.WriteLine("Overloading !=");
            Console.WriteLine(vector1 != vector);

            Console.WriteLine("Overloading >");
            Console.WriteLine(vector1 > vector);

            Console.WriteLine("Overloading <");
            Console.WriteLine(vector1 < vector);

            Console.WriteLine("Overloading >=");
            Console.WriteLine(vector1 >= vector);

            Console.WriteLine("Overloading <=");
            Console.WriteLine(vector1 <= vector);
            break;
        case 3:
            FloatMatrix matrix1 = new FloatMatrix(2, 2);
            FloatMatrix matrix2 = new FloatMatrix(2, 2);

            matrix1.Print();

            Console.WriteLine("Manual input demonstration");
            matrix1.Fill();
            matrix1.Print();

            Console.WriteLine("Filling with scalar(3)");
            matrix2.Enter(3);
            matrix2.Print();

            matrix2.CodeError = 0;
            Console.WriteLine(matrix2.CodeError);

            Console.WriteLine("Correct " + matrix1[0, 1] + " Incorrect " + matrix2[4, 5]);
            Console.WriteLine("Through the k index - " + matrix1[3]);
            Console.WriteLine(matrix2.CodeError);

            Console.WriteLine("Demonstration ++");
            matrix1++;
            matrix1.Print();

            Console.WriteLine("Demonstration --");
            matrix2--;
            matrix2--;
            matrix2.Print();

            matrix2.Fill();
            Console.WriteLine("Demonstration True/False");
            if (matrix2) Console.WriteLine("Not equal to zero");
            else Console.WriteLine("Matrix dimension or one of the elements equals 0 ");

            FloatMatrix matrix = new FloatMatrix(2, 2);
            ushort scalar1 = 2;
            Console.WriteLine("Overloading +");
            matrix = matrix1 + matrix2;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix1 + scalar1;
            matrix.Print();

            Console.WriteLine("Overloading -");
            matrix = matrix2 - matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 - scalar1;
            matrix.Print();

            Console.WriteLine("Overloading *");
            matrix = matrix1 * matrix2;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 * scalar1;
            matrix.Print();

            Console.WriteLine("Overloading /");
            matrix = matrix2 / matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 / scalar1;
            matrix.Print();

            Console.WriteLine("Overloading %");
            matrix = matrix2 % matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 % scalar1;
            matrix.Print();

            Console.WriteLine("Overloading |");
            matrix = matrix2 | matrix1;
            matrix.Print();
            Console.WriteLine("--------");
            matrix = matrix2 | scalar1;
            matrix.Print();

            Console.WriteLine("Overloading >>");
            matrix = matrix2 >> scalar1;
            matrix.Print();

            Console.WriteLine("Overloading <<");
            matrix = matrix2 << scalar1;
            matrix.Print();

            Console.WriteLine("Overloading ==");
            Console.WriteLine(matrix1 == matrix);
            matrix1 = matrix2;
            Console.WriteLine(matrix1 == matrix2);

            Console.WriteLine("Overloading !=");
            Console.WriteLine(matrix1 != matrix);

            Console.WriteLine("Overloading >");
            Console.WriteLine(matrix1 > matrix);

            Console.WriteLine("Overloading <");
            Console.WriteLine(matrix1 < matrix);

            Console.WriteLine("Overloading >=");
            Console.WriteLine(matrix1 >= matrix);

            Console.WriteLine("Overloading <=");
            Console.WriteLine(matrix1 <= matrix);

            break;
        default:
            Console.WriteLine("Incorrect");
            break;
         }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
        break; // Exit the loop if input is invalid
    }
}
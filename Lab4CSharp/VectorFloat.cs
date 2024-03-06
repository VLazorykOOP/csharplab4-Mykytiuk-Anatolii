using System;

namespace Lab4CSharp
{
    public class VectorFloat
    {
        private float[] ArrayFloat;
        private uint num;
        private uint codeError;
        private static uint num_vs;

        public VectorFloat()
        {
            this.num = 1;
            this.ArrayFloat = new float[num];
            ArrayFloat[0] = 0;
            num_vs++;
        }
        public VectorFloat(uint num)
        {
            this.num = num;
            ArrayFloat = new float[num];
            for (uint i = 0; i < num; i++)
            {
                ArrayFloat[i] = 0;
            }
            num_vs++;
        }
        public VectorFloat(uint num, float value)
        {
            this.num = num;
            ArrayFloat = new float[num];
            for (uint i = 0; i < num; i++)
            {
                ArrayFloat[i] = value;
            }
            num_vs++;
        }
        // Деструктор
        ~VectorFloat()
        {
            Console.WriteLine("VectorFloat object is being destroyed.");
        }
        public void Fill()
        {
            for (uint i = 0; i < num; i++)
            {
                this.ArrayFloat[i] = float.Parse(Console.ReadLine());
            }
        }
        public void Print()
        {
            for (uint i = 0; i < num; i++)
            {
                Console.Write(this.ArrayFloat[i] + " ");
            }
            Console.WriteLine();
        }
        static void Count()
        {
            Console.WriteLine(num_vs);
        }
        public void Enter(float value)
        {
            for (uint i = 0; i < num; i++)
            {
                this.ArrayFloat[i] = value;
            }
        }
        public uint Num
        {
            get { return num; }
        }
        public uint CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= num)
                {
                    codeError = 1;
                    return 0;
                }
                // Повертаємо значення індексу масиву
                return ArrayFloat[index];
            }
            set
            {
                if (index < 0 || index >= num)
                {
                    codeError = 1;
                    return;
                }
                // Записуємо значення індексу масиву
                ArrayFloat[index] = value;
            }
        }
        public static VectorFloat operator ++(VectorFloat vector)
        {
            for (uint i = 0; i < vector.ArrayFloat.Length; i++)
            {
                vector.ArrayFloat[i]++;
            }
            return vector;
        }

        public static VectorFloat operator --(VectorFloat vector)
        {
            for (uint i = 0; i < vector.ArrayFloat.Length; i++)
            {
                vector.ArrayFloat[i]--;
            }
            return vector;
        }
        public static bool operator true(VectorFloat vector)
        {
            return vector.num != 0 && Array.Exists(vector.ArrayFloat, element => element == 0);
        }

        public static bool operator false(VectorFloat vector)
        {
            return vector.num == 0 || Array.Exists(vector.ArrayFloat, element => element != 0);
        }
        public static bool operator !(VectorFloat vector)
        {
            return vector.num != 0;
        }
        public override string ToString()
        {
            return $"{this.num}";
        }
        public static VectorFloat operator ~(VectorFloat vector)
        {
            VectorFloat result = new VectorFloat(vector.num);
            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayFloat[i] = ~(int)vector.ArrayFloat[i];
            }
            return result;
        }
        public static VectorFloat operator +(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorFloat result = new VectorFloat(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                // Перевірка на переповнення для кожного елемента
                if (vector1.ArrayFloat[i] > float.MaxValue - vector2.ArrayFloat[i])
                {
                    throw new OverflowException("При додаванні елементів виникло переповнення.");
                }

                result.ArrayFloat[i] = vector1.ArrayFloat[i] + vector2.ArrayFloat[i];
            }

            return result;

        }

        // Перевантаження бінарної операції додавання для вектора і скаляра float
        public static VectorFloat operator +(VectorFloat vector1, float scalar)
        {
            VectorFloat vector = new VectorFloat(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector.num; i++)
            {
                vector.ArrayFloat[i] = vector1.ArrayFloat[i] + scalar;
            }

            return vector;
        }

        // Перевантаження бінарної операції віднімання для двох векторів
        public static VectorFloat operator -(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorFloat result = new VectorFloat(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector1.ArrayFloat[i] < vector2.ArrayFloat[i])
                {
                    //throw new InvalidOperationException("Віднімання може призвести до від'ємного результату.");
                    Console.WriteLine("Відємне значення виходить");
                    result.ArrayFloat[i] = 0;
                    continue;
                }

                result.ArrayFloat[i] = vector1.ArrayFloat[i] - vector2.ArrayFloat[i];
            }

            return result;
        }

        // Перевантаження бінарної операції віднімання для вектора і скаляра float
        public static VectorFloat operator -(VectorFloat vector1, float scalar)
        {
            VectorFloat vector = new VectorFloat(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector1.ArrayFloat[i] < scalar)
                {
                    //throw new InvalidOperationException("Віднімання може призвести до від'ємного результату.");
                    Console.WriteLine("Відємне значення виходить");
                    vector.ArrayFloat[i] = 0;
                    continue;
                }

                vector.ArrayFloat[i] = vector1.ArrayFloat[i] - scalar;
            }

            return vector;
        }

        // Перевантаження бінарної операції множення для двох векторів
        public static VectorFloat operator *(VectorFloat left, VectorFloat right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (left.num != right.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayFloat[i] > float.MaxValue / right.ArrayFloat[i])
                {
                    throw new OverflowException("При множенні елементів виникло переповнення.");
                }
                result.ArrayFloat[i] = left.ArrayFloat[i] * right.ArrayFloat[i];
            }

            return result;
        }

        // Перевантаження бінарної операції множення для вектора і скаляра float
        public static VectorFloat operator *(VectorFloat vector1, float scalar)
        {
            VectorFloat vector = new VectorFloat(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                vector.ArrayFloat[i] = vector1.ArrayFloat[i] * scalar;
            }

            return vector;
        }

        // Перевантаження бінарної операції ділення для двох векторів
        public static VectorFloat operator /(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorFloat result = new VectorFloat(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                /*if (vector2.ArrayFloat[i] == 0)
                {
                    throw new InvalidOperationException("Є нульові елементи");
                }*/

                result.ArrayFloat[i] = vector1.ArrayFloat[i] / vector2.ArrayFloat[i];
            }

            return result;
        }

        // Перевантаження бінарної операції ділення для вектора і скаляра float
        public static VectorFloat operator /(VectorFloat vector1, float scalar)
        {
            VectorFloat vector = new VectorFloat(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                if (scalar == 0)
                {
                    throw new InvalidOperationException("Не допустиме ділення на нуль");
                }

                vector.ArrayFloat[i] = vector1.ArrayFloat[i] / scalar;
            }

            return vector;
        }

        // Перевантаження бінарної операції остачі від ділення для двох векторів
        public static VectorFloat operator %(VectorFloat vector1, VectorFloat vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (vector1.num != vector2.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            VectorFloat result = new VectorFloat(vector1.num);

            // Додавання відповідних елементів
            for (uint i = 0; i < vector1.num; i++)
            {
                if (vector2.ArrayFloat[i] == 0)
               /* {
                    throw new InvalidOperationException("Є нульові елементи");
                }*/

                result.ArrayFloat[i] = vector1.ArrayFloat[i] % vector2.ArrayFloat[i];
            }

            return result;
        }

        // Перевантаження бінарної операції остачі від ділення для вектора і скаляра float
        public static VectorFloat operator %(VectorFloat vector1, float scalar)
        {
            VectorFloat vector = new VectorFloat(vector1.num);
            if (vector1 == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            for (uint i = 0; i < vector1.num; i++)
            {
                if (scalar == 0)
                {
                    throw new InvalidOperationException("Не допустиме ділення на нуль");
                }

                vector.ArrayFloat[i] = vector1.ArrayFloat[i] % scalar;
            }

            return vector;
        }
        
        public static VectorFloat operator |(VectorFloat left, VectorFloat right)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayFloat[i] = (int)left.ArrayFloat[i] | (int)right.ArrayFloat[i];
            }

            return result;
        }
        public static VectorFloat operator |(VectorFloat vector, float scalar)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayFloat[i] = (int)vector.ArrayFloat[i] | (int)scalar;
            }

            return result;
        }
        public static VectorFloat operator ^(VectorFloat left, VectorFloat right)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayFloat[i] = (int)left.ArrayFloat[i] ^ (int)right.ArrayFloat[i];
            }

            return result;
        }
        public static VectorFloat operator ^(VectorFloat vector, float scalar)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayFloat[i] = (int)vector.ArrayFloat[i] ^ (int)scalar;
            }

            return result;
        }
        public static VectorFloat operator &(VectorFloat left, VectorFloat right)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayFloat[i] = (int)left.ArrayFloat[i] & (int)right.ArrayFloat[i];
            }

            return result;
        }
        public static VectorFloat operator &(VectorFloat vector, float scalar)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayFloat[i] = (int)vector.ArrayFloat[i] & (int)scalar;
            }

            return result;
        }
        public static VectorFloat operator >>(VectorFloat vector, int shift)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(vector.num);

            for (uint i = 0; i < vector.num; i++)
            {
                result.ArrayFloat[i] = (int)vector.ArrayFloat[i] >> shift;
            }

            return result;
        }
        public static VectorFloat operator <<(VectorFloat left, int shift)
        {
            // Перевірка на валідність вхідних параметрів може бути додана за необхідності
            VectorFloat result = new VectorFloat(left.num);

            for (uint i = 0; i < left.num; i++)
            {
                result.ArrayFloat[i] = (int)left.ArrayFloat[i] << shift;
            }

            return result;
        }

        public static bool operator ==(VectorFloat left, VectorFloat right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            if (left.num != right.num)
                return false;

            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayFloat[i] != right.ArrayFloat[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(VectorFloat left, VectorFloat right)
        {
            return !(left == right);
        }
        public static bool operator >(VectorFloat left, VectorFloat right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (left.num != right.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayFloat[i] <= right.ArrayFloat[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator <(VectorFloat left, VectorFloat right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (left.num != right.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayFloat[i] >= right.ArrayFloat[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator >=(VectorFloat left, VectorFloat right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (left.num != right.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayFloat[i] < right.ArrayFloat[i])
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator <=(VectorFloat left, VectorFloat right)
        {
            if (left == null || right == null)
            {
                throw new ArgumentNullException("Вхідні вектори не можуть бути нульовими.");
            }
            if (left.num != right.num)
            {
                throw new ArgumentException("Розмірності векторів повинні бути однаковими.");
            }
            for (uint i = 0; i < left.num; i++)
            {
                if (left.ArrayFloat[i] > right.ArrayFloat[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static implicit operator float(VectorFloat vector)
        {
            if (vector.num != 1)
            {
                throw new InvalidOperationException("Вектор повинен мати розмірність 1 для приведення до типу float.");
            }

            return vector.ArrayFloat[0];
        }

        public static implicit operator VectorFloat(float value)
        {
            return new VectorFloat(1, value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VectorFloat v1 = new VectorFloat(3, 2.5f);
            VectorFloat v2 = new VectorFloat(3, 3.5f);
            VectorFloat v3 = v1 + v2;
            v3.Print();
            v3--;
            v3.Print();
        }
    }
}

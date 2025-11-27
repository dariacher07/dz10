namespace BuildingLibrary
{
    public class Building
    {
        private static int generationBuildingNumber = 0;
        private int buildingNumber; // номер дома
        private double height; // высота
        private int floor; // этажи
        private int apartment;// количество квартир
        private int entrance; // количество подъездов
        private static int BuildingNumberGeneration()
        {
            return ++generationBuildingNumber;
        }
        public int BuildingNumber
        {
            get
            {
                return buildingNumber;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
            }
        }
        public int Apartment
        {
            get
            {
                return apartment;
            }
            set
            {
                apartment = value;
            }
        }
        public int Entrance
        {
            get
            {
                return entrance;
            }
            set
            {
                entrance = value;
            }
        }

        public double FloorHeight
        {
            get
            {
                if (floor > 0)
                {
                    return height / floor;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double ApartmentsEntrance
        {
            get
            {
                if (entrance > 0)
                {
                    return apartment / entrance;
                }
                else
                {
                    return 0;
                }
            }
        }

        public double ApartmentsFloor
        {
            get
            {
                if (floor > 0)
                {
                    return apartment / floor;
                }
                else
                {
                    return 0;
                }
            }
        }
        internal Building(double height, int floor, int apartment, int entrance)
        {
            buildingNumber = BuildingNumberGeneration();
            if (height <= 0 || floor <= 0 || apartment <= 0 || entrance <= 0)
            {
                Console.WriteLine("Ошибка. Значения должны быть больше нуля.");
            }
            if (entrance > 0 && apartment % entrance != 0)
            {
                Console.WriteLine("Ошибка. Количество квартир должно делиться нацело на количество подъездов.");
            }
            if (floor > 0 && apartment % floor != 0)
            {
                Console.WriteLine("Ошибка. Количество квартир должно делиться нацело на количество этажей.");
            }
            this.height = height;
            this.floor = floor;
            this.apartment = apartment;
            this.entrance = entrance;
        }
        public void Filling1()
        {
            Console.WriteLine($"Номер дома: {buildingNumber}");
            Console.WriteLine($"Высота дома: {height}");
            Console.WriteLine($"Кол-во этажей: {floor}");
            Console.WriteLine($"Кол-во квартир: {apartment}");
            Console.WriteLine($"Кол-во подъездов: {entrance}");
            Console.WriteLine($"Высота этажа: {FloorHeight}");
            Console.WriteLine($"Квартир в подъезде: {ApartmentsEntrance}");
            Console.WriteLine($"Квартир на этаже: {ApartmentsFloor}");
        }
    }
}

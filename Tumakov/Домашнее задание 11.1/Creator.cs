public static class Creator
{
    private static Dictionary<int, Building> buildings = new Dictionary<int, Building>();
    internal static Building CreateBuild(double height, int floor, int apartment, int entrance)
    {
        Building newBuilding = new Building(height, floor, apartment, entrance);
        buildings[newBuilding.BuildingNumber] = newBuilding;
        return newBuilding;
    }
    public static bool RemoveBuilding(int buildingNumber)
    {
        return buildings.Remove(buildingNumber);
    }
    internal static Building GetBuilding(int buildingNumber)
    {
        if (buildings.TryGetValue(buildingNumber, out Building building))//получаем значение из словаря
        {
            return building;
        }
        else
        {
            Console.WriteLine("Здания нет");
            return null;
        }
    }
    public static void PrintInfo()
    {
        if (buildings.Count == 0)
        {
            Console.WriteLine("Нет зданий.");
            return;
        }
        foreach (Building building in buildings.Values)
        {
            building.Filling1();
        }
    }
}
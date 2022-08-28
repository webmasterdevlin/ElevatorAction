using ElevatorAction.Contracts;

namespace ElevatorAction.Parts;

public class ElevatorCar : IElevatorCar
{
    public int LastFloor { get; set; }
    public bool IsDoorOpen { get; private set; }
    public int TimeOfArrival { get; set; }
    public List<int> MidRequestedFloors { get; } = new();
    public int FloorWithEmergency { get; private set; }


    public void SetFloorOnEmergency(int floor)
    {
        FloorWithEmergency = floor;
    }

    public void GenerateNewRequestedFloor()
    {
        var newMidRequestedFloor = new Random().Next(1, LastFloor);
        if (MidRequestedFloors.Contains(newMidRequestedFloor)) return;

        MidRequestedFloors.Add(newMidRequestedFloor);
        Console.WriteLine($"{newMidRequestedFloor} floor was pressed.");
    }

    public void OpenDoor()
    {
        IsDoorOpen = true;
        Console.WriteLine("Door is opening");
    }

    public void ShuttingDoor()
    {
        IsDoorOpen = false;
        Console.WriteLine("Door is closing");
    }
}
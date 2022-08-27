namespace ElevatorAction;

// elevator implementation
public class Elevator : IFeatures
{
    private const int FloorIntervalInSeconds = 2;

    public Elevator(int floors)
    {
        LastFloor = floors;
    }

    private int CurrentFloor { get; set; }
    private int DestinationFloor { get; set; }
    private int LastFloor { get; }
    private bool IsDoorOpen { get; set; }
    private int TimeOfArrival { get; set; }
    private int FloorWithEmergency { get; set; }
    private bool HasSetFloorWithEmergency { get; set; }
    private List<int> MidRequestedFloors { get; set; } = new();
    private bool HasEnableMultiFloorRequests { get; set; }

    public void SetFloorOnEmergency(int floor)
    {
        FloorWithEmergency = floor;
        HasSetFloorWithEmergency = true;
    }

    public string GetLiftDirection()
    {
        return CurrentFloor > DestinationFloor ? "Down" : "Up";
    }

    public int GetEstimatedTimeOfWaiting(int floorsDifference, int floorIntervalInSeconds)
    {
        return floorsDifference * FloorIntervalInSeconds;
    }
    
    public void EnableMultiFloorRequests() => HasEnableMultiFloorRequests = true;


    public void GoToSpecifiedFloor()
    {
        if (CurrentFloor == DestinationFloor)
            OpenDoors();
        
        else
        {
            if (IsDoorOpen)
                ShuttingDoor();

            var floorsDifference = Math.Abs(CurrentFloor - DestinationFloor);
            TimeOfArrival = floorsDifference * FloorIntervalInSeconds;
            Console.WriteLine($"The {DestinationFloor} floor is {TimeOfArrival} seconds away");
            for (var i = 0; i < floorsDifference; i++)
            {
                if (HasEnableMultiFloorRequests)
                    GenerateNewRequestedFloor();

                if (FloorWithEmergency == CurrentFloor)
                {
                    DestinationFloor = CurrentFloor;
                    Console.WriteLine($"Emergency on {FloorWithEmergency} floor! Door will open immediately!");
                    OpenDoors();
                    return;
                }

                if (MidRequestedFloors.Contains(CurrentFloor))
                {
                    Console.WriteLine($"Stops at {CurrentFloor} floor");
                    OpenDoors();
                }

                Step();
            }

            Console.WriteLine($"You are on {CurrentFloor} floor");
            OpenDoors();
        }
    }

    public void GoToFloor(int floor)
    {
        if (LastFloor < floor || floor <= -1)
            throw new ArgumentOutOfRangeException(nameof(floor), "Floor does not exist");

        DestinationFloor = floor;
        GoToSpecifiedFloor();
    }

    public void SetUserFloorOrigin(int floor)
    {
        if (LastFloor < floor || floor <= -1)
            throw new ArgumentOutOfRangeException(nameof(floor), "Floor does not exist");

        CurrentFloor = floor;
    }


    private void Step()
    {
        Console.WriteLine($"On {CurrentFloor} floor");
        Console.WriteLine($"Going {GetLiftDirection()}");

        if (CurrentFloor > DestinationFloor)
            --CurrentFloor;
        else
            ++CurrentFloor;
    }

    private void GenerateNewRequestedFloor()
    {
        var newMidRequestedFloor = new Random().Next(1, LastFloor);
        if (MidRequestedFloors.Contains(newMidRequestedFloor)) return;
        
        MidRequestedFloors.Add(newMidRequestedFloor);
        Console.WriteLine($"{newMidRequestedFloor} floor was pressed.");
    }

    private void OpenDoors()
    {
        IsDoorOpen = true;
        Console.WriteLine("Door is opening");
    }

    private void ShuttingDoor()
    {
        IsDoorOpen = false;
        Console.WriteLine("Door is closing");
    }
}
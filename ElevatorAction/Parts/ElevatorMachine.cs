using ElevatorAction.Contracts;

namespace ElevatorAction.Parts;

public class ElevatorMachine : IElevatorMachine
{
    private const int FloorIntervalInSeconds = 2;
    private readonly ElevatorCar _elevatorCar;

    public ElevatorMachine(int floors, ElevatorCar elevatorCar)
    {
        LastFloor = floors;
        elevatorCar.LastFloor = floors;
        _elevatorCar = elevatorCar;
    }

    private int CurrentFloor { get; set; }
    private int DestinationFloor { get; set; }
    private int LastFloor { get; }
    private bool HasEnableMultiFloorRequests { get; set; }

    public string GetLiftDirection()
    {
        return CurrentFloor > DestinationFloor ? "Down" : "Up";
    }

    public void EnableMultiFloorRequests()
    {
        HasEnableMultiFloorRequests = true;
    }

    public int GetEstimatedTimeOfWaiting(int floorsDifference, int floorIntervalInSeconds)
    {
        return floorsDifference * floorIntervalInSeconds;
    }

    public void GoToSpecifiedFloor()
    {
        if (CurrentFloor == DestinationFloor)
        {
            _elevatorCar.OpenDoors();
        }

        else
        {
            if (_elevatorCar.IsDoorOpen)
                _elevatorCar.ShuttingDoor();

            var floorsDifference = Math.Abs(CurrentFloor - DestinationFloor);
            _elevatorCar.TimeOfArrival = GetEstimatedTimeOfWaiting(floorsDifference, FloorIntervalInSeconds);
            Console.WriteLine($"The {DestinationFloor} floor is {_elevatorCar.TimeOfArrival} seconds away");
            for (var i = 0; i < floorsDifference; i++)
            {
                if (HasEnableMultiFloorRequests)
                    _elevatorCar.GenerateNewRequestedFloor();

                if (_elevatorCar.FloorWithEmergency == CurrentFloor)
                {
                    DestinationFloor = CurrentFloor;
                    Console.WriteLine(
                        $"Emergency on {_elevatorCar.FloorWithEmergency} floor! Door will open immediately!");
                    _elevatorCar.OpenDoors();
                    return;
                }

                if (_elevatorCar.MidRequestedFloors.Contains(CurrentFloor))
                {
                    Console.WriteLine($"Stops at {CurrentFloor} floor");
                    _elevatorCar.OpenDoors();
                }

                Step();
            }

            Console.WriteLine($"You are on {CurrentFloor} floor");
            _elevatorCar.OpenDoors();
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
}
namespace ElevatorAction.Contracts;

public interface IElevatorMachineDriver
{
    string GetLiftDirection();
    int GetEstimatedTimeOfWaiting(int floorsDifference, int floorIntervalInSeconds);
    void EnableMultiFloorRequests();
    void GoToSpecifiedFloor();
    void GoToFloor(int floor);
    void SetUserFloorOrigin(int floor);
}
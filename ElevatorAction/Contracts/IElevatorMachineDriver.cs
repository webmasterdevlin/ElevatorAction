namespace ElevatorAction.Contracts;

public interface IElevatorMachineDriver
{
    string GetElevatorDirection();
    int GetEstimatedTimeOfWaiting(int floorsDifference, int floorIntervalInSeconds);
    void EnableMultiFloorRequests();
    void GoToSpecifiedFloor();
    void GoToFloor(int floor);
    void SetUserFloorOrigin(int floor);
}
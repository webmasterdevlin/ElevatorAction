namespace ElevatorAction;

public interface IFeatures
{
    void GoToSpecifiedFloor();
    string GetLiftDirection();
    int GetEstimatedTimeOfWaiting(int floorsDifference, int floorIntervalInSeconds);
    void SetFloorOnEmergency(int floor);
}
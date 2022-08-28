using ElevatorAction.Parts;

/* set your variations of maximum floors, the origin and destination */
const int maxFloor = 10;
const int emergencySimulationFloor = 9;
const int originFloor = 0;
const int destinationFloor = 10;

var elevatorCar = new ElevatorCar();
elevatorCar.SetFloorOnEmergency(emergencySimulationFloor); // uncomment to set emergency floor

var machineDriver = new ElevatorMachineDriverDriver(maxFloor, elevatorCar);
machineDriver.SetUserFloorOrigin(originFloor);
machineDriver.EnableMultiFloorRequests(); // uncomment to enable multi-floor requests
machineDriver.GoToFloor(destinationFloor);

Console.ReadLine();
using ElevatorAction.Parts;


const int maxFloor = 10;

var elevatorCar = new ElevatorCar();
elevatorCar.SetFloorOnEmergency(9); // uncomment to set emergency floor

var elevatorMachine = new ElevatorMachine(maxFloor, elevatorCar);
elevatorMachine.SetUserFloorOrigin(0);
elevatorMachine.EnableMultiFloorRequests(); // uncomment to enable multi-floor requests
elevatorMachine.GoToFloor(10);

Console.ReadLine();
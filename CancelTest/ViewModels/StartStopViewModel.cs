namespace CancelTest.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    public class StartStopViewModel : ViewModelBase
    {
        public StartStopViewModel(Machine controlledMachine) 
        {
            ControlledMachine = controlledMachine;
            StartMachine = new Command(OnStartMachineExecute);
            StopMachine = new Command(OnStopMachineExecute);
        }

        [Model]
        public Machine ControlledMachine
        {
            get { return GetValue<Machine>(ControlledMachineProperty); }
            private set { SetValue(ControlledMachineProperty, value); }
        }

        public static readonly PropertyData ControlledMachineProperty = RegisterProperty("ControlledMachine", typeof(Machine));

        public override string Title { get { return "Set Machine state"; } }

        public Command StartMachine { get; private set; }
        public Command StopMachine { get; private set; }

        private void OnStartMachineExecute()
        {
            ControlledMachine.Running = true;
            this.CloseViewModel(true);
        }

        private void OnStopMachineExecute()
        {
            ControlledMachine.Running = false;
            this.CloseViewModel(true);
        }
    }
}

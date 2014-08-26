namespace CancelTest.ViewModels
{
    using Catel.IoC;
    using Catel.Data;
    using Catel.MVVM;
    using Catel.MVVM.Services;
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ViewStartStopUICommand = new Command(OnViewStartStopUICommandExecute);
            CurrentMachine = new Machine();
        }
        
        public override string Title { get { return "Cancel test"; } }

        [Model]
        public Machine CurrentMachine
        {
            get { return GetValue<Machine>(CurrentMachineProperty); }
            private set { SetValue(CurrentMachineProperty, value); }
        }

        public static readonly PropertyData CurrentMachineProperty = RegisterProperty("CurrentMachine", typeof(Machine));

        public Command ViewStartStopUICommand { get; private set; }

        private void OnViewStartStopUICommandExecute()
        {
            StartStopViewModel viewModel = new StartStopViewModel(CurrentMachine);
            this.GetServiceLocator().ResolveType<UIVisualizerService>().ShowDialog(viewModel);
        }
    }
}
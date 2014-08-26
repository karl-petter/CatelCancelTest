namespace CancelTest.Views
{
    using Catel.Windows;
    using ViewModels;

    public partial class StartStopView : DataWindow
    {
        public StartStopView()
            : this(null) { }

        public StartStopView(StartStopViewModel viewModel)
            : base(viewModel,DataWindowMode.OkCancel)
        {
            InitializeComponent();
        }
    }
}

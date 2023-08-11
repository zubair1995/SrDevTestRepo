using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SrDevTest.Control
{	
	public partial class NavigationButton : ContentView
	{	
		public NavigationButton ()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NavigationButton), default(ICommand),propertyChanged: CommandPropertyChanged);
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                     propertyName: "TitleText",
                                                     returnType: typeof(string),
                                                     declaringType: typeof(NavigationButton),
                                                     defaultValue: "",
                                                     defaultBindingMode: BindingMode.TwoWay,
                                                     propertyChanged: TitleTextPropertyChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
        public Command OnTap => new Command(() => Execute(Command));
        public string TitleText
        {
            get { return base.GetValue(TitleTextProperty).ToString(); }
            set { base.SetValue(TitleTextProperty, value); }
        }
        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (NavigationButton)bindable;
            control.NavBtn.Text = newValue.ToString();
        }
        private static void CommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (NavigationButton)bindable;
            control.NavBtn.Command = (ICommand)newValue;
        }
    }

}



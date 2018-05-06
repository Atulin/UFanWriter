using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UFanWriter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            Window.Current.SetTitleBar(DraggableTitlebar);
        }

        // Open sidebar
        private void SidebarBtn_Click(object sender, RoutedEventArgs e)
        {
            SV_Sidebar.IsPaneOpen = !SV_Sidebar.IsPaneOpen;
        }

        // Settings flyout closing
        private void Flyout_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            PaperColourBtn.Foreground = new SolidColorBrush(PaperColorPicker.Color);
        }

        // Handle menu buttons
        private void Sidebar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dbg = e.ClickedItem as Grid;

            MainTextBlock.PlaceholderText += dbg.Name + Environment.NewLine;
        }

        // Color picker changing color
        private void PaperColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            PaperColourBtn.Foreground= new SolidColorBrush(PaperColorPicker.Color);
            ToolbarGrid.Background = new SolidColorBrush(PaperColorPicker.Color);
            MainTextBlock.Background = new SolidColorBrush(PaperColorPicker.Color);
        }

    }
}

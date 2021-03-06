/* First of all, take “Blank App” template, give it a name “ExtendedSplash.xaml” and customize your main grid like this. */
<Grid> 
    <Image x:Name="extendedSplashImage" Source="Images/SplashScreen.png" Stretch="Fill"/> 
    <Canvas> 
        <ProgressBar IsIndeterminate="True" Maximum="100" Value="30" Height="10" Width="400"/> 
    </Canvas> 
</Grid>

// Now in “ExtendedSplash.xaml.cs” put this method below and call it from the constructor, like this. 
public ExtendedSplash() 
{
  this.InitializeComponent();     
  //Call MainPage from ExtendedSplashScreen after some delay  
  ExtendedSplashScreen(); 
} 
  
private async void ExtendedSplashScreen()
{
  await Task.Delay(TimeSpan.FromSeconds(3));  
  // set your desired delay 
  Frame.Navigate(typeof(MainPage));
  // call MainPage 
}
// Then we must change the starting page of the project
// In the App.xaml.cs , in the OnLaunched method change the "rootFrame.Navigate(typeof(MainPage), e.Arguments)”

if (!rootFrame.Navigate(typeof(ExtendedSplash), e.Arguments))
{
  throw new Exception("Failed to create initial page");
}

// The Last Step is handling the backButton evend handler in MainPage.xaml.cs

void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e) 
{ 
    Frame frame = Window.Current.Content as Frame; 
    if (frame == null) 
    { 
        return; 
    } 
  
    if (frame.CanGoBack) 
    { 
        frame.GoBack(); 
        //Indicate the back button press is handled so the app does not exit 
        e.Handled = true; 
    } 
}

// So, we just need to remove the “Back State” so that our app can exit.
// To do so, just put this code inside the “OnNavigatedTo” method. 
// Check if ExtendedSplashscreen.xaml is on the backstack  and remove

protected override void OnNavigatedTo(NavigationEventArgs e)
{
  if (Frame.BackStack.Count() == 1) 
  {
    Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1); 
  }
}

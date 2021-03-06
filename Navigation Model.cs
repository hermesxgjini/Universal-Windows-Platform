//-->Back Key handing

// This Must be coded in app.cs
// Blank App does not include Back key handling but Hub App,Pivot App does
// Included in 
// /Common/NavigationHelper class
// Couses a backwards Page navigation
// If you need to override this, replace 
// with your own code for custom navigation handling

public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;
    // Initializing the method in the constructor
    HardwareButtons.BackPressed += HardwareButtons_BackPressed;
}
...
...
private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
{
    Frame frame = Window.Current.Content as Frame;
    if(frame == null) return ;
    
    if(frame.CanGoBack)
    {
        frame.GoBack();
        e.Handled = true;
    }
}

//--> Check what the current platform is?
if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
    Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed; 
// still in developer preview


//--> Back for Universal Windows Apps

// One event to rule them all
// The back button is now avaible everywhere!
// Title bar UI can be opted in to for Windowed mode
// Back in tablet mode works just like the back button on Phone
// Need to handle BackRequested for the page to page navigation and to dismiss temporary UI



//--> Navigating Back using a button instead of the HardwareButtons BackPressed event

// Application ca execute logic to navigate back to precending page
// Navigating back by using a button click event

private void btnGoBack_Click(object sender, RoutedEventArgs e)
{
    if(this.Frame.CanGoBack)
        this.Frame.GoBack();
}


//-->Navigations between pages by using a ListView item event

/// <summary>
/// Shows the details of an item clicked on in the <see cref="ItemPage"/>
/// </summary>

private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
{
    // Navigate to the appropriate destination page, configuring the new page
    // by passing required information as a navigation paramenter
    var itemId = ((MyListViewItem)e.ClickedItem).UniqueId;
    Frame.Navigate(typeof(MyDetailPage), itemId);
    if (!Frame.Navigate(typeof(ItemPage), itemId))
    {
        throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
    }
}

// the most generic version is by using it with an botton click event 
// here we navigate to a new page called SecondPage by clicking the botton
// for good visual effects make sure you use Page Transitions (everybody loves eye candy)

private void Button_Click(object sender, RoutedEventArgs e)
{
    Frame.Navigate(typeof(SecondPage) );
}

// we can also send information to the second page 
Frame.Navigate(typeof(SecondPage), "Hola from the Main Page!" );
// you can retrieve the object from the OnNavigatedTo method of the second page by doing this
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    myTextBlock.Text = e.Parameter as String;
}

// Fram.Navigate() creates a new instance of a Page and loads it into the entire viewable area of the Frame.
// Page has a frame property for easy navigation to it's container.
// The Frame keeps track of its history of pages, and supports methods to traverse it.
// It also suppots caching of Pages

// you can also pass a class as an object 

class NavigationContext
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
// this is on MainPage.xaml.cs
private void GoForwardButton_Click(object sender, RoutedEventArgs e)
{
    Frame.Navigate(typeof(SecondPage), new NavigationContext
    {
        Id = 7,
        Name = "Hermes Gjini",
        Description = "These are my Credentials"
    });
}
// this is on SecondPage.xaml.cs
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    //myTextBlock.Text = e.Parameter as String;
    var result = e.Parameter as NavigationContext;
    this.DataContext = result;
}

// This must be coded in App.cs

// What to do on resuming?
// Check external data or conditions that might change while the app was suspended
// Possibly factoring in the time elapsed between suspension and resumption
// Examples:  (taken from http://bit.ly/w8Resuming)
//  -refresh data from an online source
//  -refresh the apps view of connectivity-online or offline?
//  -refresh sensor data such as compass,geolocation
//  -retry a networking call that may have failed while suspended
//  -refresh layout-device may have reorientated sice suspension
//  -check for new data populated by background tacks or system roaming


sealed partial class App:Application
{
    public App()
    {
       this.InitialezeComponent();
       this.Suspending += OnSuspending;
       this.Resuming += OnResuming;
    }

    private void OnResuming(object sender,Object e)
    {
       // TODO: watever you need to do to resume your app
    }
.....
.....

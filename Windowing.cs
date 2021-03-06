// Having Multiple Application Views
// first you create a new view 
// than you switch to the new view 
// and finally you stay in the newly crated view

Windows.ApplicationModel.Core.CoreApplication.CreateNewView
Windows.UI.ViewManagement.ApplicationViewSwitcher.SwitchAsync
Windows.UI.ViewManagement.ApplicationViewSwitcher.TryStandaloneAsync

// opt-in to the new activation policy

ApplicationViewSwitcher.DisableSystemViewActivationPolicy();

// ViewSwitcher on activated event args

ViewSwitcher.ShowStandaloneAsync(viewID);

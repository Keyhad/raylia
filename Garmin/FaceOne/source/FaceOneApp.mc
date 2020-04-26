using Toybox.Application as App;
using Toybox.WatchUi as Ui;
using Toybox.System as Sys;
using Toybox.Graphics as Gfx;

class FaceOneApp extends App.AppBase {

    function initialize() {
        AppBase.initialize();
    }

    // onStart() is called on application start up
    function onStart(state) {
        Sys.println("onStart");
    }

    // onStop() is called when your application is exiting
    function onStop(state) {
        Sys.println("onStop");
    }

    // Return the initial view of your application here
    function getInitialView() {
        return [ new FaceOneView() ];
    }

    // New app settings have been received so trigger a UI update
    function onSettingsChanged() {
    	Sys.println("onSettingsChanged");
        Ui.requestUpdate();
    }

}
using Toybox.WatchUi as Ui;
using Toybox.Graphics as Gfx;
using Toybox.System as Sys;
using Toybox.Lang as Lang;
using Toybox.Application as App;
using Toybox.Time as Time;
using Toybox.Time.Gregorian as Calendar;

class FaceOneView extends Ui.WatchFace {

	var font;
	function initialize() {
        WatchFace.initialize();
    }

    // Load your resources here
    function onLayout(dc) {
		font = Ui.loadResource(Rez.Fonts.id_font_abhaya);    
        setLayout(Rez.Layouts.WatchFace(dc));
    }

    // Called when this View is brought to the foreground. Restore
    // the state of this View and prepare it to be shown. This includes
    // loading resources into memory.
    function onShow() {
    }

    // Update the view
    function onUpdate(dc) {
		var now = Time.now();
        var info = Calendar.info(now, Time.FORMAT_SHORT);
        var longInfo = Calendar.info(now, Time.FORMAT_LONG);
        
        var banana = 98;
        var hamburger = 104;
        var pizza = 112;
        var beer = 101;
        var nodllar = 110;
        var iceCream = 105;
        var energyString = "" + 
        	banana.toChar() + 
        	hamburger.toChar() + 
        	beer.toChar() +
        	pizza.toChar() +
        	//nodllar.toChar() +
        	//iceCream.toChar() +
        	"";

		var year = info.year - 2000;
        var dateString = Lang.format("$1$-$2$-$3$", 
        	[year.format("%02d"), info.month.format("%02d"), info.day.format("%02d")]);
        var timeString = Lang.format("$1$:$2$",	[info.hour, info.min.format("%02d")]);
		Sys.println("timeString: " + timeString);

        var weekString = " w" + new SwedishCal().getWeekNumber(now);               
		var dateElement = putStr("DateLabel", dateString + weekString);	
		
		//dateElement.setColor(Gfx.COLOR_WHITE);
		//timeElement.setColor(Gfx.COLOR_BLACK);
			
        View.onUpdate(dc);
        
        var width = dc.getWidth();
        var height = dc.getHeight();
 		var bx = width / 2;
        var by = (height - 110) / 2;
        var battery = Sys.getSystemStats().battery;
        if (battery > 20.0f)
        {
        	dc.setColor(Gfx.COLOR_WHITE, Gfx.COLOR_TRANSPARENT);
        }
        else if (battery > 10.0f)
        {
        	dc.setColor(Gfx.COLOR_LT_GRAY, Gfx.COLOR_TRANSPARENT);
        }
		else
		{
        	dc.setColor(Gfx.COLOR_DK_GRAY, Gfx.COLOR_TRANSPARENT);
		}        
        		
        dc.drawText(bx, by, font, timeString, Gfx.TEXT_JUSTIFY_CENTER);
        dc.drawText(bx, by + 40, font, energyString, Gfx.TEXT_JUSTIFY_CENTER);        
    }

    // Called when this View is removed from the screen. Save the
    // state of this View here. This includes freeing resources from
    // memory.
    function onHide() {
    }

    // The user has just looked at their watch. Timers and animations may be started here.
    function onExitSleep() {
    }

    // Terminate any active timers and prepare for slow updates.
    function onEnterSleep() {
    }


	function putStr(placeholder, str) {
        // Update the view
        var view = View.findDrawableById(placeholder);
        view.setColor(App.getApp().getProperty("ForegroundColor"));
        view.setText(str);
        return view;
    }
    
	function putStrXy(placeholder, str, x, y) {
        // Update the view
        var view = View.findDrawableById(placeholder);
        view.setColor(App.getApp().getProperty("ForegroundColor"));
        view.setLocation(x, y);
        view.setText(str);
        return view;
    }    
}

using Toybox.WatchUi as Ui;
using Toybox.Application as App;
using Toybox.Graphics as Gfx;
using Toybox.ActivityMonitor as Act;
using Toybox.System as Sys;


class Background extends Ui.Drawable {

    function initialize() {
        var dictionary = {
            :identifier => "Background"
        };

        Drawable.initialize(dictionary);
    }

    function draw(dc) {               
        var doneResultRect = new [4];
        var height = dc.getHeight();
        var width = dc.getWidth();
        var centerX = height / 2;
        var centerY = width / 2;

        Sys.println("w : " + width + ", h: " + height);
        
        var activityInfo = Act.getInfo();
        var progress = 0;

		progress = activityInfo.steps * 1.0 / activityInfo.stepGoal;

        Sys.println("info: " + activityInfo.steps);
        Sys.println("steps done: " + progress);
        var doneResult = progress * height;

        doneResultRect[0] = [0, height - doneResult]; 
        doneResultRect[1] = [0, height]; 
        doneResultRect[2] = [width, height]; 
        doneResultRect[3] = [width, height - doneResult]; 
               
        var bc = App.getApp().getProperty("BackgroundColor");
        var pc = App.getApp().getProperty("ProgressColor");
		// Clear the screen
        dc.setColor(bc, bc);
        dc.fillRectangle(0, 0, dc.getWidth(), dc.getHeight());
                
        // Set the background color then call to clear the screen
        dc.setColor(pc, pc);
        dc.fillPolygon(doneResultRect);       
             
        //dc.clear();
    }

}

using Toybox.WatchUi as Ui;
using Toybox.Graphics as Gfx;
using Toybox.System as Sys;
using Toybox.Lang as Lang;
using Toybox.Application as App;
using Toybox.Time as Time;
using Toybox.Time.Gregorian as Calendar;

class SwedishCal extends GenericCal  {

	const daysInMonth = [0, 31, 29, 31, 30, 31, 30, 
				31, 31, 30, 31, 30, 31];
	
	// first day in first week starts with theses numbere since 2016 
	const firstDays = [5, 7, 1, 2, 3, 5, 6, 7];
	
    function initialize() {
    	GenericCal.initialize();
    }
    
    function getWeekNumber(now)
    {
        var info = Calendar.info(now, Time.FORMAT_SHORT);
        var dayOne = firstDays[info.year - 2016];           
        var todayInYear = info.day;
        var leapYear = (info.year % 4) == 0;
        Sys.println("leapYear: " + leapYear);
        if (leapYear)
        {
        	todayInYear--;
        }
        
        for (var i = info.month - 1; i > 0; i -= 1)
        {
       		todayInYear += daysInMonth[i];
        } 
        
    	return ((todayInYear - dayOne) / 7) + 2;
    }
    
}
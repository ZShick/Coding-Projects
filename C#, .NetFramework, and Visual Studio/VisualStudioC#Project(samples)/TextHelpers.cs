using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        //creating a helper method that takes in a string value and an integer. The int value is set to a default of 8 unless overidden
        public static string Truncate(this string value, int maxLength = 8)
        {
            //creating an ellipses variable to add onto the truncated string before it is returned
            string ellipses = "...";
            //checks to see if the string is null or not. If it is, there is no need to truncate so it is returned.
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            //if there it is not null then the following lambda expression is executed
            //it checks the value string length against the maxLength. If the value length is equal to or smaller then it is returned.
            //If it is greater than maxLength, then it is cut down to the size requested by the maxLength and is returned with the ellipses attached to the end
            else
            {
                return value.Length <= maxLength ? value : value.Substring(0, maxLength) + ellipses;
            }
        }
        public static string TimeAgo(this DateTime dateTime)
//This function takes a DateTime variable as a n argument and returns an easy to understand string that describes how long ago the given DateTime was
        {
            var timeSince = DateTime.Now.Subtract(dateTime);//Compares the given datetime to now

            string result;
            //the following else if statement returns the correct string that informs how long it has been since the given datetime
            if (timeSince <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSince.Seconds);
            }
            else if (timeSince <= TimeSpan.FromMinutes(60))
            {
                result = timeSince.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSince.Minutes) :
                    "about a minute ago";
            }
            else if (timeSince <= TimeSpan.FromHours(24))
            {
                result = timeSince.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSince.Hours) :
                    "about an hour ago";
            }
            else if (timeSince <= TimeSpan.FromDays(30))
            {
                result = timeSince.Days > 1 ?
                    String.Format("about {0} days ago", timeSince.Days) :
                    "yesterday";
            }
            else if (timeSince <= TimeSpan.FromDays(365))
            {
                result = timeSince.Days > 30 ?
                    String.Format("about {0} months ago", timeSince.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSince.Days > 365 ?
                    String.Format("about {0} years ago", timeSince.Days / 365) :
                    "about a year ago";
            }
            return result;
        }
    }
}
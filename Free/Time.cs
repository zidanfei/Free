using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Free
{
    class Time
    {
        Time()
        { }
        Time(string time)
        {
            string[] timevar = time.Split(':');
            this.hour = int.Parse(timevar[0]);
            this.minute = int.Parse(timevar[1]);
            if (timevar.Length > 2)
            {
                this.second = int.Parse(timevar[2]);
            }
        }
        int hour;
        /// <summary>
        /// 小时
        /// </summary>
        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        int minute;
        /// <summary>
        /// 分
        /// </summary>
        public int Minute
        {
            get { return minute; }
            set { minute = value; }
        }
        int second = 0;
        /// <summary>
        /// 秒
        /// </summary>
        public int Second
        {
            get { return second; }
            set { second = value; }
        }
        public static Time Parse(string time)
        {
            string[] timevar = time.Split(':');
            Time t = new Time();
            t.hour = int.Parse(timevar[0]);
            t.minute = int.Parse(timevar[1]);
            if (timevar.Length > 2)
            {
                t.second = int.Parse(timevar[2]);
            }
            return t;
        }
        public static int Compare(Time timefirst, Time timesecond)
        {
            if (timefirst.hour > timesecond.hour)
                return -1;
            if (timefirst.hour < timesecond.hour)
                return 1;
            if (timefirst.hour == timesecond.hour && timefirst.minute > timesecond.minute)
                return -1;
            if (timefirst.hour == timesecond.hour && timefirst.minute < timesecond.minute)
                return 1;
            if (timefirst.hour == timesecond.hour && timefirst.minute == timesecond.minute && timefirst.second > timesecond.second)
                return -1;
            if (timefirst.hour == timesecond.hour && timefirst.minute == timesecond.minute && timefirst.second < timesecond.second)
                return 1;
            return 0;
        }
        public int Compare(Time time)
        {
            if (this.hour > time.hour)
                return -1;
            if (this.hour < time.hour)
                return 1;
            if (this.hour == time.hour && this.minute > time.minute)
                return -1;
            if (this.hour == time.hour && this.minute < time.minute)
                return 1;
            if (this.hour == time.hour && this.minute == time.minute && this.second > time.second)
                return -1;
            if (this.hour == time.hour && this.minute == time.minute && this.second < time.second)
                return 1;
            return 0;
        }
        public int Compare(DateTime date)
        {
            Time t = new Time(date.ToShortTimeString());
            return this.Compare(t);
        }
        public string ToString()
        {
            return this.hour + ":" + this.minute + ":" + this.second;
        }
    }
}

using System;
using System.Globalization;

namespace TimeAndDateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // الحصول على الوقت والتاريخ الحالي
            DateTime now = DateTime.Now;
            
            // عرض الوقت الحالي
            Console.WriteLine("=== معلومات الوقت والتاريخ ===");
            Console.WriteLine($"الساعة: {now.Hour:00}:{now.Minute:00}:{now.Second:00}");
            Console.WriteLine($"اليوم: {GetDayNameInArabic(now.DayOfWeek)}");
            
            // التاريخ الميلادي
            Console.WriteLine($"التاريخ الميلادي: {now.ToString("dd/MM/yyyy")}");
            
            // التاريخ الهجري
            UmAlQuraCalendar hijriCalendar = new UmAlQuraCalendar();
            int hijriYear = hijriCalendar.GetYear(now);
            int hijriMonth = hijriCalendar.GetMonth(now);
            int hijriDay = hijriCalendar.GetDayOfMonth(now);
            
            Console.WriteLine($"التاريخ الهجري: {hijriDay:00}/{hijriMonth:00}/{hijriYear}");
            Console.WriteLine($"الشهر الهجري: {GetHijriMonthName(hijriMonth)}");
            
            Console.WriteLine("=== انتهى البرنامج ===");
        }
        
        // دالة للحصول على اسم اليوم باللغة العربية
        static string GetDayNameInArabic(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "الأحد";
                case DayOfWeek.Monday:
                    return "الاثنين";
                case DayOfWeek.Tuesday:
                    return "الثلاثاء";
                case DayOfWeek.Wednesday:
                    return "الأربعاء";
                case DayOfWeek.Thursday:
                    return "الخميس";
                case DayOfWeek.Friday:
                    return "الجمعة";
                case DayOfWeek.Saturday:
                    return "السبت";
                default:
                    return "غير معروف";
            }
        }
        
        // دالة للحصول على اسم الشهر الهجري
        static string GetHijriMonthName(int month)
        {
            string[] hijriMonths = {
                "محرم", "صفر", "ربيع الأول", "ربيع الثاني",
                "جمادى الأولى", "جمادى الثانية", "رجب", "شعبان",
                "رمضان", "شوال", "ذو القعدة", "ذو الحجة"
            };
            
            if (month >= 1 && month <= 12)
                return hijriMonths[month - 1];
            else
                return "غير معروف";
        }
    }
}



# نظرة عامة
هذا المشروع هو تطبيق بسيط لوحدة التحكم (Console Application) مكتوب بلغة C# يعرض الوقت الحالي (الساعة، الدقيقة، الثانية) واليوم، بالإضافة إلى التاريخ الميلادي والتاريخ الهجري.

# الميزات
- عرض الوقت الحالي بدقة (الساعة، الدقيقة، الثانية).
- عرض اليوم الحالي باللغة العربية.
- عرض التاريخ الميلادي بالصيغة (يوم/شهر/سنة).
- عرض التاريخ الهجري بالصيغة (يوم/شهر/سنة) مع اسم الشهر الهجري.
- استخدام أساسيات لغة C# بما في ذلك الفئات (Classes)، الكائنات (Objects)، الدوال (Methods)، والتعامل مع التاريخ والوقت.

# كيفية التشغيل

# المتطلبات
- .NET SDK 6.0 أو أحدث.

# خطوات التشغيل
1. استنساخ المستودع (إذا كان متاحًا) أو تحميل المشروع:
   إذا كان المشروع في مستودع Git، يمكنك استنساخه باستخدام الأمر:
   ```bash
   git clone <https://github.com/Shawqi-Ye/TimeADA.git>
   cd TimeAndDateApp
   ```
   وإلا، تأكد من أن لديك مجلد المشروع `TimeAndDateApp`.

2. التنقل إلى مجلد المشروع:
   افتح سطر الأوامر (Command Prompt أو Terminal) وانتقل إلى مجلد المشروع:
   ```bash
   cd TimeAndDateApp
   ```

3. تشغيل التطبيق:
   استخدم الأمر التالي لتشغيل التطبيق:
   ```bash
   dotnet run
   ```

   سيقوم التطبيق بعرض الوقت والتاريخ الحاليين في نافذة سطر الأوامر.

# هيكل المشروع

```
TimeAndDateApp/
├── TimeAndDateApp.csproj
├── Program.cs
└── README.md
```

- `TimeAndDateApp.csproj`: ملف المشروع الذي يحتوي على إعدادات المشروع ومرجعياته.
- `Program.cs`: ملف الكود المصدري الرئيسي الذي يحتوي على منطق التطبيق.
- `README.md`: هذا الملف الذي يحتوي على توثيق المشروع.

# الكود المصدري (`Program.cs`)

```csharp
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
```

# ملاحظات
- يستخدم هذا المشروع `UmAlQuraCalendar` لتحويل التاريخ إلى الهجري، وهو التقويم الرسمي المستخدم في المملكة العربية السعودية.
- تم تنسيق الوقت والتاريخ لضمان عرض الأرقام بصيغة مكونة من رقمين (مثل 05 بدلاً من 5) باستخدام `:{00}`.

 



using System;

namespace Library.API.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset, DateTimeOffset? dateOfDeath)
        {
            var dateToCaclulateTo = DateTime.UtcNow;
            if (dateOfDeath != null)
            {
                dateToCaclulateTo = dateOfDeath.Value.UtcDateTime;
            }
            var age = dateToCaclulateTo.Year - dateTimeOffset.Year;
            if (dateToCaclulateTo < dateTimeOffset.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}

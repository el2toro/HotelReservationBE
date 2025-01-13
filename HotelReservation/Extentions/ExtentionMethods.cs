namespace HotelReservation.Extentions
{
    public static class ExtentionMethods
    {
        public static DateTime ToDateTime(this string date)
        {
            return DateTime.Parse(date);
        }
    }
}

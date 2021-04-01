namespace CollegeM8
{
    public class NextEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateStr { get; set; }
        public string TimeStr { get; set; }

        public NextEvent(string title, string description, string dateStr, string timeStr)
        {
            Title = title;
            Description = description;
            DateStr = dateStr;
            TimeStr = timeStr;
        }
    }
}

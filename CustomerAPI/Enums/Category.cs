using System.ComponentModel;

namespace NotesAPI.Enums
{
    public enum Category
    {
        [Description("Meetings, important dues, etc")]
        Work = 1,
        [Description("Birthday parties, weddings, etc")]
        FamilyEvent = 2,
        [Description("Time to study")]
        Study = 3,
        [Description("Day to day activities: day to do the groceries, hairdresses appointments, etc")]
        General =4
    }
}

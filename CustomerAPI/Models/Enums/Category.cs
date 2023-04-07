﻿using System.ComponentModel;

namespace NotesAPI.Models.Enums
{
    public enum Category
    {
        None,
        [Description("Meetings, important dues, etc")]
        Work,
        [Description("Birthday parties, weddings, etc")]
        FamilyEvent,
        [Description("Time to study")]
        Study,
        [Description("Day to day activities: day to do the groceries, hairdresses appointments, etc")]
        General
    }
}

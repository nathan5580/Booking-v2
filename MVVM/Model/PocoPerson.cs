namespace MvvmExample.Model
{

    /// <summary>
    /// Poco class don't fire propertyChanged Event
    /// </summary>
    /// =====================================================================================
    /// Modification : Initial : 12/11/2018 |N.Wilcké (SESA474351)
    /// =====================================================================================
    class PocoPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}

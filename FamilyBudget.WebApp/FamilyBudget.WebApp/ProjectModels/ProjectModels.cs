namespace FamilyBudget.WebApp.ProjectModels
{
    using FamilyBudget.WebApp.Models;
    using System.Collections.Generic;

    public class ProjectModels
    {
        public class IEs_DuplicateIEs
        {
            public List<IE> IEs { get; set; }

            public List<DuplicateIE> DuplicateIEs { get; set; }
        }

    }
}
namespace TestManagmentSystem.Data.Common.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TestManagmentSystem.Data.Common.Contracts;

    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }
    }
}

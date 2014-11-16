namespace TestManagmentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using TestManagmentSystem.Data.Common.Base;

    public class File : DeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }
    }
}

using App.Domain.Core.Entities;

namespace App.Domain.Core.DtoModels.Services
{
    public class ServiceCategoryOutputModel
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; } = null!;
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Services;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        List<ServiceCategoryOutputModel> IServiceRepository.GetServiceCategories()
        {
            return _appDbContext.ServiceCategories
                .Select(sc => new ServiceCategoryOutputModel()
            {
                    Id = sc.Id,
                    ParentId = sc.ParentId,
                    Services = sc.Services,
                    Title = sc.Title
            }).ToList();
        }
    }
}

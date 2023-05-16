using App.Domain.Core.AppServices.Services.Queries;
using App.Domain.Core.DataAccess;
using App.Domain.Core.DtoModels.Services;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Services.Queries
{
    public class GetServiceCategories : IGetServiceCategories
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceCategories(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<ServiceCategoryOutputModel> Execute()
        {
            return _serviceRepository.GetServiceCategories();
        }
    }
}

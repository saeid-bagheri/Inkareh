using App.Domain.Core.DtoModels.Services;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AppServices.Services.Queries
{
    public interface IGetServiceCategories
    {
        List<ServiceCategoryOutputModel> Execute();
    }
}

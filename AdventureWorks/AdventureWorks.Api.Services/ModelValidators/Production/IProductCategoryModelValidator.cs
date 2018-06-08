using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductCategoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>55e37fe860346327540912ce7b6daaf0</Hash>
</Codenesium>*/
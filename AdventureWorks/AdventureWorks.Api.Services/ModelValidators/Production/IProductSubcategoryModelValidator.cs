using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductSubcategoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>9e44a1305b888d459b64b5be110f677f</Hash>
</Codenesium>*/
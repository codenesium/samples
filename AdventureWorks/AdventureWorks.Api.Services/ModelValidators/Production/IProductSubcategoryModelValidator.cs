using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>9833de4fe4546dc37f1a884576b172cf</Hash>
</Codenesium>*/
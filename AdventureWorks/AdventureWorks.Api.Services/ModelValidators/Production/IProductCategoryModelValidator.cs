using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>4307cfd723bdedfa57c7756fac5c61f5</Hash>
</Codenesium>*/
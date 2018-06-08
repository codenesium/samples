using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiAddressTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>302738b4c10244adf9d40093b362b21b</Hash>
</Codenesium>*/
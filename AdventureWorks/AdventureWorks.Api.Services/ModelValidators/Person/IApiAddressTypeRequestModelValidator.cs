using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>47551a97223d9b1e6f71433a0db3efc7</Hash>
</Codenesium>*/
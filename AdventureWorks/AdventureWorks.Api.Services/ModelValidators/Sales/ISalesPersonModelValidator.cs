using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesPersonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c2e77cec6e944cbcd8b7e806a13d60e2</Hash>
</Codenesium>*/
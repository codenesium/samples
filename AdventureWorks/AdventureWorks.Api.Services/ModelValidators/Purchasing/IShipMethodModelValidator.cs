using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiShipMethodRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>cabddce80c069f2fc6e0992bb3b6744d</Hash>
</Codenesium>*/
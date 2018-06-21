using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCurrencyRateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a689e9cb4d68123fcd5fd7f9e7fec58f</Hash>
</Codenesium>*/
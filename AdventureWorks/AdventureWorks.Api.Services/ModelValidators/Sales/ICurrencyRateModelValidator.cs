using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>de497d079c4ba9cc5dfb176c5a0c081b</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCountryRegionCurrencyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>2bfb3ff4509621cf0841040189b2790e</Hash>
</Codenesium>*/
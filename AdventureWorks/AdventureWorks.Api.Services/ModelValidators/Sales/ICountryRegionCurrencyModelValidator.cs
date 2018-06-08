using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>0f6b6ca67f82e63c88cc0c9fb036ec56</Hash>
</Codenesium>*/
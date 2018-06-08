using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesTaxRateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesTaxRateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTaxRateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>abc03d6e17b2e4c635dc7cc7369edb73</Hash>
</Codenesium>*/
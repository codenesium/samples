using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>4afd7060f00a9319fb376f39ce54c38c</Hash>
</Codenesium>*/
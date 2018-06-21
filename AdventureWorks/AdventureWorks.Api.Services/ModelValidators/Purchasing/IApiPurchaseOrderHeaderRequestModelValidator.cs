using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPurchaseOrderHeaderRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>29ad5e028fbdd9dd431c362f0e4de47b</Hash>
</Codenesium>*/
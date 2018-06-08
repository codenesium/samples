using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>5f8a7b878e94e25532e3a2ff33dc4081</Hash>
</Codenesium>*/
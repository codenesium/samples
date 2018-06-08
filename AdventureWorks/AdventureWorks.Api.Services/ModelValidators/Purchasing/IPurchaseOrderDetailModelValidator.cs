using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPurchaseOrderDetailRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderDetailRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>79c547de8143cf2697ad5a4b15ed9cd4</Hash>
</Codenesium>*/
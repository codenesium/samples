using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>99c9a3e3899cb6a4bf8cd26f5de2665c</Hash>
</Codenesium>*/
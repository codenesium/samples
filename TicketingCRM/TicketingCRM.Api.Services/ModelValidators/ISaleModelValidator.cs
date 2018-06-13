using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiSaleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>8f3f4b4d9477c01d4d34be5a7b99ed26</Hash>
</Codenesium>*/
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiTransactionStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b595e03043dd3d150b5f7c73a4351bd7</Hash>
</Codenesium>*/
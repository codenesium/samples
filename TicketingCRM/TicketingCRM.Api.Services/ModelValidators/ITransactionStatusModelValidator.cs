using System;
using System.Threading.Tasks;
using FluentValidation.Results;
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
    <Hash>411ec8fb0410e4420df4d2cdc01925a9</Hash>
</Codenesium>*/
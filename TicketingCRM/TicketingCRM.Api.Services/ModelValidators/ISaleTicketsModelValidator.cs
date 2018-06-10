using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiSaleTicketsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e79296fb450b7b81efb1fa95c28fbe6c</Hash>
</Codenesium>*/
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiSaleTicketsRequestModelValidator : AbstractApiSaleTicketsRequestModelValidator, IApiSaleTicketsRequestModelValidator
        {
                public ApiSaleTicketsRequestModelValidator(ISaleTicketsRepository saleTicketsRepository)
                        : base(saleTicketsRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsRequestModel model)
                {
                        this.SaleIdRules();
                        this.TicketIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsRequestModel model)
                {
                        this.SaleIdRules();
                        this.TicketIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>775fd37989db6f93039ad29c639261f4</Hash>
</Codenesium>*/
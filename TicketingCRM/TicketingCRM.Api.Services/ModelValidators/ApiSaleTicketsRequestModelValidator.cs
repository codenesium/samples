using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiSaleTicketsRequestModelValidator: AbstractApiSaleTicketsRequestModelValidator, IApiSaleTicketsRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>06a723f7ccfad3bfd9e96663b63c52e0</Hash>
</Codenesium>*/
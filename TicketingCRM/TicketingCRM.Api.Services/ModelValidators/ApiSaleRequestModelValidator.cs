using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiSaleRequestModelValidator : AbstractApiSaleRequestModelValidator, IApiSaleRequestModelValidator
        {
                public ApiSaleRequestModelValidator(ISaleRepository saleRepository)
                        : base(saleRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model)
                {
                        this.IpAddressRules();
                        this.NotesRules();
                        this.SaleDateRules();
                        this.TransactionIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model)
                {
                        this.IpAddressRules();
                        this.NotesRules();
                        this.SaleDateRules();
                        this.TransactionIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>0fa4a5cb8c1690fe91b377e92af423c8</Hash>
</Codenesium>*/
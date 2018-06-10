using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiSaleRequestModelValidator: AbstractApiSaleRequestModelValidator, IApiSaleRequestModelValidator
        {
                public ApiSaleRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>576ee25e238518b44aba288ee94ca279</Hash>
</Codenesium>*/
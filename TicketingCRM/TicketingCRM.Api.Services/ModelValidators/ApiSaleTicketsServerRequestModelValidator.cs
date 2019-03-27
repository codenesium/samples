using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiSaleTicketsServerRequestModelValidator : AbstractApiSaleTicketsServerRequestModelValidator, IApiSaleTicketsServerRequestModelValidator
	{
		public ApiSaleTicketsServerRequestModelValidator(ISaleTicketsRepository saleTicketsRepository)
			: base(saleTicketsRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsServerRequestModel model)
		{
			this.SaleIdRules();
			this.TicketIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsServerRequestModel model)
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
    <Hash>d690b7f841944e785f48015a3a1c8aec</Hash>
</Codenesium>*/
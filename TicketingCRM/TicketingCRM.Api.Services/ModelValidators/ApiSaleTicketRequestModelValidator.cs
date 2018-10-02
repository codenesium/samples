using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiSaleTicketRequestModelValidator : AbstractApiSaleTicketRequestModelValidator, IApiSaleTicketRequestModelValidator
	{
		public ApiSaleTicketRequestModelValidator(ISaleTicketRepository saleTicketRepository)
			: base(saleTicketRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketRequestModel model)
		{
			this.SaleIdRules();
			this.TicketIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketRequestModel model)
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
    <Hash>53d71774c122e9539794674d7593720b</Hash>
</Codenesium>*/
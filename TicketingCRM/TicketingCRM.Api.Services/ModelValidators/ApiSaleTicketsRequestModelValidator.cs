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
    <Hash>26c4e3c5c62b9438f79b2a0c8870c740</Hash>
</Codenesium>*/
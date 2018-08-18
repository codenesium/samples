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
    <Hash>560103e0db75ebdd8744c730922d2402</Hash>
</Codenesium>*/
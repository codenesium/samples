using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiSaleTicketServerRequestModelValidator : AbstractApiSaleTicketServerRequestModelValidator, IApiSaleTicketServerRequestModelValidator
	{
		public ApiSaleTicketServerRequestModelValidator(ISaleTicketRepository saleTicketRepository)
			: base(saleTicketRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketServerRequestModel model)
		{
			this.SaleIdRules();
			this.TicketIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketServerRequestModel model)
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
    <Hash>b64da2f83ef9c06530a44ed8296b24a1</Hash>
</Codenesium>*/
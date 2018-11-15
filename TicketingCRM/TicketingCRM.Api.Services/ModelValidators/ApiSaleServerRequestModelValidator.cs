using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiSaleServerRequestModelValidator : AbstractApiSaleServerRequestModelValidator, IApiSaleServerRequestModelValidator
	{
		public ApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
			: base(saleRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model)
		{
			this.IpAddressRules();
			this.NoteRules();
			this.SaleDateRules();
			this.TransactionIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.IpAddressRules();
			this.NoteRules();
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
    <Hash>5e0861a3dfa4320a31a4825e71a07ce9</Hash>
</Codenesium>*/
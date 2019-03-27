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
			this.NotesRules();
			this.SaleDateRules();
			this.TransactionIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
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
    <Hash>0427f80feff43c029bc650e0877e7b5f</Hash>
</Codenesium>*/
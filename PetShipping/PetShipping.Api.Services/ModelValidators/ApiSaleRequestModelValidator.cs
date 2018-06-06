using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiSaleRequestModelValidator: AbstractApiSaleRequestModelValidator, IApiSaleRequestModelValidator
	{
		public ApiSaleRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model)
		{
			this.AmountRules();
			this.ClientIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model)
		{
			this.AmountRules();
			this.ClientIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>ab9a0bee53cff9354d93e956e1a74a53</Hash>
</Codenesium>*/
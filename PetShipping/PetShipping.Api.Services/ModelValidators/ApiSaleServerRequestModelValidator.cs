using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiSaleServerRequestModelValidator : AbstractApiSaleServerRequestModelValidator, IApiSaleServerRequestModelValidator
	{
		public ApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
			: base(saleRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model)
		{
			this.AmountRules();
			this.CutomerIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.AmountRules();
			this.CutomerIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>28cf8bdcee5067ee9e6abcc9a5a139c1</Hash>
</Codenesium>*/
using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class SaleModelValidator: AbstractSaleModelValidator, ISaleModelValidator
	{
		public SaleModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SaleModel model)
		{
			this.AmountRules();
			this.ClientIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SaleModel model)
		{
			this.AmountRules();
			this.ClientIdRules();
			this.NoteRules();
			this.PetIdRules();
			this.SaleDateRules();
			this.SalesPersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>79c038443f24ef82578bb8402dff6b2a</Hash>
</Codenesium>*/
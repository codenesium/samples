using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiBillOfMaterialServerRequestModelValidator : AbstractApiBillOfMaterialServerRequestModelValidator, IApiBillOfMaterialServerRequestModelValidator
	{
		public ApiBillOfMaterialServerRequestModelValidator(IBillOfMaterialRepository billOfMaterialRepository)
			: base(billOfMaterialRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialServerRequestModel model)
		{
			this.BOMLevelRules();
			this.ComponentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.PerAssemblyQtyRules();
			this.ProductAssemblyIDRules();
			this.StartDateRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialServerRequestModel model)
		{
			this.BOMLevelRules();
			this.ComponentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.PerAssemblyQtyRules();
			this.ProductAssemblyIDRules();
			this.StartDateRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>b1bfe7ba3f115da33637dec9b77d0c8f</Hash>
</Codenesium>*/
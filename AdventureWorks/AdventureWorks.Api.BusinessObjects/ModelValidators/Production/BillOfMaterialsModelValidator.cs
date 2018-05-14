using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiBillOfMaterialsModelValidator: AbstractApiBillOfMaterialsModelValidator, IApiBillOfMaterialsModelValidator
	{
		public ApiBillOfMaterialsModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsModel model)
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

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>422bd1503cd955fa9702582c7146c2b7</Hash>
</Codenesium>*/
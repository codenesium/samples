using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BillOfMaterialsModelValidator: AbstractBillOfMaterialsModelValidator, IBillOfMaterialsModelValidator
	{
		public BillOfMaterialsModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(BillOfMaterialsModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BillOfMaterialsModel model)
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
    <Hash>edbe01bcb598758611943eeacfe428bb</Hash>
</Codenesium>*/
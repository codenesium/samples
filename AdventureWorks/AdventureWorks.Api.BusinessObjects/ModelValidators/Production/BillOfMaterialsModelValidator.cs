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
			this.ProductAssemblyIDRules();
			this.ComponentIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.UnitMeasureCodeRules();
			this.BOMLevelRules();
			this.PerAssemblyQtyRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BillOfMaterialsModel model)
		{
			this.ProductAssemblyIDRules();
			this.ComponentIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.UnitMeasureCodeRules();
			this.BOMLevelRules();
			this.PerAssemblyQtyRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>8ef36151f8028a24de61a3e4b890b215</Hash>
</Codenesium>*/
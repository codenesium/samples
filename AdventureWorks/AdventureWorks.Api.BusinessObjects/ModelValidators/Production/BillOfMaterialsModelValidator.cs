using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiBillOfMaterialsRequestModelValidator: AbstractApiBillOfMaterialsRequestModelValidator, IApiBillOfMaterialsRequestModelValidator
	{
		public ApiBillOfMaterialsRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsRequestModel model)
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
    <Hash>5ca35c303d65e9066852bce02fecbee5</Hash>
</Codenesium>*/
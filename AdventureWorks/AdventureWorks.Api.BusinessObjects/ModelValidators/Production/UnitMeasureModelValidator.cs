using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class UnitMeasureModelValidator: AbstractUnitMeasureModelValidator, IUnitMeasureModelValidator
	{
		public UnitMeasureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(UnitMeasureModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, UnitMeasureModel model)
		{
			this.NameRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a70f0f19b4b152f56e056c12de866c50</Hash>
</Codenesium>*/
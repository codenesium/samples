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
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, UnitMeasureModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>624ddb65f92377e67712099a017e1461</Hash>
</Codenesium>*/
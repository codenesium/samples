using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiUnitMeasureModelValidator: AbstractApiUnitMeasureModelValidator, IApiUnitMeasureModelValidator
	{
		public ApiUnitMeasureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureModel model)
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
    <Hash>f3f85032ad5e191404fe998c475c2121</Hash>
</Codenesium>*/
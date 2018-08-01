using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiUnitMeasureRequestModelValidator : AbstractApiUnitMeasureRequestModelValidator, IApiUnitMeasureRequestModelValidator
	{
		public ApiUnitMeasureRequestModelValidator(IUnitMeasureRepository unitMeasureRepository)
			: base(unitMeasureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>36d3b0fb879e1b5bd3b30f6bbd7af2ce</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiUnitMeasureServerRequestModelValidator : AbstractApiUnitMeasureServerRequestModelValidator, IApiUnitMeasureServerRequestModelValidator
	{
		public ApiUnitMeasureServerRequestModelValidator(IUnitMeasureRepository unitMeasureRepository)
			: base(unitMeasureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureServerRequestModel model)
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
    <Hash>77fe9845c53f5e2c277f35d38403e8d3</Hash>
</Codenesium>*/
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiColumnSameAsFKTableRequestModelValidator : AbstractApiColumnSameAsFKTableRequestModelValidator, IApiColumnSameAsFKTableRequestModelValidator
	{
		public ApiColumnSameAsFKTableRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
			: base(columnSameAsFKTableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiColumnSameAsFKTableRequestModel model)
		{
			this.PersonRules();
			this.PersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiColumnSameAsFKTableRequestModel model)
		{
			this.PersonRules();
			this.PersonIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>143e52911a5d45b7047ea636ea64cdd3</Hash>
</Codenesium>*/
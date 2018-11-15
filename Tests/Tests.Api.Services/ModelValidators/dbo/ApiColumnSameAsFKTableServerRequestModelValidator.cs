using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiColumnSameAsFKTableServerRequestModelValidator : AbstractApiColumnSameAsFKTableServerRequestModelValidator, IApiColumnSameAsFKTableServerRequestModelValidator
	{
		public ApiColumnSameAsFKTableServerRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
			: base(columnSameAsFKTableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiColumnSameAsFKTableServerRequestModel model)
		{
			this.PersonRules();
			this.PersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiColumnSameAsFKTableServerRequestModel model)
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
    <Hash>46a00a1031d3fce40d54f9d0d1af4aa1</Hash>
</Codenesium>*/
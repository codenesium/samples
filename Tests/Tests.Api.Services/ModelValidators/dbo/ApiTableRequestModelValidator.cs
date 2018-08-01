using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiTableRequestModelValidator : AbstractApiTableRequestModelValidator, IApiTableRequestModelValidator
	{
		public ApiTableRequestModelValidator(ITableRepository tableRepository)
			: base(tableRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTableRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7af01754e2cb3706d3e1329134419450</Hash>
</Codenesium>*/
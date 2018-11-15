using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiSchemaBPersonServerRequestModelValidator : AbstractApiSchemaBPersonServerRequestModelValidator, IApiSchemaBPersonServerRequestModelValidator
	{
		public ApiSchemaBPersonServerRequestModelValidator(ISchemaBPersonRepository schemaBPersonRepository)
			: base(schemaBPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSchemaBPersonServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSchemaBPersonServerRequestModel model)
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
    <Hash>544d81b05354a34782dd955872cae674</Hash>
</Codenesium>*/
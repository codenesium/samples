using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCultureServerRequestModelValidator : AbstractApiCultureServerRequestModelValidator, IApiCultureServerRequestModelValidator
	{
		public ApiCultureServerRequestModelValidator(ICultureRepository cultureRepository)
			: base(cultureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCultureServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureServerRequestModel model)
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
    <Hash>5c2408609f1a743708461597dae05245</Hash>
</Codenesium>*/
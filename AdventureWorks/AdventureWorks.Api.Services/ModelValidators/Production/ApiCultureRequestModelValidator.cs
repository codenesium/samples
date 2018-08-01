using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiCultureRequestModelValidator : AbstractApiCultureRequestModelValidator, IApiCultureRequestModelValidator
	{
		public ApiCultureRequestModelValidator(ICultureRepository cultureRepository)
			: base(cultureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCultureRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureRequestModel model)
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
    <Hash>6d5618b9d124ae02aea5c2721fc489f4</Hash>
</Codenesium>*/
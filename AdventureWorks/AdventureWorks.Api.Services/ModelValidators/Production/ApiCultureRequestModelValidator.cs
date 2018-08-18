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
    <Hash>8339b0619f7217e6cb6a43267dac246d</Hash>
</Codenesium>*/
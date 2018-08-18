using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiRowVersionCheckRequestModelValidator : AbstractApiRowVersionCheckRequestModelValidator, IApiRowVersionCheckRequestModelValidator
	{
		public ApiRowVersionCheckRequestModelValidator(IRowVersionCheckRepository rowVersionCheckRepository)
			: base(rowVersionCheckRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckRequestModel model)
		{
			this.NameRules();
			this.RowVersionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>008fb0d3db98ba003d1afac7c2e92700</Hash>
</Codenesium>*/
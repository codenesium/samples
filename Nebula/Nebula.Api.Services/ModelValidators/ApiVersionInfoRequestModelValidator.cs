using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiVersionInfoRequestModelValidator : AbstractApiVersionInfoRequestModelValidator, IApiVersionInfoRequestModelValidator
	{
		public ApiVersionInfoRequestModelValidator(IVersionInfoRepository versionInfoRepository)
			: base(versionInfoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(long id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d29f4b64cf9c52245d7a5fc4aa920caf</Hash>
</Codenesium>*/
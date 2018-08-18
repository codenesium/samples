using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
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
    <Hash>b2c706d67bfe75ae9c8d06d88561989c</Hash>
</Codenesium>*/
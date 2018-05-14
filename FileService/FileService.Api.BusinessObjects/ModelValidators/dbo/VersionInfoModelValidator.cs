using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class ApiVersionInfoModelValidator: AbstractApiVersionInfoModelValidator, IApiVersionInfoModelValidator
	{
		public ApiVersionInfoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(long id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>aabd9da5b25099ab8833c7b37a95feb8</Hash>
</Codenesium>*/
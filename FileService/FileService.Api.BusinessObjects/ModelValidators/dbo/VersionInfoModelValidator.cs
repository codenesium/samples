using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class ApiVersionInfoRequestModelValidator: AbstractApiVersionInfoRequestModelValidator, IApiVersionInfoRequestModelValidator
	{
		public ApiVersionInfoRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(long id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a5d28200253b14361b17151a28bcde9f</Hash>
</Codenesium>*/
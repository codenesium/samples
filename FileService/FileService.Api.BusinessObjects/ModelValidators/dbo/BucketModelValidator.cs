using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class ApiBucketRequestModelValidator: AbstractApiBucketRequestModelValidator, IApiBucketRequestModelValidator
	{
		public ApiBucketRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBucketRequestModel model)
		{
			this.ExternalIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketRequestModel model)
		{
			this.ExternalIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>103920511b060e3a4f4026461cf00d32</Hash>
</Codenesium>*/
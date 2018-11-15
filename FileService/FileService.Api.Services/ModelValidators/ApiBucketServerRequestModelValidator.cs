using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiBucketServerRequestModelValidator : AbstractApiBucketServerRequestModelValidator, IApiBucketServerRequestModelValidator
	{
		public ApiBucketServerRequestModelValidator(IBucketRepository bucketRepository)
			: base(bucketRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBucketServerRequestModel model)
		{
			this.ExternalIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketServerRequestModel model)
		{
			this.ExternalIdRules();
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
    <Hash>5e87d893456ef6f23725542b0ec324fb</Hash>
</Codenesium>*/
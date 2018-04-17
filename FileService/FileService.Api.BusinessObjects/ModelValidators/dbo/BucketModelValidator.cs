using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class BucketModelValidator: AbstractBucketModelValidator, IBucketModelValidator
	{
		public BucketModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(BucketModel model)
		{
			this.NameRules();
			this.ExternalIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BucketModel model)
		{
			this.NameRules();
			this.ExternalIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c7115d73f75497e0cccf0cbcff87d33b</Hash>
</Codenesium>*/
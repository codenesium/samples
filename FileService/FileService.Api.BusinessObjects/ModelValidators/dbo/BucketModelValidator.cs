using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class ApiBucketModelValidator: AbstractApiBucketModelValidator, IApiBucketModelValidator
	{
		public ApiBucketModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBucketModel model)
		{
			this.ExternalIdRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBucketModel model)
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
    <Hash>3d6b7fbcd472e57f05c4ceba95eeda63</Hash>
</Codenesium>*/
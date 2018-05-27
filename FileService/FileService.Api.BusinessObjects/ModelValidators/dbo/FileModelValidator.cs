using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class ApiFileRequestModelValidator: AbstractApiFileRequestModelValidator, IApiFileRequestModelValidator
	{
		public ApiFileRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model)
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model)
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f4377af7024da35bbb22cc79d5adffb2</Hash>
</Codenesium>*/
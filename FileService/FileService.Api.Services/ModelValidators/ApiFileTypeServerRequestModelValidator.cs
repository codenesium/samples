using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiFileTypeServerRequestModelValidator : AbstractValidator<ApiFileTypeServerRequestModel>, IApiFileTypeServerRequestModelValidator
	{
		private int existingRecordId;

		protected IFileTypeRepository FileTypeRepository { get; private set; }

		public ApiFileTypeServerRequestModelValidator(IFileTypeRepository fileTypeRepository)
		{
			this.FileTypeRepository = fileTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFileTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 255).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>68c3d2aff48ceab8a3607c5d5e79de3d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
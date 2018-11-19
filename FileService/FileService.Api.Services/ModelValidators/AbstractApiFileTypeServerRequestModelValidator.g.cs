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
	public abstract class AbstractApiFileTypeServerRequestModelValidator : AbstractValidator<ApiFileTypeServerRequestModel>
	{
		private int existingRecordId;

		private IFileTypeRepository fileTypeRepository;

		public AbstractApiFileTypeServerRequestModelValidator(IFileTypeRepository fileTypeRepository)
		{
			this.fileTypeRepository = fileTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFileTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 255).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>701b1abcbd7e61700ce706f54651ac82</Hash>
</Codenesium>*/
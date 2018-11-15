using Codenesium.DataConversionExtensions;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 255);
		}
	}
}

/*<Codenesium>
    <Hash>9c7b22de6822c2e3674b3e924eb1885c</Hash>
</Codenesium>*/
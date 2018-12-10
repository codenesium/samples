using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiDocumentServerRequestModelValidator : AbstractValidator<ApiDocumentServerRequestModel>
	{
		private Guid existingRecordId;

		protected IDocumentRepository DocumentRepository { get; private set; }

		public AbstractApiDocumentServerRequestModelValidator(IDocumentRepository documentRepository)
		{
			this.DocumentRepository = documentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDocumentServerRequestModel model, Guid id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ChangeNumberRules()
		{
		}

		public virtual void Document1Rules()
		{
		}

		public virtual void DocumentLevelRules()
		{
		}

		public virtual void DocumentSummaryRules()
		{
		}

		public virtual void FileExtensionRules()
		{
			this.RuleFor(x => x.FileExtension).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FileExtension).Length(0, 8).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FileNameRules()
		{
			this.RuleFor(x => x.FileName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FileName).Length(0, 400).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FolderFlagRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OwnerRules()
		{
		}

		public virtual void RevisionRules()
		{
			this.RuleFor(x => x.Revision).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Revision).Length(0, 5).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StatusRules()
		{
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Title).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>5a0ef8528c85a473cc8872e3c56f52e8</Hash>
</Codenesium>*/
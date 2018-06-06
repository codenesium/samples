using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiDocumentRequestModelValidator: AbstractValidator<ApiDocumentRequestModel>
	{
		private Guid existingRecordId;

		public new ValidationResult Validate(ApiDocumentRequestModel model, Guid id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDocumentRequestModel model, Guid id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void ChangeNumberRules()
		{
			this.RuleFor(x => x.ChangeNumber).NotNull();
		}

		public virtual void Document1Rules()
		{                       }

		public virtual void DocumentLevelRules()
		{                       }

		public virtual void DocumentSummaryRules()
		{                       }

		public virtual void FileExtensionRules()
		{
			this.RuleFor(x => x.FileExtension).NotNull();
			this.RuleFor(x => x.FileExtension).Length(0, 8);
		}

		public virtual void FileNameRules()
		{
			this.RuleFor(x => x.FileName).NotNull();
			this.RuleFor(x => x.FileName).Length(0, 400);
		}

		public virtual void FolderFlagRules()
		{
			this.RuleFor(x => x.FolderFlag).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OwnerRules()
		{
			this.RuleFor(x => x.Owner).NotNull();
		}

		public virtual void RevisionRules()
		{
			this.RuleFor(x => x.Revision).NotNull();
			this.RuleFor(x => x.Revision).Length(0, 5);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StatusRules()
		{
			this.RuleFor(x => x.Status).NotNull();
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).NotNull();
			this.RuleFor(x => x.Title).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>125429c4d8c4e14bd916bd0fbf490881</Hash>
</Codenesium>*/
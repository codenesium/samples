using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractDocumentModelValidator: AbstractValidator<DocumentModel>
	{
		public new ValidationResult Validate(DocumentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DocumentModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository {get; set;}
		public virtual void DocumentLevelRules()
		{                       }

		public virtual void TitleRules()
		{
			RuleFor(x => x.Title).NotNull();
			RuleFor(x => x.Title).Length(0,50);
		}

		public virtual void OwnerRules()
		{
			RuleFor(x => x.Owner).NotNull();
			RuleFor(x => x.Owner).Must(BeValidEmployee).When(x => x ?.Owner != null).WithMessage("Invalid reference");
		}

		public virtual void FolderFlagRules()
		{
			RuleFor(x => x.FolderFlag).NotNull();
		}

		public virtual void FileNameRules()
		{
			RuleFor(x => x.FileName).NotNull();
			RuleFor(x => x.FileName).Length(0,400);
		}

		public virtual void FileExtensionRules()
		{
			RuleFor(x => x.FileExtension).NotNull();
			RuleFor(x => x.FileExtension).Length(0,8);
		}

		public virtual void RevisionRules()
		{
			RuleFor(x => x.Revision).NotNull();
			RuleFor(x => x.Revision).Length(0,5);
		}

		public virtual void ChangeNumberRules()
		{
			RuleFor(x => x.ChangeNumber).NotNull();
		}

		public virtual void StatusRules()
		{
			RuleFor(x => x.Status).NotNull();
		}

		public virtual void DocumentSummaryRules()
		{                       }

		public virtual void Document1Rules()
		{                       }

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidEmployee(int id)
		{
			Response response = new Response();

			this.EmployeeRepository.GetById(id,response);
			return response.Employees.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>7a2f154eca86bd7f45d8eaa4401649ab</Hash>
</Codenesium>*/
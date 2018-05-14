using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiStudentXFamilyModelValidator: AbstractValidator<ApiStudentXFamilyModel>
	{
		public new ValidationResult Validate(ApiStudentXFamilyModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudentXFamilyModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IFamilyRepository FamilyRepository { get; set; }
		public IStudentRepository StudentRepository { get; set; }
		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).NotNull();
			this.RuleFor(x => x.FamilyId).Must(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).NotNull();
			this.RuleFor(x => x.StudentId).Must(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
		}

		private bool BeValidFamily(int id)
		{
			return this.FamilyRepository.Get(id) != null;
		}

		private bool BeValidStudent(int id)
		{
			return this.StudentRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>7f7dd5264b78e1be036187ea94d7bd51</Hash>
</Codenesium>*/
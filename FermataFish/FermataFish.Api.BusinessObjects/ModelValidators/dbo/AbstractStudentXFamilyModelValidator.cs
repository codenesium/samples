using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractStudentXFamilyModelValidator: AbstractValidator<StudentXFamilyModel>
	{
		public new ValidationResult Validate(StudentXFamilyModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StudentXFamilyModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStudentRepository StudentRepository { get; set; }
		public IFamilyRepository FamilyRepository { get; set; }
		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).NotNull();
			this.RuleFor(x => x.StudentId).Must(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
		}

		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).NotNull();
			this.RuleFor(x => x.FamilyId).Must(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
		}

		private bool BeValidStudent(int id)
		{
			return this.StudentRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidFamily(int id)
		{
			return this.FamilyRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>d51483cf12ce1f2419ef91587139c13e</Hash>
</Codenesium>*/
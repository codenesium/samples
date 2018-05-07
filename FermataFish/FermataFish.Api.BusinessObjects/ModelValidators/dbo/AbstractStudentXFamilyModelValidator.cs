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
    <Hash>0549fc844be472ef5b9d471f50047773</Hash>
</Codenesium>*/
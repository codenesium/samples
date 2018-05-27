using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractApiStudentXFamilyRequestModelValidator: AbstractValidator<ApiStudentXFamilyRequestModel>
	{
		public new ValidationResult Validate(ApiStudentXFamilyRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudentXFamilyRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IFamilyRepository FamilyRepository { get; set; }
		public IStudentRepository StudentRepository { get; set; }
		public virtual void FamilyIdRules()
		{
			this.RuleFor(x => x.FamilyId).NotNull();
			this.RuleFor(x => x.FamilyId).MustAsync(this.BeValidFamily).When(x => x ?.FamilyId != null).WithMessage("Invalid reference");
		}

		public virtual void StudentIdRules()
		{
			this.RuleFor(x => x.StudentId).NotNull();
			this.RuleFor(x => x.StudentId).MustAsync(this.BeValidStudent).When(x => x ?.StudentId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidFamily(int id,  CancellationToken cancellationToken)
		{
			var record = await this.FamilyRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidStudent(int id,  CancellationToken cancellationToken)
		{
			var record = await this.StudentRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1f6c7c8dbc5d793a4856d7947bf6b3d9</Hash>
</Codenesium>*/
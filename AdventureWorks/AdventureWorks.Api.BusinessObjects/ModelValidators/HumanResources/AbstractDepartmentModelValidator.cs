using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiDepartmentModelValidator: AbstractValidator<ApiDepartmentModel>
	{
		public new ValidationResult Validate(ApiDepartmentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDepartmentModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IDepartmentRepository DepartmentRepository { get; set; }
		public virtual void GroupNameRules()
		{
			this.RuleFor(x => x.GroupName).NotNull();
			this.RuleFor(x => x.GroupName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiDepartmentModel model)
		{
			return this.DepartmentRepository.GetName(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>ddf561a26900f51440c11d22407d4114</Hash>
</Codenesium>*/
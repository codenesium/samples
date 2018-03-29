using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractDepartmentModelValidator: AbstractValidator<DepartmentModel>
	{
		public new ValidationResult Validate(DepartmentModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DepartmentModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void GroupNameRules()
		{
			RuleFor(x => x.GroupName).NotNull();
			RuleFor(x => x.GroupName).Length(0,50);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>7029d0284f45f66466105a9a81b3124c</Hash>
</Codenesium>*/
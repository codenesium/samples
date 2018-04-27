using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>8686b041083654e8d069f8f86e043cdc</Hash>
</Codenesium>*/
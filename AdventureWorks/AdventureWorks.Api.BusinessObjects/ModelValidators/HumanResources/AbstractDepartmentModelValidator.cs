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
    <Hash>b97a88a38315548f9022ebb36045689b</Hash>
</Codenesium>*/
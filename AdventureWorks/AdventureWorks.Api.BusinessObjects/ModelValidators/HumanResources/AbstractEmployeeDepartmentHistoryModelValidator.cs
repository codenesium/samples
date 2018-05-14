using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiEmployeeDepartmentHistoryModelValidator: AbstractValidator<ApiEmployeeDepartmentHistoryModel>
	{
		public new ValidationResult Validate(ApiEmployeeDepartmentHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeDepartmentHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DepartmentIDRules()
		{
			this.RuleFor(x => x.DepartmentID).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ShiftIDRules()
		{
			this.RuleFor(x => x.ShiftID).NotNull();
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>d5726ceb961e1a04b9ff1bd4d04d68a2</Hash>
</Codenesium>*/
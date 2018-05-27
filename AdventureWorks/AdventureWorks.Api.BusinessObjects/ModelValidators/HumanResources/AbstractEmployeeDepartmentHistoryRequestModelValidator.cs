using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiEmployeeDepartmentHistoryRequestModelValidator: AbstractValidator<ApiEmployeeDepartmentHistoryRequestModel>
	{
		public new ValidationResult Validate(ApiEmployeeDepartmentHistoryRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeDepartmentHistoryRequestModel model)
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
    <Hash>287d64c60b239a7d508c78ae095eb28a</Hash>
</Codenesium>*/
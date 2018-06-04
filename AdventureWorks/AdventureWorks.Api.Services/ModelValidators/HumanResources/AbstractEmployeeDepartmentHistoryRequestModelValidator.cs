using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiEmployeeDepartmentHistoryRequestModelValidator: AbstractValidator<ApiEmployeeDepartmentHistoryRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiEmployeeDepartmentHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeDepartmentHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>0f806d5e1261eeedf75a3b858f46e180</Hash>
</Codenesium>*/
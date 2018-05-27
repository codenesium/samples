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
	public abstract class AbstractApiEmployeeRequestModelValidator: AbstractValidator<ApiEmployeeRequestModel>
	{
		public new ValidationResult Validate(ApiEmployeeRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IEmployeeRepository EmployeeRepository { get; set; }
		public virtual void BirthDateRules()
		{
			this.RuleFor(x => x.BirthDate).NotNull();
		}

		public virtual void CurrentFlagRules()
		{
			this.RuleFor(x => x.CurrentFlag).NotNull();
		}

		public virtual void GenderRules()
		{
			this.RuleFor(x => x.Gender).NotNull();
			this.RuleFor(x => x.Gender).Length(0, 1);
		}

		public virtual void HireDateRules()
		{
			this.RuleFor(x => x.HireDate).NotNull();
		}

		public virtual void JobTitleRules()
		{
			this.RuleFor(x => x.JobTitle).NotNull();
			this.RuleFor(x => x.JobTitle).Length(0, 50);
		}

		public virtual void LoginIDRules()
		{
			this.RuleFor(x => x.LoginID).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetLoginID).When(x => x ?.LoginID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeRequestModel.LoginID));
			this.RuleFor(x => x.LoginID).Length(0, 256);
		}

		public virtual void MaritalStatusRules()
		{
			this.RuleFor(x => x.MaritalStatus).NotNull();
			this.RuleFor(x => x.MaritalStatus).Length(0, 1);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NationalIDNumberRules()
		{
			this.RuleFor(x => x.NationalIDNumber).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetNationalIDNumber).When(x => x ?.NationalIDNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeRequestModel.NationalIDNumber));
			this.RuleFor(x => x.NationalIDNumber).Length(0, 15);
		}

		public virtual void OrganizationLevelRules()
		{                       }

		public virtual void OrganizationNodeRules()
		{                       }

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalariedFlagRules()
		{
			this.RuleFor(x => x.SalariedFlag).NotNull();
		}

		public virtual void SickLeaveHoursRules()
		{
			this.RuleFor(x => x.SickLeaveHours).NotNull();
		}

		public virtual void VacationHoursRules()
		{
			this.RuleFor(x => x.VacationHours).NotNull();
		}

		private async Task<bool> BeUniqueGetLoginID(ApiEmployeeRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.EmployeeRepository.GetLoginID(model.LoginID);

			return record == null;
		}
		private async Task<bool> BeUniqueGetNationalIDNumber(ApiEmployeeRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.EmployeeRepository.GetNationalIDNumber(model.NationalIDNumber);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>823855afee19defef57351f774eb9e07</Hash>
</Codenesium>*/
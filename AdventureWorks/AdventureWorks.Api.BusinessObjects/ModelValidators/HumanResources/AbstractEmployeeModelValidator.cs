using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiEmployeeModelValidator: AbstractValidator<ApiEmployeeModel>
	{
		public new ValidationResult Validate(ApiEmployeeModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeModel model)
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
			this.RuleFor(x => x).Must(this.BeUniqueGetLoginID).When(x => x ?.LoginID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeModel.LoginID));
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
			this.RuleFor(x => x).Must(this.BeUniqueGetNationalIDNumber).When(x => x ?.NationalIDNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeModel.NationalIDNumber));
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

		private bool BeUniqueGetLoginID(ApiEmployeeModel model)
		{
			return this.EmployeeRepository.GetLoginID(model.LoginID) == null;
		}

		private bool BeUniqueGetNationalIDNumber(ApiEmployeeModel model)
		{
			return this.EmployeeRepository.GetNationalIDNumber(model.NationalIDNumber) == null;
		}
	}
}

/*<Codenesium>
    <Hash>ade55c33706cccede667cf0db65e99b7</Hash>
</Codenesium>*/
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiEmployeeServerRequestModelValidator : AbstractValidator<ApiEmployeeServerRequestModel>
	{
		private int existingRecordId;

		protected IEmployeeRepository EmployeeRepository { get; private set; }

		public AbstractApiEmployeeServerRequestModelValidator(IEmployeeRepository employeeRepository)
		{
			this.EmployeeRepository = employeeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BirthDateRules()
		{
		}

		public virtual void CurrentFlagRules()
		{
		}

		public virtual void GenderRules()
		{
			this.RuleFor(x => x.Gender).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Gender).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void HireDateRules()
		{
		}

		public virtual void JobTitleRules()
		{
			this.RuleFor(x => x.JobTitle).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.JobTitle).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LoginIDRules()
		{
			this.RuleFor(x => x.LoginID).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByLoginID).When(x => (!x?.LoginID.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeServerRequestModel.LoginID)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.LoginID).Length(0, 256).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void MaritalStatuRules()
		{
			this.RuleFor(x => x.MaritalStatu).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.MaritalStatu).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NationalIDNumberRules()
		{
			this.RuleFor(x => x.NationalIDNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByNationalIDNumber).When(x => (!x?.NationalIDNumber.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeServerRequestModel.NationalIDNumber)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.NationalIDNumber).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void OrganizationLevelRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiEmployeeServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void SalariedFlagRules()
		{
		}

		public virtual void SickLeaveHourRules()
		{
		}

		public virtual void VacationHourRules()
		{
		}

		protected async Task<bool> BeUniqueByLoginID(ApiEmployeeServerRequestModel model,  CancellationToken cancellationToken)
		{
			Employee record = await this.EmployeeRepository.ByLoginID(model.LoginID);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByNationalIDNumber(ApiEmployeeServerRequestModel model,  CancellationToken cancellationToken)
		{
			Employee record = await this.EmployeeRepository.ByNationalIDNumber(model.NationalIDNumber);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiEmployeeServerRequestModel model,  CancellationToken cancellationToken)
		{
			Employee record = await this.EmployeeRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>eccdc6ef709f607efae0467b3a51af7f</Hash>
</Codenesium>*/
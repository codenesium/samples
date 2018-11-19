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
	public abstract class AbstractApiDepartmentServerRequestModelValidator : AbstractValidator<ApiDepartmentServerRequestModel>
	{
		private short existingRecordId;

		private IDepartmentRepository departmentRepository;

		public AbstractApiDepartmentServerRequestModelValidator(IDepartmentRepository departmentRepository)
		{
			this.departmentRepository = departmentRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDepartmentServerRequestModel model, short id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void GroupNameRules()
		{
			this.RuleFor(x => x.GroupName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.GroupName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiDepartmentServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeUniqueByName(ApiDepartmentServerRequestModel model,  CancellationToken cancellationToken)
		{
			Department record = await this.departmentRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(short) && record.DepartmentID == this.existingRecordId))
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
    <Hash>0c032c0e43e5c5b7ea8b7fe81f6e7bf4</Hash>
</Codenesium>*/
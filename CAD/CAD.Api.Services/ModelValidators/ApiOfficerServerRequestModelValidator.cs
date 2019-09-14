using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerServerRequestModelValidator : AbstractValidator<ApiOfficerServerRequestModel>, IApiOfficerServerRequestModelValidator
	{
		private int existingRecordId;

		protected IOfficerRepository OfficerRepository { get; private set; }

		public ApiOfficerServerRequestModelValidator(IOfficerRepository officerRepository)
		{
			this.OfficerRepository = officerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOfficerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOfficerServerRequestModel model)
		{
			this.BadgeRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerServerRequestModel model)
		{
			this.BadgeRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void BadgeRules()
		{
			this.RuleFor(x => x.Badge).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Email).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Password).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>e77240752b474c510a6ada92b3676e42</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
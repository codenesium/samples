using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiUserServerRequestModelValidator : AbstractValidator<ApiUserServerRequestModel>, IApiUserServerRequestModelValidator
	{
		private int existingRecordId;

		protected IUserRepository UserRepository { get; private set; }

		public ApiUserServerRequestModelValidator(IUserRepository userRepository)
		{
			this.UserRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model)
		{
			this.BioImgUrlRules();
			this.BirthdayRules();
			this.ContentDescriptionRules();
			this.EmailRules();
			this.FullNameRules();
			this.HeaderImgUrlRules();
			this.InterestRules();
			this.LocationLocationIdRules();
			this.PasswordRules();
			this.PhoneNumberRules();
			this.PrivacyRules();
			this.UsernameRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.BioImgUrlRules();
			this.BirthdayRules();
			this.ContentDescriptionRules();
			this.EmailRules();
			this.FullNameRules();
			this.HeaderImgUrlRules();
			this.InterestRules();
			this.LocationLocationIdRules();
			this.PasswordRules();
			this.PhoneNumberRules();
			this.PrivacyRules();
			this.UsernameRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void BioImgUrlRules()
		{
			this.RuleFor(x => x.BioImgUrl).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void BirthdayRules()
		{
		}

		public virtual void ContentDescriptionRules()
		{
			this.RuleFor(x => x.ContentDescription).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Email).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FullNameRules()
		{
			this.RuleFor(x => x.FullName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FullName).Length(0, 64).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void HeaderImgUrlRules()
		{
			this.RuleFor(x => x.HeaderImgUrl).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void InterestRules()
		{
			this.RuleFor(x => x.Interest).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LocationLocationIdRules()
		{
			this.RuleFor(x => x.LocationLocationId).MustAsync(this.BeValidLocationByLocationLocationId).When(x => !x?.LocationLocationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Password).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneNumberRules()
		{
			this.RuleFor(x => x.PhoneNumber).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PrivacyRules()
		{
			this.RuleFor(x => x.Privacy).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Privacy).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UsernameRules()
		{
			this.RuleFor(x => x.Username).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Username).Length(0, 64).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidLocationByLocationLocationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.UserRepository.LocationByLocationLocationId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d3b8c310f4b3f7a08e382b7646850c57</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
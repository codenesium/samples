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
	public abstract class AbstractApiUserRequestModelValidator : AbstractValidator<ApiUserRequestModel>
	{
		private int existingRecordId;

		private IUserRepository userRepository;

		public AbstractApiUserRequestModelValidator(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BioImgUrlRules()
		{
			this.RuleFor(x => x.BioImgUrl).Length(0, 32);
		}

		public virtual void BirthdayRules()
		{
		}

		public virtual void ContentDescriptionRules()
		{
			this.RuleFor(x => x.ContentDescription).Length(0, 128);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 32);
		}

		public virtual void FullNameRules()
		{
			this.RuleFor(x => x.FullName).NotNull();
			this.RuleFor(x => x.FullName).Length(0, 64);
		}

		public virtual void HeaderImgUrlRules()
		{
			this.RuleFor(x => x.HeaderImgUrl).Length(0, 32);
		}

		public virtual void InterestRules()
		{
			this.RuleFor(x => x.Interest).Length(0, 128);
		}

		public virtual void LocationLocationIdRules()
		{
			this.RuleFor(x => x.LocationLocationId).MustAsync(this.BeValidLocationByLocationLocationId).When(x => x?.LocationLocationId != null).WithMessage("Invalid reference");
		}

		public virtual void PasswordRules()
		{
			this.RuleFor(x => x.Password).NotNull();
			this.RuleFor(x => x.Password).Length(0, 32);
		}

		public virtual void PhoneNumberRules()
		{
			this.RuleFor(x => x.PhoneNumber).Length(0, 32);
		}

		public virtual void PrivacyRules()
		{
			this.RuleFor(x => x.Privacy).NotNull();
			this.RuleFor(x => x.Privacy).Length(0, 1);
		}

		public virtual void UsernameRules()
		{
			this.RuleFor(x => x.Username).NotNull();
			this.RuleFor(x => x.Username).Length(0, 64);
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).Length(0, 32);
		}

		private async Task<bool> BeValidLocationByLocationLocationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.userRepository.LocationByLocationLocationId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>610e1705eaa656fd93bedd81f80d855a</Hash>
</Codenesium>*/
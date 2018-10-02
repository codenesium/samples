using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiUserRequestModelValidator : AbstractApiUserRequestModelValidator, IApiUserRequestModelValidator
	{
		public ApiUserRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserRequestModel model)
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
	}
}

/*<Codenesium>
    <Hash>3d6a3d2d5387f1dd4b3bc6a6551e25f1</Hash>
</Codenesium>*/
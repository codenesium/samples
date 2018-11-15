using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ApiUserServerRequestModelValidator : AbstractApiUserServerRequestModelValidator, IApiUserServerRequestModelValidator
	{
		public ApiUserServerRequestModelValidator(IUserRepository userRepository)
			: base(userRepository)
		{
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
	}
}

/*<Codenesium>
    <Hash>4e0518606552f0247cd1159b9d390592</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
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
			this.AboutMeRules();
			this.AccountIdRules();
			this.AgeRules();
			this.CreationDateRules();
			this.DisplayNameRules();
			this.DownVoteRules();
			this.EmailHashRules();
			this.LastAccessDateRules();
			this.LocationRules();
			this.ReputationRules();
			this.UpVoteRules();
			this.ViewRules();
			this.WebsiteUrlRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model)
		{
			this.AboutMeRules();
			this.AccountIdRules();
			this.AgeRules();
			this.CreationDateRules();
			this.DisplayNameRules();
			this.DownVoteRules();
			this.EmailHashRules();
			this.LastAccessDateRules();
			this.LocationRules();
			this.ReputationRules();
			this.UpVoteRules();
			this.ViewRules();
			this.WebsiteUrlRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void AboutMeRules()
		{
		}

		public virtual void AccountIdRules()
		{
		}

		public virtual void AgeRules()
		{
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void DisplayNameRules()
		{
			this.RuleFor(x => x.DisplayName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.DisplayName).Length(0, 40).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DownVoteRules()
		{
		}

		public virtual void EmailHashRules()
		{
			this.RuleFor(x => x.EmailHash).Length(0, 40).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastAccessDateRules()
		{
		}

		public virtual void LocationRules()
		{
			this.RuleFor(x => x.Location).Length(0, 100).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ReputationRules()
		{
		}

		public virtual void UpVoteRules()
		{
		}

		public virtual void ViewRules()
		{
		}

		public virtual void WebsiteUrlRules()
		{
			this.RuleFor(x => x.WebsiteUrl).Length(0, 200).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>c0a529a536260194eb1b839519e52295</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
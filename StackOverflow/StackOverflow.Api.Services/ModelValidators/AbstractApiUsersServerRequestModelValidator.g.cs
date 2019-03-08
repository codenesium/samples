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
	public abstract class AbstractApiUsersServerRequestModelValidator : AbstractValidator<ApiUsersServerRequestModel>
	{
		private int existingRecordId;

		protected IUsersRepository UsersRepository { get; private set; }

		public AbstractApiUsersServerRequestModelValidator(IUsersRepository usersRepository)
		{
			this.UsersRepository = usersRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUsersServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>dab8192140e881eb017ea4a70a9173e1</Hash>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiUserServerRequestModelValidator : AbstractValidator<ApiUserServerRequestModel>
	{
		private int existingRecordId;

		private IUserRepository userRepository;

		public AbstractApiUserServerRequestModelValidator(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserServerRequestModel model, int id)
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
			this.RuleFor(x => x.DisplayName).NotNull();
			this.RuleFor(x => x.DisplayName).Length(0, 40);
		}

		public virtual void DownVoteRules()
		{
		}

		public virtual void EmailHashRules()
		{
			this.RuleFor(x => x.EmailHash).Length(0, 40);
		}

		public virtual void LastAccessDateRules()
		{
		}

		public virtual void LocationRules()
		{
			this.RuleFor(x => x.Location).Length(0, 100);
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
			this.RuleFor(x => x.WebsiteUrl).Length(0, 200);
		}
	}
}

/*<Codenesium>
    <Hash>7ed9b66993ffa115339cbbabfffdfa61</Hash>
</Codenesium>*/
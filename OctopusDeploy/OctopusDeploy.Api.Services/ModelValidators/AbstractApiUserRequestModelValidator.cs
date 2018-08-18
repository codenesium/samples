using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiUserRequestModelValidator : AbstractValidator<ApiUserRequestModel>
	{
		private string existingRecordId;

		private IUserRepository userRepository;

		public AbstractApiUserRequestModelValidator(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUserRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DisplayNameRules()
		{
			this.RuleFor(x => x.DisplayName).Length(0, 200);
		}

		public virtual void EmailAddressRules()
		{
			this.RuleFor(x => x.EmailAddress).Length(0, 400);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).Length(0, 400);
		}

		public virtual void ExternalIdentifiersRules()
		{
		}

		public virtual void IdentificationTokenRules()
		{
		}

		public virtual void IsActiveRules()
		{
		}

		public virtual void IsServiceRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void UsernameRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByUsername).When(x => x?.Username != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUserRequestModel.Username));
			this.RuleFor(x => x.Username).Length(0, 200);
		}

		private async Task<bool> BeUniqueByUsername(ApiUserRequestModel model,  CancellationToken cancellationToken)
		{
			User record = await this.userRepository.ByUsername(model.Username);

			if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>67b6d6b18892869ce48f4531adfb1606</Hash>
</Codenesium>*/
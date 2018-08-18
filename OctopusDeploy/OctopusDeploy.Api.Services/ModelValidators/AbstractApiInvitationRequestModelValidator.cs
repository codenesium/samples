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
	public abstract class AbstractApiInvitationRequestModelValidator : AbstractValidator<ApiInvitationRequestModel>
	{
		private string existingRecordId;

		private IInvitationRepository invitationRepository;

		public AbstractApiInvitationRequestModelValidator(IInvitationRepository invitationRepository)
		{
			this.invitationRepository = invitationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiInvitationRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void InvitationCodeRules()
		{
			this.RuleFor(x => x.InvitationCode).Length(0, 200);
		}

		public virtual void JSONRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>62fc8520f7dbe08fbb7900eff9ade876</Hash>
</Codenesium>*/
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
	public abstract class AbstractApiFollowingServerRequestModelValidator : AbstractValidator<ApiFollowingServerRequestModel>
	{
		private int existingRecordId;

		private IFollowingRepository followingRepository;

		public AbstractApiFollowingServerRequestModelValidator(IFollowingRepository followingRepository)
		{
			this.followingRepository = followingRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFollowingServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateFollowedRules()
		{
		}

		public virtual void MutedRules()
		{
			this.RuleFor(x => x.Muted).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>c0487b3e07a14bbc123233089036d5ca</Hash>
</Codenesium>*/
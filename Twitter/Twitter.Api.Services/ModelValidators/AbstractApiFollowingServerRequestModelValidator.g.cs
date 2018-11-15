using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
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
			this.RuleFor(x => x.Muted).Length(0, 1);
		}
	}
}

/*<Codenesium>
    <Hash>60a9cbec4aebaae362d7955b0b121c05</Hash>
</Codenesium>*/
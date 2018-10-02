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
	public abstract class AbstractApiFollowingRequestModelValidator : AbstractValidator<ApiFollowingRequestModel>
	{
		private string existingRecordId;

		private IFollowingRepository followingRepository;

		public AbstractApiFollowingRequestModelValidator(IFollowingRepository followingRepository)
		{
			this.followingRepository = followingRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiFollowingRequestModel model, string id)
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
    <Hash>7ca59f813290a443754c7669b6e4862d</Hash>
</Codenesium>*/
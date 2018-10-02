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
	public abstract class AbstractApiLikeRequestModelValidator : AbstractValidator<ApiLikeRequestModel>
	{
		private int existingRecordId;

		private ILikeRepository likeRepository;

		public AbstractApiLikeRequestModelValidator(ILikeRepository likeRepository)
		{
			this.likeRepository = likeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLikeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void LikerUserIdRules()
		{
			this.RuleFor(x => x.LikerUserId).MustAsync(this.BeValidUser).When(x => x?.LikerUserId != null).WithMessage("Invalid reference");
		}

		public virtual void TweetIdRules()
		{
			this.RuleFor(x => x.TweetId).MustAsync(this.BeValidTweet).When(x => x?.TweetId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.likeRepository.GetUser(id);

			return record != null;
		}

		private async Task<bool> BeValidTweet(int id,  CancellationToken cancellationToken)
		{
			var record = await this.likeRepository.GetTweet(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0aa671f6ef0601cd834be88160101011</Hash>
</Codenesium>*/
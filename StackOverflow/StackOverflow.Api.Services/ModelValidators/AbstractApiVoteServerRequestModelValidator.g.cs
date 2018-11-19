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
	public abstract class AbstractApiVoteServerRequestModelValidator : AbstractValidator<ApiVoteServerRequestModel>
	{
		private int existingRecordId;

		private IVoteRepository voteRepository;

		public AbstractApiVoteServerRequestModelValidator(IVoteRepository voteRepository)
		{
			this.voteRepository = voteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BountyAmountRules()
		{
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void PostIdRules()
		{
		}

		public virtual void UserIdRules()
		{
		}

		public virtual void VoteTypeIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7d8638fb8529c46f0cb9cc056ba49ff1</Hash>
</Codenesium>*/
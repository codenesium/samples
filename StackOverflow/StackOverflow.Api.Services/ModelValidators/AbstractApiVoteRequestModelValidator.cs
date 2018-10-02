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
	public abstract class AbstractApiVoteRequestModelValidator : AbstractValidator<ApiVoteRequestModel>
	{
		private int existingRecordId;

		private IVoteRepository voteRepository;

		public AbstractApiVoteRequestModelValidator(IVoteRepository voteRepository)
		{
			this.voteRepository = voteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteRequestModel model, int id)
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
    <Hash>4a2e063d61ca2c1d4fc1e5f7c34d6a23</Hash>
</Codenesium>*/
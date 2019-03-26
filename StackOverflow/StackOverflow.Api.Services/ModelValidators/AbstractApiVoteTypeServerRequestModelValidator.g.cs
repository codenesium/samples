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
	public abstract class AbstractApiVoteTypeServerRequestModelValidator : AbstractValidator<ApiVoteTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IVoteTypeRepository VoteTypeRepository { get; private set; }

		public AbstractApiVoteTypeServerRequestModelValidator(IVoteTypeRepository voteTypeRepository)
		{
			this.VoteTypeRepository = voteTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>a5461daa5c3fd4ca74042b32d5aeeb96</Hash>
</Codenesium>*/
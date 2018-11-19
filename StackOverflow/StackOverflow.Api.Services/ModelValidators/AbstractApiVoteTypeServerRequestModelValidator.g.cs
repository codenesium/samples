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

		private IVoteTypeRepository voteTypeRepository;

		public AbstractApiVoteTypeServerRequestModelValidator(IVoteTypeRepository voteTypeRepository)
		{
			this.voteTypeRepository = voteTypeRepository;
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
    <Hash>7ed6da86b25f501b467876d6fb3729ff</Hash>
</Codenesium>*/
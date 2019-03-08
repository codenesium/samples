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
	public abstract class AbstractApiVoteTypesServerRequestModelValidator : AbstractValidator<ApiVoteTypesServerRequestModel>
	{
		private int existingRecordId;

		protected IVoteTypesRepository VoteTypesRepository { get; private set; }

		public AbstractApiVoteTypesServerRequestModelValidator(IVoteTypesRepository voteTypesRepository)
		{
			this.VoteTypesRepository = voteTypesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteTypesServerRequestModel model, int id)
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
    <Hash>0963803298ec8826d535b077a852949d</Hash>
</Codenesium>*/
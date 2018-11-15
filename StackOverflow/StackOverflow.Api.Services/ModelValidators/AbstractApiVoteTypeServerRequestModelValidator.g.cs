using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>f4bd76be9922654b09cdf818bbb90dba</Hash>
</Codenesium>*/
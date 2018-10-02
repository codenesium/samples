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
	public abstract class AbstractApiVoteTypeRequestModelValidator : AbstractValidator<ApiVoteTypeRequestModel>
	{
		private int existingRecordId;

		private IVoteTypeRepository voteTypeRepository;

		public AbstractApiVoteTypeRequestModelValidator(IVoteTypeRepository voteTypeRepository)
		{
			this.voteTypeRepository = voteTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVoteTypeRequestModel model, int id)
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
    <Hash>629183b3c814c176621f2f4c532ee382</Hash>
</Codenesium>*/
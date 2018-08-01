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
	public abstract class AbstractApiBadgesRequestModelValidator : AbstractValidator<ApiBadgesRequestModel>
	{
		private int existingRecordId;

		private IBadgesRepository badgesRepository;

		public AbstractApiBadgesRequestModelValidator(IBadgesRepository badgesRepository)
		{
			this.badgesRepository = badgesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBadgesRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 40);
		}

		public virtual void UserIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>47aff4855dfab2268b1524efdc296c39</Hash>
</Codenesium>*/
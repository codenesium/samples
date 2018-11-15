using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiBadgeServerRequestModelValidator : AbstractValidator<ApiBadgeServerRequestModel>
	{
		private int existingRecordId;

		private IBadgeRepository badgeRepository;

		public AbstractApiBadgeServerRequestModelValidator(IBadgeRepository badgeRepository)
		{
			this.badgeRepository = badgeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBadgeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 40);
		}

		public virtual void UserIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7f3e51a94fe2f7ba05cd9cd38cd8918c</Hash>
</Codenesium>*/
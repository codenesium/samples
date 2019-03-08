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
	public abstract class AbstractApiBadgesServerRequestModelValidator : AbstractValidator<ApiBadgesServerRequestModel>
	{
		private int existingRecordId;

		protected IBadgesRepository BadgesRepository { get; private set; }

		public AbstractApiBadgesServerRequestModelValidator(IBadgesRepository badgesRepository)
		{
			this.BadgesRepository = badgesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBadgesServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 40).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUsersByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidUsersByUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.BadgesRepository.UsersByUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>4e336097155bba78359794e1a3905827</Hash>
</Codenesium>*/
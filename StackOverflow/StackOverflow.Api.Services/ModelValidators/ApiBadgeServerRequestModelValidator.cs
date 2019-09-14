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
	public class ApiBadgeServerRequestModelValidator : AbstractValidator<ApiBadgeServerRequestModel>, IApiBadgeServerRequestModelValidator
	{
		private int existingRecordId;

		protected IBadgeRepository BadgeRepository { get; private set; }

		public ApiBadgeServerRequestModelValidator(IBadgeRepository badgeRepository)
		{
			this.BadgeRepository = badgeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiBadgeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBadgeServerRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgeServerRequestModel model)
		{
			this.DateRules();
			this.NameRules();
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidUserByUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.BadgeRepository.UserByUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b5ed76e9981b5430af0ff6d88bf88b44</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkLogServerRequestModelValidator : AbstractValidator<ApiLinkLogServerRequestModel>
	{
		private int existingRecordId;

		private ILinkLogRepository linkLogRepository;

		public AbstractApiLinkLogServerRequestModelValidator(ILinkLogRepository linkLogRepository)
		{
			this.linkLogRepository = linkLogRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkLogServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateEnteredRules()
		{
		}

		public virtual void LinkIdRules()
		{
			this.RuleFor(x => x.LinkId).MustAsync(this.BeValidLinkByLinkId).When(x => !x?.LinkId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void LogRules()
		{
			this.RuleFor(x => x.Log).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Log).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeValidLinkByLinkId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.linkLogRepository.LinkByLinkId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c94496b9ae0377e1f4cb3258e408ffb1</Hash>
</Codenesium>*/
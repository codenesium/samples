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

		protected ILinkLogRepository LinkLogRepository { get; private set; }

		public AbstractApiLinkLogServerRequestModelValidator(ILinkLogRepository linkLogRepository)
		{
			this.LinkLogRepository = linkLogRepository;
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

		protected async Task<bool> BeValidLinkByLinkId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.LinkLogRepository.LinkByLinkId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f7583b091dbe10a244c866773569acd7</Hash>
</Codenesium>*/
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
	public abstract class AbstractApiLinkStatusServerRequestModelValidator : AbstractValidator<ApiLinkStatusServerRequestModel>
	{
		private int existingRecordId;

		protected ILinkStatusRepository LinkStatusRepository { get; private set; }

		public AbstractApiLinkStatusServerRequestModelValidator(ILinkStatusRepository linkStatusRepository)
		{
			this.LinkStatusRepository = linkStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkStatusServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByName(ApiLinkStatusServerRequestModel model,  CancellationToken cancellationToken)
		{
			LinkStatus record = await this.LinkStatusRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.Id == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>a8e0dea1374fd6679b72c3d00abff6c5</Hash>
</Codenesium>*/
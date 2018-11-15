using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiLinkStatusServerRequestModelValidator : AbstractValidator<ApiLinkStatusServerRequestModel>
	{
		private int existingRecordId;

		private ILinkStatusRepository linkStatusRepository;

		public AbstractApiLinkStatusServerRequestModelValidator(ILinkStatusRepository linkStatusRepository)
		{
			this.linkStatusRepository = linkStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkStatusServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByName(ApiLinkStatusServerRequestModel model,  CancellationToken cancellationToken)
		{
			LinkStatus record = await this.linkStatusRepository.ByName(model.Name);

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
    <Hash>747cb30ec9ed16f4a0090099e103d5c7</Hash>
</Codenesium>*/
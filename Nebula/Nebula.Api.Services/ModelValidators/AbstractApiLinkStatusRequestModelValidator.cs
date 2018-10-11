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
	public abstract class AbstractApiLinkStatusRequestModelValidator : AbstractValidator<ApiLinkStatusRequestModel>
	{
		private int existingRecordId;

		private ILinkStatusRepository linkStatusRepository;

		public AbstractApiLinkStatusRequestModelValidator(ILinkStatusRepository linkStatusRepository)
		{
			this.linkStatusRepository = linkStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkStatusRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByName(ApiLinkStatusRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>323d84bf392cc34545e4e1aa29120ce2</Hash>
</Codenesium>*/
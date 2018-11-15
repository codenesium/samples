using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiChainStatusServerRequestModelValidator : AbstractValidator<ApiChainStatusServerRequestModel>
	{
		private int existingRecordId;

		private IChainStatusRepository chainStatusRepository;

		public AbstractApiChainStatusServerRequestModelValidator(IChainStatusRepository chainStatusRepository)
		{
			this.chainStatusRepository = chainStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiChainStatusServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByName(ApiChainStatusServerRequestModel model,  CancellationToken cancellationToken)
		{
			ChainStatus record = await this.chainStatusRepository.ByName(model.Name);

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
    <Hash>89ce659fdea9522f703145d7f47094dc</Hash>
</Codenesium>*/
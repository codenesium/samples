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
	public abstract class AbstractApiChainStatusRequestModelValidator : AbstractValidator<ApiChainStatusRequestModel>
	{
		private int existingRecordId;

		private IChainStatusRepository chainStatusRepository;

		public AbstractApiChainStatusRequestModelValidator(IChainStatusRepository chainStatusRepository)
		{
			this.chainStatusRepository = chainStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainStatusRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChainStatusRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByName(ApiChainStatusRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>3aa83f0b0ed6c743d3670b81ef5db7b9</Hash>
</Codenesium>*/
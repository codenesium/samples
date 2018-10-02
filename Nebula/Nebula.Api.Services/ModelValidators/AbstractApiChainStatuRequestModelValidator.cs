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
	public abstract class AbstractApiChainStatuRequestModelValidator : AbstractValidator<ApiChainStatuRequestModel>
	{
		private int existingRecordId;

		private IChainStatuRepository chainStatuRepository;

		public AbstractApiChainStatuRequestModelValidator(IChainStatuRepository chainStatuRepository)
		{
			this.chainStatuRepository = chainStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainStatuRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChainStatuRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByName(ApiChainStatuRequestModel model,  CancellationToken cancellationToken)
		{
			ChainStatu record = await this.chainStatuRepository.ByName(model.Name);

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
    <Hash>bec9cc4acc3b8b22b31da632bc86e8da</Hash>
</Codenesium>*/
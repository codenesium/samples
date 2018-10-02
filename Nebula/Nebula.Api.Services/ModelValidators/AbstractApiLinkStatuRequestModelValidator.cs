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
	public abstract class AbstractApiLinkStatuRequestModelValidator : AbstractValidator<ApiLinkStatuRequestModel>
	{
		private int existingRecordId;

		private ILinkStatuRepository linkStatuRepository;

		public AbstractApiLinkStatuRequestModelValidator(ILinkStatuRepository linkStatuRepository)
		{
			this.linkStatuRepository = linkStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkStatuRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLinkStatuRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeUniqueByName(ApiLinkStatuRequestModel model,  CancellationToken cancellationToken)
		{
			LinkStatu record = await this.linkStatuRepository.ByName(model.Name);

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
    <Hash>c7164e8d04b67ff134ce56ff2eca7e0d</Hash>
</Codenesium>*/
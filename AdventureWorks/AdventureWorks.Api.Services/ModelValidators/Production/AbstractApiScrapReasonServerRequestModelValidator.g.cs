using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiScrapReasonServerRequestModelValidator : AbstractValidator<ApiScrapReasonServerRequestModel>
	{
		private short existingRecordId;

		private IScrapReasonRepository scrapReasonRepository;

		public AbstractApiScrapReasonServerRequestModelValidator(IScrapReasonRepository scrapReasonRepository)
		{
			this.scrapReasonRepository = scrapReasonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiScrapReasonServerRequestModel model, short id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiScrapReasonServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiScrapReasonServerRequestModel model,  CancellationToken cancellationToken)
		{
			ScrapReason record = await this.scrapReasonRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(short) && record.ScrapReasonID == this.existingRecordId))
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
    <Hash>9df6a10bc2134d3b9450df409205bdac</Hash>
</Codenesium>*/
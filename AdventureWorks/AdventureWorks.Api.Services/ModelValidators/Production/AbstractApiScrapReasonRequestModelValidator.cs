using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiScrapReasonRequestModelValidator : AbstractValidator<ApiScrapReasonRequestModel>
	{
		private short existingRecordId;

		private IScrapReasonRepository scrapReasonRepository;

		public AbstractApiScrapReasonRequestModelValidator(IScrapReasonRepository scrapReasonRepository)
		{
			this.scrapReasonRepository = scrapReasonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiScrapReasonRequestModel model, short id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiScrapReasonRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiScrapReasonRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>89ce7fc01e4559a6eeba7123f66d5827</Hash>
</Codenesium>*/
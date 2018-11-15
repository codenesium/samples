using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductDescriptionServerRequestModelValidator : AbstractValidator<ApiProductDescriptionServerRequestModel>
	{
		private int existingRecordId;

		private IProductDescriptionRepository productDescriptionRepository;

		public AbstractApiProductDescriptionServerRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
		{
			this.productDescriptionRepository = productDescriptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductDescriptionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 400);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductDescriptionServerRequestModel.Rowguid));
		}

		private async Task<bool> BeUniqueByRowguid(ApiProductDescriptionServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductDescription record = await this.productDescriptionRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductDescriptionID == this.existingRecordId))
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
    <Hash>562a38e58cf4669821b0efe4dc8e7577</Hash>
</Codenesium>*/
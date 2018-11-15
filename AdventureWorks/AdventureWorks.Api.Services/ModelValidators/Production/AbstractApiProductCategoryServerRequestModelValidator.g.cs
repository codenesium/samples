using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductCategoryServerRequestModelValidator : AbstractValidator<ApiProductCategoryServerRequestModel>
	{
		private int existingRecordId;

		private IProductCategoryRepository productCategoryRepository;

		public AbstractApiProductCategoryServerRequestModelValidator(IProductCategoryRepository productCategoryRepository)
		{
			this.productCategoryRepository = productCategoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductCategoryServerRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryServerRequestModel.Rowguid));
		}

		private async Task<bool> BeUniqueByName(ApiProductCategoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductCategory record = await this.productCategoryRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductCategoryID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiProductCategoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductCategory record = await this.productCategoryRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductCategoryID == this.existingRecordId))
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
    <Hash>7e8170b9a04b404472f97cc2670936c2</Hash>
</Codenesium>*/
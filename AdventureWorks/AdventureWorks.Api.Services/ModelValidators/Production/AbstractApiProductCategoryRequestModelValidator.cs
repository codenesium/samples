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
	public abstract class AbstractApiProductCategoryRequestModelValidator : AbstractValidator<ApiProductCategoryRequestModel>
	{
		private int existingRecordId;

		private IProductCategoryRepository productCategoryRepository;

		public AbstractApiProductCategoryRequestModelValidator(IProductCategoryRepository productCategoryRepository)
		{
			this.productCategoryRepository = productCategoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductCategoryRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductCategoryRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiProductCategoryRequestModel model,  CancellationToken cancellationToken)
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
	}
}

/*<Codenesium>
    <Hash>6e19a8271e21a448cca1e9075edd5b41</Hash>
</Codenesium>*/
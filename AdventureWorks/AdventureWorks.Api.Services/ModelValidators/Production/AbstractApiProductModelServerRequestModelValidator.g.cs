using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductModelServerRequestModelValidator : AbstractValidator<ApiProductModelServerRequestModel>
	{
		private int existingRecordId;

		private IProductModelRepository productModelRepository;

		public AbstractApiProductModelServerRequestModelValidator(IProductModelRepository productModelRepository)
		{
			this.productModelRepository = productModelRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CatalogDescriptionRules()
		{
		}

		public virtual void InstructionRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelServerRequestModel.Rowguid));
		}

		private async Task<bool> BeUniqueByName(ApiProductModelServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.productModelRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ProductModelID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiProductModelServerRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.productModelRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ProductModelID == this.existingRecordId))
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
    <Hash>9f0cb133c52e50888800886dff39de22</Hash>
</Codenesium>*/
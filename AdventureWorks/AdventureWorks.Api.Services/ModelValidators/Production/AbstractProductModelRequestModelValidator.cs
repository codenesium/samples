using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiProductModelRequestModelValidator: AbstractValidator<ApiProductModelRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiProductModelRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IProductModelRepository ProductModelRepository { get; set; }
		public virtual void CatalogDescriptionRules()
		{                       }

		public virtual void InstructionsRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private async Task<bool> BeUniqueGetName(ApiProductModelRequestModel model,  CancellationToken cancellationToken)
		{
			ProductModel record = await this.ProductModelRepository.GetName(model.Name);

			if(record == null || record.ProductModelID == this.existingRecordId)
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
    <Hash>79eab1fc7daa7a8f8adab934290ee97d</Hash>
</Codenesium>*/
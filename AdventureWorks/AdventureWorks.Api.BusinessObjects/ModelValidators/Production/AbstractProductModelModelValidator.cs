using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductModelModelValidator: AbstractValidator<ApiProductModelModel>
	{
		public new ValidationResult Validate(ApiProductModelModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelModel model)
		{
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
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProductModelModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeUniqueGetName(ApiProductModelModel model)
		{
			return this.ProductModelRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>59b60e342b62dd20adbb1d2f27be0a4a</Hash>
</Codenesium>*/
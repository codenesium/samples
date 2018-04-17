using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractProductCostHistoryModelValidator: AbstractValidator<ProductCostHistoryModel>
	{
		public new ValidationResult Validate(ProductCostHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductCostHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository { get; set; }
		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void StandardCostRules()
		{
			this.RuleFor(x => x.StandardCost).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>48776ea9a58eb2a2315f1d0a59ad0477</Hash>
</Codenesium>*/
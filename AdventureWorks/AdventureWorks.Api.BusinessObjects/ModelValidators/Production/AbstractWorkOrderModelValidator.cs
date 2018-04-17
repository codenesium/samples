using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractWorkOrderModelValidator: AbstractValidator<WorkOrderModel>
	{
		public new ValidationResult Validate(WorkOrderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(WorkOrderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IProductRepository ProductRepository { get; set; }
		public IScrapReasonRepository ScrapReasonRepository { get; set; }
		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
			this.RuleFor(x => x.ProductID).Must(this.BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void OrderQtyRules()
		{
			this.RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			this.RuleFor(x => x.StockedQty).NotNull();
		}

		public virtual void ScrappedQtyRules()
		{
			this.RuleFor(x => x.ScrappedQty).NotNull();
		}

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void DueDateRules()
		{
			this.RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void ScrapReasonIDRules()
		{
			this.RuleFor(x => x.ScrapReasonID).Must(this.BeValidScrapReason).When(x => x ?.ScrapReasonID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidScrapReason(Nullable<short> id)
		{
			return this.ScrapReasonRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}
	}
}

/*<Codenesium>
    <Hash>2dfc0dace30c84f33f7e72a8daa3eabe</Hash>
</Codenesium>*/
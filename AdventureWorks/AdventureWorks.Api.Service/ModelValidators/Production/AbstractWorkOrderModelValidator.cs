using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public IProductRepository ProductRepository {get; set;}
		public IScrapReasonRepository ScrapReasonRepository {get; set;}
		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
			RuleFor(x => x.ProductID).Must(BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void OrderQtyRules()
		{
			RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			RuleFor(x => x.StockedQty).NotNull();
		}

		public virtual void ScrappedQtyRules()
		{
			RuleFor(x => x.ScrappedQty).NotNull();
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void DueDateRules()
		{
			RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void ScrapReasonIDRules()
		{
			RuleFor(x => x.ScrapReasonID).Must(BeValidScrapReason).When(x => x ?.ScrapReasonID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidProduct(int id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id,response);
			return response.Products.Count > 0;
		}

		public bool BeValidScrapReason(Nullable<short> id)
		{
			Response response = new Response();

			this.ScrapReasonRepository.GetById(id.GetValueOrDefault(),response);
			return response.ScrapReasons.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>ed38b1b1814fccf63ad6d320b221f264</Hash>
</Codenesium>*/
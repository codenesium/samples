using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiWorkOrderModelValidator: AbstractValidator<ApiWorkOrderModel>
	{
		public new ValidationResult Validate(ApiWorkOrderModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiWorkOrderModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DueDateRules()
		{
			this.RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void EndDateRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			this.RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void ScrappedQtyRules()
		{
			this.RuleFor(x => x.ScrappedQty).NotNull();
		}

		public virtual void ScrapReasonIDRules()
		{                       }

		public virtual void StartDateRules()
		{
			this.RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			this.RuleFor(x => x.StockedQty).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>6ffb315e139d351fe0ec6c1acad83f52</Hash>
</Codenesium>*/
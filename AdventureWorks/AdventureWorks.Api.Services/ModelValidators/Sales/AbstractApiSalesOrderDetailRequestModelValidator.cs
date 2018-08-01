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
	public abstract class AbstractApiSalesOrderDetailRequestModelValidator : AbstractValidator<ApiSalesOrderDetailRequestModel>
	{
		private int existingRecordId;

		private ISalesOrderDetailRepository salesOrderDetailRepository;

		public AbstractApiSalesOrderDetailRequestModelValidator(ISalesOrderDetailRepository salesOrderDetailRepository)
		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderDetailRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CarrierTrackingNumberRules()
		{
			this.RuleFor(x => x.CarrierTrackingNumber).Length(0, 25);
		}

		public virtual void LineTotalRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OrderQtyRules()
		{
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).MustAsync(this.BeValidSpecialOfferProduct).When(x => x?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void SalesOrderDetailIDRules()
		{
		}

		public virtual void SpecialOfferIDRules()
		{
			this.RuleFor(x => x.SpecialOfferID).MustAsync(this.BeValidSpecialOfferProduct).When(x => x?.SpecialOfferID != null).WithMessage("Invalid reference");
		}

		public virtual void UnitPriceRules()
		{
		}

		public virtual void UnitPriceDiscountRules()
		{
		}

		private async Task<bool> BeValidSpecialOfferProduct(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesOrderDetailRepository.GetSpecialOfferProduct(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesOrderHeader(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesOrderDetailRepository.GetSalesOrderHeader(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f5d558d88f5be0e47998102c139d2012</Hash>
</Codenesium>*/
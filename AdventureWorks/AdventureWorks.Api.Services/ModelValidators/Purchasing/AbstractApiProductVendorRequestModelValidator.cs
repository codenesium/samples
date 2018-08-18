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
	public abstract class AbstractApiProductVendorRequestModelValidator : AbstractValidator<ApiProductVendorRequestModel>
	{
		private int existingRecordId;

		private IProductVendorRepository productVendorRepository;

		public AbstractApiProductVendorRequestModelValidator(IProductVendorRepository productVendorRepository)
		{
			this.productVendorRepository = productVendorRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductVendorRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AverageLeadTimeRules()
		{
		}

		public virtual void BusinessEntityIDRules()
		{
		}

		public virtual void LastReceiptCostRules()
		{
		}

		public virtual void LastReceiptDateRules()
		{
		}

		public virtual void MaxOrderQtyRules()
		{
		}

		public virtual void MinOrderQtyRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OnOrderQtyRules()
		{
		}

		public virtual void StandardPriceRules()
		{
		}

		public virtual void UnitMeasureCodeRules()
		{
			this.RuleFor(x => x.UnitMeasureCode).NotNull();
			this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
		}
	}
}

/*<Codenesium>
    <Hash>fc02209dc5a2601f20e980705aa07582</Hash>
</Codenesium>*/
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
	public abstract class AbstractApiPurchaseOrderHeaderServerRequestModelValidator : AbstractValidator<ApiPurchaseOrderHeaderServerRequestModel>
	{
		private int existingRecordId;

		protected IPurchaseOrderHeaderRepository PurchaseOrderHeaderRepository { get; private set; }

		public AbstractApiPurchaseOrderHeaderServerRequestModelValidator(IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository)
		{
			this.PurchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderHeaderServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmployeeIDRules()
		{
		}

		public virtual void FreightRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OrderDateRules()
		{
		}

		public virtual void RevisionNumberRules()
		{
		}

		public virtual void ShipDateRules()
		{
		}

		public virtual void ShipMethodIDRules()
		{
		}

		public virtual void StatusRules()
		{
		}

		public virtual void SubTotalRules()
		{
		}

		public virtual void TaxAmtRules()
		{
		}

		public virtual void TotalDueRules()
		{
		}

		public virtual void VendorIDRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>49ccc3557cf580ed4c0ea83621c17f06</Hash>
</Codenesium>*/
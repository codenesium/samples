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

		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;

		public AbstractApiPurchaseOrderHeaderServerRequestModelValidator(IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository)
		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
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
    <Hash>0bf96eb5fc4f4b37de33cc6c78ab8052</Hash>
</Codenesium>*/
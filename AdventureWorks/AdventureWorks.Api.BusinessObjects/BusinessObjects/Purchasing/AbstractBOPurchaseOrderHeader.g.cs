using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOPurchaseOrderHeader
	{
		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;
		private IApiPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator;
		private ILogger logger;

		public AbstractBOPurchaseOrderHeader(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderModelValidator purchaseOrderHeaderModelValidator)

		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPurchaseOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.purchaseOrderHeaderRepository.All(skip, take, orderClause);
		}

		public virtual POCOPurchaseOrderHeader Get(int purchaseOrderID)
		{
			return this.purchaseOrderHeaderRepository.Get(purchaseOrderID);
		}

		public virtual async Task<CreateResponse<POCOPurchaseOrderHeader>> Create(
			ApiPurchaseOrderHeaderModel model)
		{
			CreateResponse<POCOPurchaseOrderHeader> response = new CreateResponse<POCOPurchaseOrderHeader>(await this.purchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPurchaseOrderHeader record = this.purchaseOrderHeaderRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderModel model)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model));

			if (response.Success)
			{
				this.purchaseOrderHeaderRepository.Update(purchaseOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				this.purchaseOrderHeaderRepository.Delete(purchaseOrderID);
			}
			return response;
		}

		public List<POCOPurchaseOrderHeader> GetEmployeeID(int employeeID)
		{
			return this.purchaseOrderHeaderRepository.GetEmployeeID(employeeID);
		}
		public List<POCOPurchaseOrderHeader> GetVendorID(int vendorID)
		{
			return this.purchaseOrderHeaderRepository.GetVendorID(vendorID);
		}
	}
}

/*<Codenesium>
    <Hash>4dbe0e14c0ca22215fee3600662708d9</Hash>
</Codenesium>*/
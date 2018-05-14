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
	public abstract class AbstractBOSalesOrderHeader
	{
		private ISalesOrderHeaderRepository salesOrderHeaderRepository;
		private IApiSalesOrderHeaderModelValidator salesOrderHeaderModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderHeader(
			ILogger logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderModelValidator salesOrderHeaderModelValidator)

		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
			this.salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSalesOrderHeader> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderRepository.All(skip, take, orderClause);
		}

		public virtual POCOSalesOrderHeader Get(int salesOrderID)
		{
			return this.salesOrderHeaderRepository.Get(salesOrderID);
		}

		public virtual async Task<CreateResponse<POCOSalesOrderHeader>> Create(
			ApiSalesOrderHeaderModel model)
		{
			CreateResponse<POCOSalesOrderHeader> response = new CreateResponse<POCOSalesOrderHeader>(await this.salesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesOrderHeader record = this.salesOrderHeaderRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderHeaderModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				this.salesOrderHeaderRepository.Update(salesOrderID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				this.salesOrderHeaderRepository.Delete(salesOrderID);
			}
			return response;
		}

		public POCOSalesOrderHeader GetSalesOrderNumber(string salesOrderNumber)
		{
			return this.salesOrderHeaderRepository.GetSalesOrderNumber(salesOrderNumber);
		}

		public List<POCOSalesOrderHeader> GetCustomerID(int customerID)
		{
			return this.salesOrderHeaderRepository.GetCustomerID(customerID);
		}
		public List<POCOSalesOrderHeader> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			return this.salesOrderHeaderRepository.GetSalesPersonID(salesPersonID);
		}
	}
}

/*<Codenesium>
    <Hash>889e7b7655a9c438f407bb539b9d7656</Hash>
</Codenesium>*/
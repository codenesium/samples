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
		private ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator;
		private ILogger logger;

		public AbstractBOSalesOrderHeader(
			ILogger logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator)

		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
			this.salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesOrderHeaderModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesOrderHeaderRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			SalesOrderHeaderModel model)
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

		public virtual ApiResponse GetById(int salesOrderID)
		{
			return this.salesOrderHeaderRepository.GetById(salesOrderID);
		}

		public virtual POCOSalesOrderHeader GetByIdDirect(int salesOrderID)
		{
			return this.salesOrderHeaderRepository.GetByIdDirect(salesOrderID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesOrderHeader> GetWhereDirect(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesOrderHeaderRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>e1f6d4575e64b63e950423db3a54c781</Hash>
</Codenesium>*/
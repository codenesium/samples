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
	public abstract class AbstractBOSalesPersonQuotaHistory
	{
		private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;
		private ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesPersonQuotaHistory(
			ILogger logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			ISalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator)

		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this.salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesPersonQuotaHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesPersonQuotaHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesPersonQuotaHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			SalesPersonQuotaHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.salesPersonQuotaHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.salesPersonQuotaHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.salesPersonQuotaHistoryRepository.GetById(businessEntityID);
		}

		public virtual POCOSalesPersonQuotaHistory GetByIdDirect(int businessEntityID)
		{
			return this.salesPersonQuotaHistoryRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonQuotaHistoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonQuotaHistoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesPersonQuotaHistory> GetWhereDirect(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonQuotaHistoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>01996732bbcd080211a911493068130a</Hash>
</Codenesium>*/
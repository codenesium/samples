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
	public abstract class AbstractBOSalesPersonQuotaHistory: AbstractBOManager
	{
		private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;
		private IApiSalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesPersonQuotaHistory(
			ILogger logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryModelValidator salesPersonQuotaHistoryModelValidator)
			: base()

		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this.salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesPersonQuotaHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonQuotaHistoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesPersonQuotaHistory> Get(int businessEntityID)
		{
			return this.salesPersonQuotaHistoryRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOSalesPersonQuotaHistory>> Create(
			ApiSalesPersonQuotaHistoryModel model)
		{
			CreateResponse<POCOSalesPersonQuotaHistory> response = new CreateResponse<POCOSalesPersonQuotaHistory>(await this.salesPersonQuotaHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesPersonQuotaHistory record = await this.salesPersonQuotaHistoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.salesPersonQuotaHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.salesPersonQuotaHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>42824e8e410135d3c4deb081ee2d895d</Hash>
</Codenesium>*/
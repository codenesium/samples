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
	public abstract class AbstractBOSalesTerritoryHistory: AbstractBOManager
	{
		private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;
		private IApiSalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesTerritoryHistory(
			ILogger logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator)
			: base()

		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesTerritoryHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryHistoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesTerritoryHistory> Get(int businessEntityID)
		{
			return this.salesTerritoryHistoryRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOSalesTerritoryHistory>> Create(
			ApiSalesTerritoryHistoryModel model)
		{
			CreateResponse<POCOSalesTerritoryHistory> response = new CreateResponse<POCOSalesTerritoryHistory>(await this.salesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesTerritoryHistory record = await this.salesTerritoryHistoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesTerritoryHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.salesTerritoryHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.salesTerritoryHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>959c64bc6a65e13de774ae8b976a8f7f</Hash>
</Codenesium>*/
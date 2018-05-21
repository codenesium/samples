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
	public abstract class AbstractBOSalesTerritory: AbstractBOManager
	{
		private ISalesTerritoryRepository salesTerritoryRepository;
		private IApiSalesTerritoryModelValidator salesTerritoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesTerritory(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryModelValidator salesTerritoryModelValidator)
			: base()

		{
			this.salesTerritoryRepository = salesTerritoryRepository;
			this.salesTerritoryModelValidator = salesTerritoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesTerritory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesTerritory> Get(int territoryID)
		{
			return this.salesTerritoryRepository.Get(territoryID);
		}

		public virtual async Task<CreateResponse<POCOSalesTerritory>> Create(
			ApiSalesTerritoryModel model)
		{
			CreateResponse<POCOSalesTerritory> response = new CreateResponse<POCOSalesTerritory>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesTerritory record = await this.salesTerritoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int territoryID,
			ApiSalesTerritoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryModelValidator.ValidateUpdateAsync(territoryID, model));

			if (response.Success)
			{
				await this.salesTerritoryRepository.Update(territoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int territoryID)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryModelValidator.ValidateDeleteAsync(territoryID));

			if (response.Success)
			{
				await this.salesTerritoryRepository.Delete(territoryID);
			}
			return response;
		}

		public async Task<POCOSalesTerritory> GetName(string name)
		{
			return await this.salesTerritoryRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>a93d460fc73a8466afc2c63e4a5fd42f</Hash>
</Codenesium>*/
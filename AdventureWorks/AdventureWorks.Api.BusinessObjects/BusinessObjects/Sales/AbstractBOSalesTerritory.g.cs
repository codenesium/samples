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
	public abstract class AbstractBOSalesTerritory
	{
		private ISalesTerritoryRepository salesTerritoryRepository;
		private IApiSalesTerritoryModelValidator salesTerritoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesTerritory(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryModelValidator salesTerritoryModelValidator)

		{
			this.salesTerritoryRepository = salesTerritoryRepository;
			this.salesTerritoryModelValidator = salesTerritoryModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryRepository.All(skip, take, orderClause);
		}

		public virtual POCOSalesTerritory Get(int territoryID)
		{
			return this.salesTerritoryRepository.Get(territoryID);
		}

		public virtual async Task<CreateResponse<POCOSalesTerritory>> Create(
			ApiSalesTerritoryModel model)
		{
			CreateResponse<POCOSalesTerritory> response = new CreateResponse<POCOSalesTerritory>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesTerritory record = this.salesTerritoryRepository.Create(model);
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
				this.salesTerritoryRepository.Update(territoryID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int territoryID)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryModelValidator.ValidateDeleteAsync(territoryID));

			if (response.Success)
			{
				this.salesTerritoryRepository.Delete(territoryID);
			}
			return response;
		}

		public POCOSalesTerritory GetName(string name)
		{
			return this.salesTerritoryRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>ff2d50cbee710c040857ef3e3485b4cc</Hash>
</Codenesium>*/
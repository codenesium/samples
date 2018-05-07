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
		private ISalesTerritoryModelValidator salesTerritoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesTerritory(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			ISalesTerritoryModelValidator salesTerritoryModelValidator)

		{
			this.salesTerritoryRepository = salesTerritoryRepository;
			this.salesTerritoryModelValidator = salesTerritoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesTerritoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesTerritoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int territoryID,
			SalesTerritoryModel model)
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

		public virtual POCOSalesTerritory Get(int territoryID)
		{
			return this.salesTerritoryRepository.Get(territoryID);
		}

		public virtual List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>3f76a78f273acb2f6127de917c2ca29e</Hash>
</Codenesium>*/
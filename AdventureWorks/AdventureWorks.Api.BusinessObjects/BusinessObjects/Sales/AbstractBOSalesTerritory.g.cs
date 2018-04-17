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

		public virtual ApiResponse GetById(int territoryID)
		{
			return this.salesTerritoryRepository.GetById(territoryID);
		}

		public virtual POCOSalesTerritory GetByIdDirect(int territoryID)
		{
			return this.salesTerritoryRepository.GetByIdDirect(territoryID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>44e54165a607ac7d149fbbe75b516aa9</Hash>
</Codenesium>*/
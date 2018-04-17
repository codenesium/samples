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
	public abstract class AbstractBOSalesTerritoryHistory
	{
		private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;
		private ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator;
		private ILogger logger;

		public AbstractBOSalesTerritoryHistory(
			ILogger logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			ISalesTerritoryHistoryModelValidator salesTerritoryHistoryModelValidator)

		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesTerritoryHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesTerritoryHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			SalesTerritoryHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.salesTerritoryHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.salesTerritoryHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.salesTerritoryHistoryRepository.GetById(businessEntityID);
		}

		public virtual POCOSalesTerritoryHistory GetByIdDirect(int businessEntityID)
		{
			return this.salesTerritoryHistoryRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryHistoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryHistoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesTerritoryHistory> GetWhereDirect(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesTerritoryHistoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>3ec2d933281343ab29eea26817a4b00c</Hash>
</Codenesium>*/
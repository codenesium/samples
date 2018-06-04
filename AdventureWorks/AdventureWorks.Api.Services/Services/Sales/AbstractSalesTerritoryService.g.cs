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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesTerritoryService: AbstractService
	{
		private ISalesTerritoryRepository salesTerritoryRepository;
		private IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator;
		private IBOLSalesTerritoryMapper BOLSalesTerritoryMapper;
		private IDALSalesTerritoryMapper DALSalesTerritoryMapper;
		private ILogger logger;

		public AbstractSalesTerritoryService(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper bolsalesTerritoryMapper,
			IDALSalesTerritoryMapper dalsalesTerritoryMapper)
			: base()

		{
			this.salesTerritoryRepository = salesTerritoryRepository;
			this.salesTerritoryModelValidator = salesTerritoryModelValidator;
			this.BOLSalesTerritoryMapper = bolsalesTerritoryMapper;
			this.DALSalesTerritoryMapper = dalsalesTerritoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesTerritoryRepository.All(skip, take, orderClause);

			return this.BOLSalesTerritoryMapper.MapBOToModel(this.DALSalesTerritoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> Get(int territoryID)
		{
			var record = await salesTerritoryRepository.Get(territoryID);

			return this.BOLSalesTerritoryMapper.MapBOToModel(this.DALSalesTerritoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
			ApiSalesTerritoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryResponseModel> response = new CreateResponse<ApiSalesTerritoryResponseModel>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesTerritoryMapper.MapModelToBO(default (int), model);
				var record = await this.salesTerritoryRepository.Create(this.DALSalesTerritoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesTerritoryMapper.MapBOToModel(this.DALSalesTerritoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int territoryID,
			ApiSalesTerritoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryModelValidator.ValidateUpdateAsync(territoryID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesTerritoryMapper.MapModelToBO(territoryID, model);
				await this.salesTerritoryRepository.Update(this.DALSalesTerritoryMapper.MapBOToEF(bo));
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

		public async Task<ApiSalesTerritoryResponseModel> GetName(string name)
		{
			SalesTerritory record = await this.salesTerritoryRepository.GetName(name);

			return this.BOLSalesTerritoryMapper.MapBOToModel(this.DALSalesTerritoryMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>1611978067a4a91975bbda7668040606</Hash>
</Codenesium>*/
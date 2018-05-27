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
		private IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator;
		private IBOLSalesTerritoryMapper salesTerritoryMapper;
		private ILogger logger;

		public AbstractBOSalesTerritory(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper salesTerritoryMapper)
			: base()

		{
			this.salesTerritoryRepository = salesTerritoryRepository;
			this.salesTerritoryModelValidator = salesTerritoryModelValidator;
			this.salesTerritoryMapper = salesTerritoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesTerritoryRepository.All(skip, take, orderClause);

			return this.salesTerritoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> Get(int territoryID)
		{
			var record = await salesTerritoryRepository.Get(territoryID);

			return this.salesTerritoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
			ApiSalesTerritoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryResponseModel> response = new CreateResponse<ApiSalesTerritoryResponseModel>(await this.salesTerritoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesTerritoryMapper.MapModelToDTO(default (int), model);
				var record = await this.salesTerritoryRepository.Create(dto);

				response.SetRecord(this.salesTerritoryMapper.MapDTOToModel(record));
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
				var dto = this.salesTerritoryMapper.MapModelToDTO(territoryID, model);
				await this.salesTerritoryRepository.Update(territoryID, dto);
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
			DTOSalesTerritory record = await this.salesTerritoryRepository.GetName(name);

			return this.salesTerritoryMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>68579229d0fa62339e73002f0ab85a56</Hash>
</Codenesium>*/
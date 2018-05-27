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
		private IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator;
		private IBOLSalesTerritoryHistoryMapper salesTerritoryHistoryMapper;
		private ILogger logger;

		public AbstractBOSalesTerritoryHistory(
			ILogger logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper salesTerritoryHistoryMapper)
			: base()

		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
			this.salesTerritoryHistoryMapper = salesTerritoryHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesTerritoryHistoryRepository.All(skip, take, orderClause);

			return this.salesTerritoryHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await salesTerritoryHistoryRepository.Get(businessEntityID);

			return this.salesTerritoryHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
			ApiSalesTerritoryHistoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryHistoryResponseModel> response = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(await this.salesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesTerritoryHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.salesTerritoryHistoryRepository.Create(dto);

				response.SetRecord(this.salesTerritoryHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesTerritoryHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesTerritoryHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.salesTerritoryHistoryMapper.MapModelToDTO(businessEntityID, model);
				await this.salesTerritoryHistoryRepository.Update(businessEntityID, dto);
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
    <Hash>25d555ec55e53616048bb0264c151973</Hash>
</Codenesium>*/
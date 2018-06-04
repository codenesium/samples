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
	public abstract class AbstractSalesTerritoryHistoryService: AbstractService
	{
		private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;
		private IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator;
		private IBOLSalesTerritoryHistoryMapper BOLSalesTerritoryHistoryMapper;
		private IDALSalesTerritoryHistoryMapper DALSalesTerritoryHistoryMapper;
		private ILogger logger;

		public AbstractSalesTerritoryHistoryService(
			ILogger logger,
			ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository,
			IApiSalesTerritoryHistoryRequestModelValidator salesTerritoryHistoryModelValidator,
			IBOLSalesTerritoryHistoryMapper bolsalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalsalesTerritoryHistoryMapper)
			: base()

		{
			this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
			this.salesTerritoryHistoryModelValidator = salesTerritoryHistoryModelValidator;
			this.BOLSalesTerritoryHistoryMapper = bolsalesTerritoryHistoryMapper;
			this.DALSalesTerritoryHistoryMapper = dalsalesTerritoryHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesTerritoryHistoryRepository.All(skip, take, orderClause);

			return this.BOLSalesTerritoryHistoryMapper.MapBOToModel(this.DALSalesTerritoryHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTerritoryHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await salesTerritoryHistoryRepository.Get(businessEntityID);

			return this.BOLSalesTerritoryHistoryMapper.MapBOToModel(this.DALSalesTerritoryHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryHistoryResponseModel>> Create(
			ApiSalesTerritoryHistoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryHistoryResponseModel> response = new CreateResponse<ApiSalesTerritoryHistoryResponseModel>(await this.salesTerritoryHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesTerritoryHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.salesTerritoryHistoryRepository.Create(this.DALSalesTerritoryHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesTerritoryHistoryMapper.MapBOToModel(this.DALSalesTerritoryHistoryMapper.MapEFToBO(record)));
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
				var bo = this.BOLSalesTerritoryHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.salesTerritoryHistoryRepository.Update(this.DALSalesTerritoryHistoryMapper.MapBOToEF(bo));
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
    <Hash>952d2db38344ff6c59343d6c37f29353</Hash>
</Codenesium>*/
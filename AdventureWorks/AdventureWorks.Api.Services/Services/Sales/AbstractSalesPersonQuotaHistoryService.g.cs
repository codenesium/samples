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
	public abstract class AbstractSalesPersonQuotaHistoryService: AbstractService
	{
		private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;
		private IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator;
		private IBOLSalesPersonQuotaHistoryMapper BOLSalesPersonQuotaHistoryMapper;
		private IDALSalesPersonQuotaHistoryMapper DALSalesPersonQuotaHistoryMapper;
		private ILogger logger;

		public AbstractSalesPersonQuotaHistoryService(
			ILogger logger,
			ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository,
			IApiSalesPersonQuotaHistoryRequestModelValidator salesPersonQuotaHistoryModelValidator,
			IBOLSalesPersonQuotaHistoryMapper bolsalesPersonQuotaHistoryMapper,
			IDALSalesPersonQuotaHistoryMapper dalsalesPersonQuotaHistoryMapper)
			: base()

		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
			this.salesPersonQuotaHistoryModelValidator = salesPersonQuotaHistoryModelValidator;
			this.BOLSalesPersonQuotaHistoryMapper = bolsalesPersonQuotaHistoryMapper;
			this.DALSalesPersonQuotaHistoryMapper = dalsalesPersonQuotaHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonQuotaHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesPersonQuotaHistoryRepository.All(skip, take, orderClause);

			return this.BOLSalesPersonQuotaHistoryMapper.MapBOToModel(this.DALSalesPersonQuotaHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesPersonQuotaHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await salesPersonQuotaHistoryRepository.Get(businessEntityID);

			return this.BOLSalesPersonQuotaHistoryMapper.MapBOToModel(this.DALSalesPersonQuotaHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>> Create(
			ApiSalesPersonQuotaHistoryRequestModel model)
		{
			CreateResponse<ApiSalesPersonQuotaHistoryResponseModel> response = new CreateResponse<ApiSalesPersonQuotaHistoryResponseModel>(await this.salesPersonQuotaHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesPersonQuotaHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.salesPersonQuotaHistoryRepository.Create(this.DALSalesPersonQuotaHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesPersonQuotaHistoryMapper.MapBOToModel(this.DALSalesPersonQuotaHistoryMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesPersonQuotaHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.salesPersonQuotaHistoryRepository.Update(this.DALSalesPersonQuotaHistoryMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonQuotaHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.salesPersonQuotaHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9fd4869c097033580879fef18f210629</Hash>
</Codenesium>*/
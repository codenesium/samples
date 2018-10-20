using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesPersonService : AbstractService
	{
		protected ISalesPersonRepository SalesPersonRepository { get; private set; }

		protected IApiSalesPersonRequestModelValidator SalesPersonModelValidator { get; private set; }

		protected IBOLSalesPersonMapper BolSalesPersonMapper { get; private set; }

		protected IDALSalesPersonMapper DalSalesPersonMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		protected IBOLSalesPersonQuotaHistoryMapper BolSalesPersonQuotaHistoryMapper { get; private set; }

		protected IDALSalesPersonQuotaHistoryMapper DalSalesPersonQuotaHistoryMapper { get; private set; }

		protected IBOLSalesTerritoryHistoryMapper BolSalesTerritoryHistoryMapper { get; private set; }

		protected IDALSalesTerritoryHistoryMapper DalSalesTerritoryHistoryMapper { get; private set; }

		protected IBOLStoreMapper BolStoreMapper { get; private set; }

		protected IDALStoreMapper DalStoreMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesPersonService(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesPersonQuotaHistoryMapper bolSalesPersonQuotaHistoryMapper,
			IDALSalesPersonQuotaHistoryMapper dalSalesPersonQuotaHistoryMapper,
			IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper)
			: base()
		{
			this.SalesPersonRepository = salesPersonRepository;
			this.SalesPersonModelValidator = salesPersonModelValidator;
			this.BolSalesPersonMapper = bolSalesPersonMapper;
			this.DalSalesPersonMapper = dalSalesPersonMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.BolSalesPersonQuotaHistoryMapper = bolSalesPersonQuotaHistoryMapper;
			this.DalSalesPersonQuotaHistoryMapper = dalSalesPersonQuotaHistoryMapper;
			this.BolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
			this.DalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
			this.BolStoreMapper = bolStoreMapper;
			this.DalStoreMapper = dalStoreMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesPersonRepository.All(limit, offset);

			return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesPersonResponseModel> Get(int businessEntityID)
		{
			var record = await this.SalesPersonRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
			ApiSalesPersonRequestModel model)
		{
			CreateResponse<ApiSalesPersonResponseModel> response = new CreateResponse<ApiSalesPersonResponseModel>(await this.SalesPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesPersonMapper.MapModelToBO(default(int), model);
				var record = await this.SalesPersonRepository.Create(this.DalSalesPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesPersonResponseModel>> Update(
			int businessEntityID,
			ApiSalesPersonRequestModel model)
		{
			var validationResult = await this.SalesPersonModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesPersonMapper.MapModelToBO(businessEntityID, model);
				await this.SalesPersonRepository.Update(this.DalSalesPersonMapper.MapBOToEF(bo));

				var record = await this.SalesPersonRepository.Get(businessEntityID);

				return new UpdateResponse<ApiSalesPersonResponseModel>(this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.SalesPersonModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.SalesPersonRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesPersonRepository.SalesOrderHeadersBySalesPersonID(salesPersonID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesPersonQuotaHistoryResponseModel>> SalesPersonQuotaHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesPersonQuotaHistory> records = await this.SalesPersonRepository.SalesPersonQuotaHistoriesByBusinessEntityID(businessEntityID, limit, offset);

			return this.BolSalesPersonQuotaHistoryMapper.MapBOToModel(this.DalSalesPersonQuotaHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistoriesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesTerritoryHistory> records = await this.SalesPersonRepository.SalesTerritoryHistoriesByBusinessEntityID(businessEntityID, limit, offset);

			return this.BolSalesTerritoryHistoryMapper.MapBOToModel(this.DalSalesTerritoryHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStoreResponseModel>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			List<Store> records = await this.SalesPersonRepository.StoresBySalesPersonID(salesPersonID, limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5fafcdec341a29e520d02a622de28b61</Hash>
</Codenesium>*/
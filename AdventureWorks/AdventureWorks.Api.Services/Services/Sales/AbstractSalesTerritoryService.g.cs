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
	public abstract class AbstractSalesTerritoryService : AbstractService
	{
		protected ISalesTerritoryRepository SalesTerritoryRepository { get; private set; }

		protected IApiSalesTerritoryRequestModelValidator SalesTerritoryModelValidator { get; private set; }

		protected IBOLSalesTerritoryMapper BolSalesTerritoryMapper { get; private set; }

		protected IDALSalesTerritoryMapper DalSalesTerritoryMapper { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }
		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }
		protected IBOLSalesPersonMapper BolSalesPersonMapper { get; private set; }

		protected IDALSalesPersonMapper DalSalesPersonMapper { get; private set; }
		protected IBOLSalesTerritoryHistoryMapper BolSalesTerritoryHistoryMapper { get; private set; }

		protected IDALSalesTerritoryHistoryMapper DalSalesTerritoryHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesTerritoryService(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper bolSalesTerritoryMapper,
			IDALSalesTerritoryMapper dalSalesTerritoryMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IBOLSalesTerritoryHistoryMapper bolSalesTerritoryHistoryMapper,
			IDALSalesTerritoryHistoryMapper dalSalesTerritoryHistoryMapper)
			: base()
		{
			this.SalesTerritoryRepository = salesTerritoryRepository;
			this.SalesTerritoryModelValidator = salesTerritoryModelValidator;
			this.BolSalesTerritoryMapper = bolSalesTerritoryMapper;
			this.DalSalesTerritoryMapper = dalSalesTerritoryMapper;
			this.BolCustomerMapper = bolCustomerMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.BolSalesPersonMapper = bolSalesPersonMapper;
			this.DalSalesPersonMapper = dalSalesPersonMapper;
			this.BolSalesTerritoryHistoryMapper = bolSalesTerritoryHistoryMapper;
			this.DalSalesTerritoryHistoryMapper = dalSalesTerritoryHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesTerritoryRepository.All(limit, offset);

			return this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTerritoryResponseModel> Get(int territoryID)
		{
			var record = await this.SalesTerritoryRepository.Get(territoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryResponseModel>> Create(
			ApiSalesTerritoryRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryResponseModel> response = new CreateResponse<ApiSalesTerritoryResponseModel>(await this.SalesTerritoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesTerritoryMapper.MapModelToBO(default(int), model);
				var record = await this.SalesTerritoryRepository.Create(this.DalSalesTerritoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesTerritoryResponseModel>> Update(
			int territoryID,
			ApiSalesTerritoryRequestModel model)
		{
			var validationResult = await this.SalesTerritoryModelValidator.ValidateUpdateAsync(territoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesTerritoryMapper.MapModelToBO(territoryID, model);
				await this.SalesTerritoryRepository.Update(this.DalSalesTerritoryMapper.MapBOToEF(bo));

				var record = await this.SalesTerritoryRepository.Get(territoryID);

				return new UpdateResponse<ApiSalesTerritoryResponseModel>(this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesTerritoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int territoryID)
		{
			ActionResponse response = new ActionResponse(await this.SalesTerritoryModelValidator.ValidateDeleteAsync(territoryID));
			if (response.Success)
			{
				await this.SalesTerritoryRepository.Delete(territoryID);
			}

			return response;
		}

		public async Task<ApiSalesTerritoryResponseModel> ByName(string name)
		{
			SalesTerritory record = await this.SalesTerritoryRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiCustomerResponseModel>> Customers(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<Customer> records = await this.SalesTerritoryRepository.Customers(territoryID, limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesTerritoryRepository.SalesOrderHeaders(territoryID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesPersonResponseModel>> SalesPersons(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesPerson> records = await this.SalesTerritoryRepository.SalesPersons(territoryID, limit, offset);

			return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesTerritoryHistoryResponseModel>> SalesTerritoryHistories(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesTerritoryHistory> records = await this.SalesTerritoryRepository.SalesTerritoryHistories(territoryID, limit, offset);

			return this.BolSalesTerritoryHistoryMapper.MapBOToModel(this.DalSalesTerritoryHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6ac87629ec461e00136940619072a414</Hash>
</Codenesium>*/
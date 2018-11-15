using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesTerritoryService : AbstractService
	{
		protected ISalesTerritoryRepository SalesTerritoryRepository { get; private set; }

		protected IApiSalesTerritoryServerRequestModelValidator SalesTerritoryModelValidator { get; private set; }

		protected IBOLSalesTerritoryMapper BolSalesTerritoryMapper { get; private set; }

		protected IDALSalesTerritoryMapper DalSalesTerritoryMapper { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		protected IBOLSalesPersonMapper BolSalesPersonMapper { get; private set; }

		protected IDALSalesPersonMapper DalSalesPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesTerritoryService(
			ILogger logger,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryServerRequestModelValidator salesTerritoryModelValidator,
			IBOLSalesTerritoryMapper bolSalesTerritoryMapper,
			IDALSalesTerritoryMapper dalSalesTerritoryMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper)
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
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesTerritoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesTerritoryRepository.All(limit, offset);

			return this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesTerritoryServerResponseModel> Get(int territoryID)
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

		public virtual async Task<CreateResponse<ApiSalesTerritoryServerResponseModel>> Create(
			ApiSalesTerritoryServerRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryServerResponseModel> response = ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.CreateResponse(await this.SalesTerritoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSalesTerritoryMapper.MapModelToBO(default(int), model);
				var record = await this.SalesTerritoryRepository.Create(this.DalSalesTerritoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesTerritoryServerResponseModel>> Update(
			int territoryID,
			ApiSalesTerritoryServerRequestModel model)
		{
			var validationResult = await this.SalesTerritoryModelValidator.ValidateUpdateAsync(territoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesTerritoryMapper.MapModelToBO(territoryID, model);
				await this.SalesTerritoryRepository.Update(this.DalSalesTerritoryMapper.MapBOToEF(bo));

				var record = await this.SalesTerritoryRepository.Get(territoryID);

				return ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.UpdateResponse(this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int territoryID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SalesTerritoryModelValidator.ValidateDeleteAsync(territoryID));

			if (response.Success)
			{
				await this.SalesTerritoryRepository.Delete(territoryID);
			}

			return response;
		}

		public async virtual Task<ApiSalesTerritoryServerResponseModel> ByName(string name)
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

		public async virtual Task<ApiSalesTerritoryServerResponseModel> ByRowguid(Guid rowguid)
		{
			SalesTerritory record = await this.SalesTerritoryRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesTerritoryMapper.MapBOToModel(this.DalSalesTerritoryMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiCustomerServerResponseModel>> CustomersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<Customer> records = await this.SalesTerritoryRepository.CustomersByTerritoryID(territoryID, limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesTerritoryRepository.SalesOrderHeadersByTerritoryID(territoryID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesPersonServerResponseModel>> SalesPersonsByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesPerson> records = await this.SalesTerritoryRepository.SalesPersonsByTerritoryID(territoryID, limit, offset);

			return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a9e7aa126954bdbef13c10d02fda7c0d</Hash>
</Codenesium>*/
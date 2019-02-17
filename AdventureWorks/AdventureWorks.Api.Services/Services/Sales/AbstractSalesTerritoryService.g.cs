using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesTerritoryService : AbstractService
	{
		private IMediator mediator;

		protected ISalesTerritoryRepository SalesTerritoryRepository { get; private set; }

		protected IApiSalesTerritoryServerRequestModelValidator SalesTerritoryModelValidator { get; private set; }

		protected IDALSalesTerritoryMapper DalSalesTerritoryMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesPersonMapper DalSalesPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesTerritoryService(
			ILogger logger,
			IMediator mediator,
			ISalesTerritoryRepository salesTerritoryRepository,
			IApiSalesTerritoryServerRequestModelValidator salesTerritoryModelValidator,
			IDALSalesTerritoryMapper dalSalesTerritoryMapper,
			IDALCustomerMapper dalCustomerMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IDALSalesPersonMapper dalSalesPersonMapper)
			: base()
		{
			this.SalesTerritoryRepository = salesTerritoryRepository;
			this.SalesTerritoryModelValidator = salesTerritoryModelValidator;
			this.DalSalesTerritoryMapper = dalSalesTerritoryMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.DalSalesPersonMapper = dalSalesPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSalesTerritoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SalesTerritory> records = await this.SalesTerritoryRepository.All(limit, offset, query);

			return this.DalSalesTerritoryMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSalesTerritoryServerResponseModel> Get(int territoryID)
		{
			SalesTerritory record = await this.SalesTerritoryRepository.Get(territoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSalesTerritoryMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSalesTerritoryServerResponseModel>> Create(
			ApiSalesTerritoryServerRequestModel model)
		{
			CreateResponse<ApiSalesTerritoryServerResponseModel> response = ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.CreateResponse(await this.SalesTerritoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SalesTerritory record = this.DalSalesTerritoryMapper.MapModelToEntity(default(int), model);
				record = await this.SalesTerritoryRepository.Create(record);

				response.SetRecord(this.DalSalesTerritoryMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SalesTerritoryCreatedNotification(response.Record));
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
				SalesTerritory record = this.DalSalesTerritoryMapper.MapModelToEntity(territoryID, model);
				await this.SalesTerritoryRepository.Update(record);

				record = await this.SalesTerritoryRepository.Get(territoryID);

				ApiSalesTerritoryServerResponseModel apiModel = this.DalSalesTerritoryMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SalesTerritoryUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSalesTerritoryServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new SalesTerritoryDeletedNotification(territoryID));
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
				return this.DalSalesTerritoryMapper.MapEntityToModel(record);
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
				return this.DalSalesTerritoryMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiCustomerServerResponseModel>> CustomersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<Customer> records = await this.SalesTerritoryRepository.CustomersByTerritoryID(territoryID, limit, offset);

			return this.DalCustomerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesTerritoryRepository.SalesOrderHeadersByTerritoryID(territoryID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSalesPersonServerResponseModel>> SalesPersonsByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesPerson> records = await this.SalesTerritoryRepository.SalesPersonsByTerritoryID(territoryID, limit, offset);

			return this.DalSalesPersonMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>98133dd0f6f6d8fe50c335072172fb8b</Hash>
</Codenesium>*/
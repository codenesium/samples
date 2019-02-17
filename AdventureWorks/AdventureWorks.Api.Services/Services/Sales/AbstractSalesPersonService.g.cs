using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesPersonService : AbstractService
	{
		private IMediator mediator;

		protected ISalesPersonRepository SalesPersonRepository { get; private set; }

		protected IApiSalesPersonServerRequestModelValidator SalesPersonModelValidator { get; private set; }

		protected IDALSalesPersonMapper DalSalesPersonMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		protected IDALStoreMapper DalStoreMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesPersonService(
			ILogger logger,
			IMediator mediator,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonServerRequestModelValidator salesPersonModelValidator,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IDALStoreMapper dalStoreMapper)
			: base()
		{
			this.SalesPersonRepository = salesPersonRepository;
			this.SalesPersonModelValidator = salesPersonModelValidator;
			this.DalSalesPersonMapper = dalSalesPersonMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.DalStoreMapper = dalStoreMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSalesPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SalesPerson> records = await this.SalesPersonRepository.All(limit, offset, query);

			return this.DalSalesPersonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSalesPersonServerResponseModel> Get(int businessEntityID)
		{
			SalesPerson record = await this.SalesPersonRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSalesPersonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSalesPersonServerResponseModel>> Create(
			ApiSalesPersonServerRequestModel model)
		{
			CreateResponse<ApiSalesPersonServerResponseModel> response = ValidationResponseFactory<ApiSalesPersonServerResponseModel>.CreateResponse(await this.SalesPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SalesPerson record = this.DalSalesPersonMapper.MapModelToEntity(default(int), model);
				record = await this.SalesPersonRepository.Create(record);

				response.SetRecord(this.DalSalesPersonMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SalesPersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesPersonServerResponseModel>> Update(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model)
		{
			var validationResult = await this.SalesPersonModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				SalesPerson record = this.DalSalesPersonMapper.MapModelToEntity(businessEntityID, model);
				await this.SalesPersonRepository.Update(record);

				record = await this.SalesPersonRepository.Get(businessEntityID);

				ApiSalesPersonServerResponseModel apiModel = this.DalSalesPersonMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SalesPersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSalesPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSalesPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SalesPersonModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.SalesPersonRepository.Delete(businessEntityID);

				await this.mediator.Publish(new SalesPersonDeletedNotification(businessEntityID));
			}

			return response;
		}

		public async virtual Task<ApiSalesPersonServerResponseModel> ByRowguid(Guid rowguid)
		{
			SalesPerson record = await this.SalesPersonRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSalesPersonMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesPersonRepository.SalesOrderHeadersBySalesPersonID(salesPersonID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiStoreServerResponseModel>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			List<Store> records = await this.SalesPersonRepository.StoresBySalesPersonID(salesPersonID, limit, offset);

			return this.DalStoreMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>49b1942bbec7bd28efe6e214727778c0</Hash>
</Codenesium>*/
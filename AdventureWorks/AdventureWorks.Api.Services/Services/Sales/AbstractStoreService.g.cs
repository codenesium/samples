using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractStoreService : AbstractService
	{
		private IMediator mediator;

		protected IStoreRepository StoreRepository { get; private set; }

		protected IApiStoreServerRequestModelValidator StoreModelValidator { get; private set; }

		protected IBOLStoreMapper BolStoreMapper { get; private set; }

		protected IDALStoreMapper DalStoreMapper { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		private ILogger logger;

		public AbstractStoreService(
			ILogger logger,
			IMediator mediator,
			IStoreRepository storeRepository,
			IApiStoreServerRequestModelValidator storeModelValidator,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base()
		{
			this.StoreRepository = storeRepository;
			this.StoreModelValidator = storeModelValidator;
			this.BolStoreMapper = bolStoreMapper;
			this.DalStoreMapper = dalStoreMapper;
			this.BolCustomerMapper = bolCustomerMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStoreServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StoreRepository.All(limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStoreServerResponseModel> Get(int businessEntityID)
		{
			var record = await this.StoreRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStoreServerResponseModel>> Create(
			ApiStoreServerRequestModel model)
		{
			CreateResponse<ApiStoreServerResponseModel> response = ValidationResponseFactory<ApiStoreServerResponseModel>.CreateResponse(await this.StoreModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolStoreMapper.MapModelToBO(default(int), model);
				var record = await this.StoreRepository.Create(this.DalStoreMapper.MapBOToEF(bo));

				var businessObject = this.DalStoreMapper.MapEFToBO(record);
				response.SetRecord(this.BolStoreMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new StoreCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStoreServerResponseModel>> Update(
			int businessEntityID,
			ApiStoreServerRequestModel model)
		{
			var validationResult = await this.StoreModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStoreMapper.MapModelToBO(businessEntityID, model);
				await this.StoreRepository.Update(this.DalStoreMapper.MapBOToEF(bo));

				var record = await this.StoreRepository.Get(businessEntityID);

				var businessObject = this.DalStoreMapper.MapEFToBO(record);
				var apiModel = this.BolStoreMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new StoreUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiStoreServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiStoreServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.StoreModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.StoreRepository.Delete(businessEntityID);

				await this.mediator.Publish(new StoreDeletedNotification(businessEntityID));
			}

			return response;
		}

		public async virtual Task<ApiStoreServerResponseModel> ByRowguid(Guid rowguid)
		{
			Store record = await this.StoreRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiStoreServerResponseModel>> BySalesPersonID(int? salesPersonID, int limit = 0, int offset = int.MaxValue)
		{
			List<Store> records = await this.StoreRepository.BySalesPersonID(salesPersonID, limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStoreServerResponseModel>> ByDemographic(string demographic, int limit = 0, int offset = int.MaxValue)
		{
			List<Store> records = await this.StoreRepository.ByDemographic(demographic, limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCustomerServerResponseModel>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0)
		{
			List<Customer> records = await this.StoreRepository.CustomersByStoreID(storeID, limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0090c713c9377208fb65fe2231253ddf</Hash>
</Codenesium>*/
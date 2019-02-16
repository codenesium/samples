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

		protected IDALStoreMapper DalStoreMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		private ILogger logger;

		public AbstractStoreService(
			ILogger logger,
			IMediator mediator,
			IStoreRepository storeRepository,
			IApiStoreServerRequestModelValidator storeModelValidator,
			IDALStoreMapper dalStoreMapper,
			IDALCustomerMapper dalCustomerMapper)
			: base()
		{
			this.StoreRepository = storeRepository;
			this.StoreModelValidator = storeModelValidator;
			this.DalStoreMapper = dalStoreMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStoreServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.StoreRepository.All(limit, offset, query);

			return this.DalStoreMapper.MapBOToModel(records);
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
				return this.DalStoreMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiStoreServerResponseModel>> Create(
			ApiStoreServerRequestModel model)
		{
			CreateResponse<ApiStoreServerResponseModel> response = ValidationResponseFactory<ApiStoreServerResponseModel>.CreateResponse(await this.StoreModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalStoreMapper.MapModelToBO(default(int), model);
				var record = await this.StoreRepository.Create(bo);

				response.SetRecord(this.DalStoreMapper.MapBOToModel(record));
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
				var bo = this.DalStoreMapper.MapModelToBO(businessEntityID, model);
				await this.StoreRepository.Update(bo);

				var record = await this.StoreRepository.Get(businessEntityID);

				var apiModel = this.DalStoreMapper.MapBOToModel(record);
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
				return this.DalStoreMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiStoreServerResponseModel>> BySalesPersonID(int? salesPersonID, int limit = 0, int offset = int.MaxValue)
		{
			List<Store> records = await this.StoreRepository.BySalesPersonID(salesPersonID, limit, offset);

			return this.DalStoreMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiStoreServerResponseModel>> ByDemographic(string demographic, int limit = 0, int offset = int.MaxValue)
		{
			List<Store> records = await this.StoreRepository.ByDemographic(demographic, limit, offset);

			return this.DalStoreMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiCustomerServerResponseModel>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0)
		{
			List<Customer> records = await this.StoreRepository.CustomersByStoreID(storeID, limit, offset);

			return this.DalCustomerMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>54fadc128966457b67d68db47a17c1c5</Hash>
</Codenesium>*/
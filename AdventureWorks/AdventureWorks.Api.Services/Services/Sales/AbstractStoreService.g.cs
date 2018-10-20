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
	public abstract class AbstractStoreService : AbstractService
	{
		protected IStoreRepository StoreRepository { get; private set; }

		protected IApiStoreRequestModelValidator StoreModelValidator { get; private set; }

		protected IBOLStoreMapper BolStoreMapper { get; private set; }

		protected IDALStoreMapper DalStoreMapper { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		private ILogger logger;

		public AbstractStoreService(
			ILogger logger,
			IStoreRepository storeRepository,
			IApiStoreRequestModelValidator storeModelValidator,
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
		}

		public virtual async Task<List<ApiStoreResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StoreRepository.All(limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStoreResponseModel> Get(int businessEntityID)
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

		public virtual async Task<CreateResponse<ApiStoreResponseModel>> Create(
			ApiStoreRequestModel model)
		{
			CreateResponse<ApiStoreResponseModel> response = new CreateResponse<ApiStoreResponseModel>(await this.StoreModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolStoreMapper.MapModelToBO(default(int), model);
				var record = await this.StoreRepository.Create(this.DalStoreMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStoreResponseModel>> Update(
			int businessEntityID,
			ApiStoreRequestModel model)
		{
			var validationResult = await this.StoreModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStoreMapper.MapModelToBO(businessEntityID, model);
				await this.StoreRepository.Update(this.DalStoreMapper.MapBOToEF(bo));

				var record = await this.StoreRepository.Get(businessEntityID);

				return new UpdateResponse<ApiStoreResponseModel>(this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStoreResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.StoreModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.StoreRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiStoreResponseModel>> BySalesPersonID(int? salesPersonID, int limit = 0, int offset = int.MaxValue)
		{
			List<Store> records = await this.StoreRepository.BySalesPersonID(salesPersonID, limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}

		public async Task<List<ApiStoreResponseModel>> ByDemographic(string demographic, int limit = 0, int offset = int.MaxValue)
		{
			List<Store> records = await this.StoreRepository.ByDemographic(demographic, limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCustomerResponseModel>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0)
		{
			List<Customer> records = await this.StoreRepository.CustomersByStoreID(storeID, limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5a0c7bf5864b278283decf697c3deea9</Hash>
</Codenesium>*/
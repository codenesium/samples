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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOStore: AbstractBOManager
	{
		private IStoreRepository storeRepository;
		private IApiStoreRequestModelValidator storeModelValidator;
		private IBOLStoreMapper storeMapper;
		private ILogger logger;

		public AbstractBOStore(
			ILogger logger,
			IStoreRepository storeRepository,
			IApiStoreRequestModelValidator storeModelValidator,
			IBOLStoreMapper storeMapper)
			: base()

		{
			this.storeRepository = storeRepository;
			this.storeModelValidator = storeModelValidator;
			this.storeMapper = storeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStoreResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.storeRepository.All(skip, take, orderClause);

			return this.storeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiStoreResponseModel> Get(int businessEntityID)
		{
			var record = await storeRepository.Get(businessEntityID);

			return this.storeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiStoreResponseModel>> Create(
			ApiStoreRequestModel model)
		{
			CreateResponse<ApiStoreResponseModel> response = new CreateResponse<ApiStoreResponseModel>(await this.storeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.storeMapper.MapModelToDTO(default (int), model);
				var record = await this.storeRepository.Create(dto);

				response.SetRecord(this.storeMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiStoreRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.storeMapper.MapModelToDTO(businessEntityID, model);
				await this.storeRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.storeRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiStoreResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<DTOStore> records = await this.storeRepository.GetSalesPersonID(salesPersonID);

			return this.storeMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiStoreResponseModel>> GetDemographics(string demographics)
		{
			List<DTOStore> records = await this.storeRepository.GetDemographics(demographics);

			return this.storeMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>04eda9c5849ab585e8965535da78e9ea</Hash>
</Codenesium>*/
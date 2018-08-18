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
	public abstract class AbstractProductListPriceHistoryService : AbstractService
	{
		protected IProductListPriceHistoryRepository ProductListPriceHistoryRepository { get; private set; }

		protected IApiProductListPriceHistoryRequestModelValidator ProductListPriceHistoryModelValidator { get; private set; }

		protected IBOLProductListPriceHistoryMapper BolProductListPriceHistoryMapper { get; private set; }

		protected IDALProductListPriceHistoryMapper DalProductListPriceHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductListPriceHistoryService(
			ILogger logger,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
			IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper,
			IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper)
			: base()
		{
			this.ProductListPriceHistoryRepository = productListPriceHistoryRepository;
			this.ProductListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
			this.BolProductListPriceHistoryMapper = bolProductListPriceHistoryMapper;
			this.DalProductListPriceHistoryMapper = dalProductListPriceHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductListPriceHistoryRepository.All(limit, offset);

			return this.BolProductListPriceHistoryMapper.MapBOToModel(this.DalProductListPriceHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductListPriceHistoryResponseModel> Get(int productID)
		{
			var record = await this.ProductListPriceHistoryRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductListPriceHistoryMapper.MapBOToModel(this.DalProductListPriceHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
			ApiProductListPriceHistoryRequestModel model)
		{
			CreateResponse<ApiProductListPriceHistoryResponseModel> response = new CreateResponse<ApiProductListPriceHistoryResponseModel>(await this.ProductListPriceHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductListPriceHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductListPriceHistoryRepository.Create(this.DalProductListPriceHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductListPriceHistoryMapper.MapBOToModel(this.DalProductListPriceHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductListPriceHistoryResponseModel>> Update(
			int productID,
			ApiProductListPriceHistoryRequestModel model)
		{
			var validationResult = await this.ProductListPriceHistoryModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductListPriceHistoryMapper.MapModelToBO(productID, model);
				await this.ProductListPriceHistoryRepository.Update(this.DalProductListPriceHistoryMapper.MapBOToEF(bo));

				var record = await this.ProductListPriceHistoryRepository.Get(productID);

				return new UpdateResponse<ApiProductListPriceHistoryResponseModel>(this.BolProductListPriceHistoryMapper.MapBOToModel(this.DalProductListPriceHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductListPriceHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.ProductListPriceHistoryModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.ProductListPriceHistoryRepository.Delete(productID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b8aec708b4db3f7eaa6368abf14e9c14</Hash>
</Codenesium>*/
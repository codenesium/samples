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
	public abstract class AbstractProductInventoryService : AbstractService
	{
		protected IProductInventoryRepository ProductInventoryRepository { get; private set; }

		protected IApiProductInventoryRequestModelValidator ProductInventoryModelValidator { get; private set; }

		protected IBOLProductInventoryMapper BolProductInventoryMapper { get; private set; }

		protected IDALProductInventoryMapper DalProductInventoryMapper { get; private set; }

		private ILogger logger;

		public AbstractProductInventoryService(
			ILogger logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryRequestModelValidator productInventoryModelValidator,
			IBOLProductInventoryMapper bolProductInventoryMapper,
			IDALProductInventoryMapper dalProductInventoryMapper)
			: base()
		{
			this.ProductInventoryRepository = productInventoryRepository;
			this.ProductInventoryModelValidator = productInventoryModelValidator;
			this.BolProductInventoryMapper = bolProductInventoryMapper;
			this.DalProductInventoryMapper = dalProductInventoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductInventoryRepository.All(limit, offset);

			return this.BolProductInventoryMapper.MapBOToModel(this.DalProductInventoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductInventoryResponseModel> Get(int productID)
		{
			var record = await this.ProductInventoryRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductInventoryMapper.MapBOToModel(this.DalProductInventoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
			ApiProductInventoryRequestModel model)
		{
			CreateResponse<ApiProductInventoryResponseModel> response = new CreateResponse<ApiProductInventoryResponseModel>(await this.ProductInventoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductInventoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductInventoryRepository.Create(this.DalProductInventoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductInventoryMapper.MapBOToModel(this.DalProductInventoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductInventoryResponseModel>> Update(
			int productID,
			ApiProductInventoryRequestModel model)
		{
			var validationResult = await this.ProductInventoryModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductInventoryMapper.MapModelToBO(productID, model);
				await this.ProductInventoryRepository.Update(this.DalProductInventoryMapper.MapBOToEF(bo));

				var record = await this.ProductInventoryRepository.Get(productID);

				return new UpdateResponse<ApiProductInventoryResponseModel>(this.BolProductInventoryMapper.MapBOToModel(this.DalProductInventoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductInventoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.ProductInventoryModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.ProductInventoryRepository.Delete(productID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>87058b8b4d6e2dd20ad0520f50bc18b3</Hash>
</Codenesium>*/
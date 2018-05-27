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
	public abstract class AbstractBOProductInventory: AbstractBOManager
	{
		private IProductInventoryRepository productInventoryRepository;
		private IApiProductInventoryRequestModelValidator productInventoryModelValidator;
		private IBOLProductInventoryMapper productInventoryMapper;
		private ILogger logger;

		public AbstractBOProductInventory(
			ILogger logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryRequestModelValidator productInventoryModelValidator,
			IBOLProductInventoryMapper productInventoryMapper)
			: base()

		{
			this.productInventoryRepository = productInventoryRepository;
			this.productInventoryModelValidator = productInventoryModelValidator;
			this.productInventoryMapper = productInventoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductInventoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productInventoryRepository.All(skip, take, orderClause);

			return this.productInventoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductInventoryResponseModel> Get(int productID)
		{
			var record = await productInventoryRepository.Get(productID);

			return this.productInventoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
			ApiProductInventoryRequestModel model)
		{
			CreateResponse<ApiProductInventoryResponseModel> response = new CreateResponse<ApiProductInventoryResponseModel>(await this.productInventoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productInventoryMapper.MapModelToDTO(default (int), model);
				var record = await this.productInventoryRepository.Create(dto);

				response.SetRecord(this.productInventoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductInventoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				var dto = this.productInventoryMapper.MapModelToDTO(productID, model);
				await this.productInventoryRepository.Update(productID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productInventoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a24ccd020dbcef75914196ce0633cd99</Hash>
</Codenesium>*/
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
	public abstract class AbstractBOShoppingCartItem: AbstractBOManager
	{
		private IShoppingCartItemRepository shoppingCartItemRepository;
		private IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator;
		private IBOLShoppingCartItemMapper shoppingCartItemMapper;
		private ILogger logger;

		public AbstractBOShoppingCartItem(
			ILogger logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper shoppingCartItemMapper)
			: base()

		{
			this.shoppingCartItemRepository = shoppingCartItemRepository;
			this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.shoppingCartItemMapper = shoppingCartItemMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.shoppingCartItemRepository.All(skip, take, orderClause);

			return this.shoppingCartItemMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID)
		{
			var record = await shoppingCartItemRepository.Get(shoppingCartItemID);

			return this.shoppingCartItemMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemResponseModel> response = new CreateResponse<ApiShoppingCartItemResponseModel>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.shoppingCartItemMapper.MapModelToDTO(default (int), model);
				var record = await this.shoppingCartItemRepository.Create(dto);

				response.SetRecord(this.shoppingCartItemMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateUpdateAsync(shoppingCartItemID, model));

			if (response.Success)
			{
				var dto = this.shoppingCartItemMapper.MapModelToDTO(shoppingCartItemID, model);
				await this.shoppingCartItemRepository.Update(shoppingCartItemID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shoppingCartItemID)
		{
			ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateDeleteAsync(shoppingCartItemID));

			if (response.Success)
			{
				await this.shoppingCartItemRepository.Delete(shoppingCartItemID);
			}
			return response;
		}

		public async Task<List<ApiShoppingCartItemResponseModel>> GetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			List<DTOShoppingCartItem> records = await this.shoppingCartItemRepository.GetShoppingCartIDProductID(shoppingCartID,productID);

			return this.shoppingCartItemMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>da0c53f76e1a4098b6021a76261bd1fd</Hash>
</Codenesium>*/
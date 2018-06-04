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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShoppingCartItemService: AbstractService
	{
		private IShoppingCartItemRepository shoppingCartItemRepository;
		private IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator;
		private IBOLShoppingCartItemMapper BOLShoppingCartItemMapper;
		private IDALShoppingCartItemMapper DALShoppingCartItemMapper;
		private ILogger logger;

		public AbstractShoppingCartItemService(
			ILogger logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper bolshoppingCartItemMapper,
			IDALShoppingCartItemMapper dalshoppingCartItemMapper)
			: base()

		{
			this.shoppingCartItemRepository = shoppingCartItemRepository;
			this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.BOLShoppingCartItemMapper = bolshoppingCartItemMapper;
			this.DALShoppingCartItemMapper = dalshoppingCartItemMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.shoppingCartItemRepository.All(skip, take, orderClause);

			return this.BOLShoppingCartItemMapper.MapBOToModel(this.DALShoppingCartItemMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID)
		{
			var record = await shoppingCartItemRepository.Get(shoppingCartItemID);

			return this.BOLShoppingCartItemMapper.MapBOToModel(this.DALShoppingCartItemMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemResponseModel> response = new CreateResponse<ApiShoppingCartItemResponseModel>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLShoppingCartItemMapper.MapModelToBO(default (int), model);
				var record = await this.shoppingCartItemRepository.Create(this.DALShoppingCartItemMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLShoppingCartItemMapper.MapBOToModel(this.DALShoppingCartItemMapper.MapEFToBO(record)));
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
				var bo = this.BOLShoppingCartItemMapper.MapModelToBO(shoppingCartItemID, model);
				await this.shoppingCartItemRepository.Update(this.DALShoppingCartItemMapper.MapBOToEF(bo));
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
			List<ShoppingCartItem> records = await this.shoppingCartItemRepository.GetShoppingCartIDProductID(shoppingCartID,productID);

			return this.BOLShoppingCartItemMapper.MapBOToModel(this.DALShoppingCartItemMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b095842becd8a6f5d0fc90709a0c317d</Hash>
</Codenesium>*/
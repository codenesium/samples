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
		private IBOLShoppingCartItemMapper bolShoppingCartItemMapper;
		private IDALShoppingCartItemMapper dalShoppingCartItemMapper;
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
			this.bolShoppingCartItemMapper = bolshoppingCartItemMapper;
			this.dalShoppingCartItemMapper = dalshoppingCartItemMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.shoppingCartItemRepository.All(skip, take, orderClause);

			return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID)
		{
			var record = await shoppingCartItemRepository.Get(shoppingCartItemID);

			return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemResponseModel> response = new CreateResponse<ApiShoppingCartItemResponseModel>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolShoppingCartItemMapper.MapModelToBO(default (int), model);
				var record = await this.shoppingCartItemRepository.Create(this.dalShoppingCartItemMapper.MapBOToEF(bo));

				response.SetRecord(this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(record)));
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
				var bo = this.bolShoppingCartItemMapper.MapModelToBO(shoppingCartItemID, model);
				await this.shoppingCartItemRepository.Update(this.dalShoppingCartItemMapper.MapBOToEF(bo));
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

			return this.bolShoppingCartItemMapper.MapBOToModel(this.dalShoppingCartItemMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b3a104fc272a88655bec1e8a607614d7</Hash>
</Codenesium>*/
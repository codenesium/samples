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
	public abstract class AbstractShoppingCartItemService : AbstractService
	{
		protected IShoppingCartItemRepository ShoppingCartItemRepository { get; private set; }

		protected IApiShoppingCartItemRequestModelValidator ShoppingCartItemModelValidator { get; private set; }

		protected IBOLShoppingCartItemMapper BolShoppingCartItemMapper { get; private set; }

		protected IDALShoppingCartItemMapper DalShoppingCartItemMapper { get; private set; }

		private ILogger logger;

		public AbstractShoppingCartItemService(
			ILogger logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper bolShoppingCartItemMapper,
			IDALShoppingCartItemMapper dalShoppingCartItemMapper)
			: base()
		{
			this.ShoppingCartItemRepository = shoppingCartItemRepository;
			this.ShoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.BolShoppingCartItemMapper = bolShoppingCartItemMapper;
			this.DalShoppingCartItemMapper = dalShoppingCartItemMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShoppingCartItemResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ShoppingCartItemRepository.All(limit, offset);

			return this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShoppingCartItemResponseModel> Get(int shoppingCartItemID)
		{
			var record = await this.ShoppingCartItemRepository.Get(shoppingCartItemID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShoppingCartItemResponseModel>> Create(
			ApiShoppingCartItemRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemResponseModel> response = new CreateResponse<ApiShoppingCartItemResponseModel>(await this.ShoppingCartItemModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolShoppingCartItemMapper.MapModelToBO(default(int), model);
				var record = await this.ShoppingCartItemRepository.Create(this.DalShoppingCartItemMapper.MapBOToEF(bo));

				response.SetRecord(this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShoppingCartItemResponseModel>> Update(
			int shoppingCartItemID,
			ApiShoppingCartItemRequestModel model)
		{
			var validationResult = await this.ShoppingCartItemModelValidator.ValidateUpdateAsync(shoppingCartItemID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolShoppingCartItemMapper.MapModelToBO(shoppingCartItemID, model);
				await this.ShoppingCartItemRepository.Update(this.DalShoppingCartItemMapper.MapBOToEF(bo));

				var record = await this.ShoppingCartItemRepository.Get(shoppingCartItemID);

				return new UpdateResponse<ApiShoppingCartItemResponseModel>(this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiShoppingCartItemResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shoppingCartItemID)
		{
			ActionResponse response = new ActionResponse(await this.ShoppingCartItemModelValidator.ValidateDeleteAsync(shoppingCartItemID));
			if (response.Success)
			{
				await this.ShoppingCartItemRepository.Delete(shoppingCartItemID);
			}

			return response;
		}

		public async Task<List<ApiShoppingCartItemResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID)
		{
			List<ShoppingCartItem> records = await this.ShoppingCartItemRepository.ByShoppingCartIDProductID(shoppingCartID, productID);

			return this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a075e3eb196b8c74a7fc95dc94b00504</Hash>
</Codenesium>*/
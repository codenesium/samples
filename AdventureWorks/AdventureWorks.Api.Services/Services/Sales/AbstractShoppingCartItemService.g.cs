using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShoppingCartItemService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IShoppingCartItemRepository ShoppingCartItemRepository { get; private set; }

		protected IApiShoppingCartItemServerRequestModelValidator ShoppingCartItemModelValidator { get; private set; }

		protected IDALShoppingCartItemMapper DalShoppingCartItemMapper { get; private set; }

		private ILogger logger;

		public AbstractShoppingCartItemService(
			ILogger logger,
			MediatR.IMediator mediator,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemServerRequestModelValidator shoppingCartItemModelValidator,
			IDALShoppingCartItemMapper dalShoppingCartItemMapper)
			: base()
		{
			this.ShoppingCartItemRepository = shoppingCartItemRepository;
			this.ShoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.DalShoppingCartItemMapper = dalShoppingCartItemMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiShoppingCartItemServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ShoppingCartItem> records = await this.ShoppingCartItemRepository.All(limit, offset, query);

			return this.DalShoppingCartItemMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiShoppingCartItemServerResponseModel> Get(int shoppingCartItemID)
		{
			ShoppingCartItem record = await this.ShoppingCartItemRepository.Get(shoppingCartItemID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShoppingCartItemMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiShoppingCartItemServerResponseModel>> Create(
			ApiShoppingCartItemServerRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemServerResponseModel> response = ValidationResponseFactory<ApiShoppingCartItemServerResponseModel>.CreateResponse(await this.ShoppingCartItemModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ShoppingCartItem record = this.DalShoppingCartItemMapper.MapModelToEntity(default(int), model);
				record = await this.ShoppingCartItemRepository.Create(record);

				response.SetRecord(this.DalShoppingCartItemMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ShoppingCartItemCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShoppingCartItemServerResponseModel>> Update(
			int shoppingCartItemID,
			ApiShoppingCartItemServerRequestModel model)
		{
			var validationResult = await this.ShoppingCartItemModelValidator.ValidateUpdateAsync(shoppingCartItemID, model);

			if (validationResult.IsValid)
			{
				ShoppingCartItem record = this.DalShoppingCartItemMapper.MapModelToEntity(shoppingCartItemID, model);
				await this.ShoppingCartItemRepository.Update(record);

				record = await this.ShoppingCartItemRepository.Get(shoppingCartItemID);

				ApiShoppingCartItemServerResponseModel apiModel = this.DalShoppingCartItemMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ShoppingCartItemUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiShoppingCartItemServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiShoppingCartItemServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shoppingCartItemID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ShoppingCartItemModelValidator.ValidateDeleteAsync(shoppingCartItemID));

			if (response.Success)
			{
				await this.ShoppingCartItemRepository.Delete(shoppingCartItemID);

				await this.mediator.Publish(new ShoppingCartItemDeletedNotification(shoppingCartItemID));
			}

			return response;
		}

		public async virtual Task<List<ApiShoppingCartItemServerResponseModel>> ByShoppingCartIDProductID(string shoppingCartID, int productID, int limit = 0, int offset = int.MaxValue)
		{
			List<ShoppingCartItem> records = await this.ShoppingCartItemRepository.ByShoppingCartIDProductID(shoppingCartID, productID, limit, offset);

			return this.DalShoppingCartItemMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>d14177391cf53a8aba0eacca3a95cbbe</Hash>
</Codenesium>*/
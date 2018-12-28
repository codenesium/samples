using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShoppingCartItemService : AbstractService
	{
		private IMediator mediator;

		protected IShoppingCartItemRepository ShoppingCartItemRepository { get; private set; }

		protected IApiShoppingCartItemServerRequestModelValidator ShoppingCartItemModelValidator { get; private set; }

		protected IBOLShoppingCartItemMapper BolShoppingCartItemMapper { get; private set; }

		protected IDALShoppingCartItemMapper DalShoppingCartItemMapper { get; private set; }

		private ILogger logger;

		public AbstractShoppingCartItemService(
			ILogger logger,
			IMediator mediator,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemServerRequestModelValidator shoppingCartItemModelValidator,
			IBOLShoppingCartItemMapper bolShoppingCartItemMapper,
			IDALShoppingCartItemMapper dalShoppingCartItemMapper)
			: base()
		{
			this.ShoppingCartItemRepository = shoppingCartItemRepository;
			this.ShoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.BolShoppingCartItemMapper = bolShoppingCartItemMapper;
			this.DalShoppingCartItemMapper = dalShoppingCartItemMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiShoppingCartItemServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ShoppingCartItemRepository.All(limit, offset);

			return this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShoppingCartItemServerResponseModel> Get(int shoppingCartItemID)
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

		public virtual async Task<CreateResponse<ApiShoppingCartItemServerResponseModel>> Create(
			ApiShoppingCartItemServerRequestModel model)
		{
			CreateResponse<ApiShoppingCartItemServerResponseModel> response = ValidationResponseFactory<ApiShoppingCartItemServerResponseModel>.CreateResponse(await this.ShoppingCartItemModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolShoppingCartItemMapper.MapModelToBO(default(int), model);
				var record = await this.ShoppingCartItemRepository.Create(this.DalShoppingCartItemMapper.MapBOToEF(bo));

				var businessObject = this.DalShoppingCartItemMapper.MapEFToBO(record);
				response.SetRecord(this.BolShoppingCartItemMapper.MapBOToModel(businessObject));
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
				var bo = this.BolShoppingCartItemMapper.MapModelToBO(shoppingCartItemID, model);
				await this.ShoppingCartItemRepository.Update(this.DalShoppingCartItemMapper.MapBOToEF(bo));

				var record = await this.ShoppingCartItemRepository.Get(shoppingCartItemID);

				var businessObject = this.DalShoppingCartItemMapper.MapEFToBO(record);
				var apiModel = this.BolShoppingCartItemMapper.MapBOToModel(businessObject);
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

			return this.BolShoppingCartItemMapper.MapBOToModel(this.DalShoppingCartItemMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1926123953fdc10f7baf289bf92ad0e4</Hash>
</Codenesium>*/
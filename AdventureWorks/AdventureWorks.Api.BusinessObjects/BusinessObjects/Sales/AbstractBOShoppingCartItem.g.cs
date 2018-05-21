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
		private IApiShoppingCartItemModelValidator shoppingCartItemModelValidator;
		private ILogger logger;

		public AbstractBOShoppingCartItem(
			ILogger logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IApiShoppingCartItemModelValidator shoppingCartItemModelValidator)
			: base()

		{
			this.shoppingCartItemRepository = shoppingCartItemRepository;
			this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shoppingCartItemRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOShoppingCartItem> Get(int shoppingCartItemID)
		{
			return this.shoppingCartItemRepository.Get(shoppingCartItemID);
		}

		public virtual async Task<CreateResponse<POCOShoppingCartItem>> Create(
			ApiShoppingCartItemModel model)
		{
			CreateResponse<POCOShoppingCartItem> response = new CreateResponse<POCOShoppingCartItem>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOShoppingCartItem record = await this.shoppingCartItemRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shoppingCartItemID,
			ApiShoppingCartItemModel model)
		{
			ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateUpdateAsync(shoppingCartItemID, model));

			if (response.Success)
			{
				await this.shoppingCartItemRepository.Update(shoppingCartItemID, model);
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

		public async Task<List<POCOShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			return await this.shoppingCartItemRepository.GetShoppingCartIDProductID(shoppingCartID,productID);
		}
	}
}

/*<Codenesium>
    <Hash>b82ae59e69eff757e8e7ff853494435d</Hash>
</Codenesium>*/
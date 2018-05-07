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
	public abstract class AbstractBOShoppingCartItem
	{
		private IShoppingCartItemRepository shoppingCartItemRepository;
		private IShoppingCartItemModelValidator shoppingCartItemModelValidator;
		private ILogger logger;

		public AbstractBOShoppingCartItem(
			ILogger logger,
			IShoppingCartItemRepository shoppingCartItemRepository,
			IShoppingCartItemModelValidator shoppingCartItemModelValidator)

		{
			this.shoppingCartItemRepository = shoppingCartItemRepository;
			this.shoppingCartItemModelValidator = shoppingCartItemModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ShoppingCartItemModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.shoppingCartItemModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.shoppingCartItemRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shoppingCartItemID,
			ShoppingCartItemModel model)
		{
			ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateUpdateAsync(shoppingCartItemID, model));

			if (response.Success)
			{
				this.shoppingCartItemRepository.Update(shoppingCartItemID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shoppingCartItemID)
		{
			ActionResponse response = new ActionResponse(await this.shoppingCartItemModelValidator.ValidateDeleteAsync(shoppingCartItemID));

			if (response.Success)
			{
				this.shoppingCartItemRepository.Delete(shoppingCartItemID);
			}
			return response;
		}

		public virtual POCOShoppingCartItem Get(int shoppingCartItemID)
		{
			return this.shoppingCartItemRepository.Get(shoppingCartItemID);
		}

		public virtual List<POCOShoppingCartItem> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shoppingCartItemRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>bcd94d74c52b831d95b8a26b5349e8d1</Hash>
</Codenesium>*/
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

		public virtual ApiResponse GetById(int shoppingCartItemID)
		{
			return this.shoppingCartItemRepository.GetById(shoppingCartItemID);
		}

		public virtual POCOShoppingCartItem GetByIdDirect(int shoppingCartItemID)
		{
			return this.shoppingCartItemRepository.GetByIdDirect(shoppingCartItemID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shoppingCartItemRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shoppingCartItemRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOShoppingCartItem> GetWhereDirect(Expression<Func<EFShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shoppingCartItemRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>1a59e4556f68566892ba38230f95df5d</Hash>
</Codenesium>*/
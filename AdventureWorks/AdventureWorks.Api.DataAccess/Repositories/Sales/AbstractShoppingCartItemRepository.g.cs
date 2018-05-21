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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShoppingCartItemRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractShoppingCartItemRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOShoppingCartItem> Get(int shoppingCartItemID)
		{
			ShoppingCartItem record = await this.GetById(shoppingCartItemID);

			return this.Mapper.ShoppingCartItemMapEFToPOCO(record);
		}

		public async virtual Task<POCOShoppingCartItem> Create(
			ApiShoppingCartItemModel model)
		{
			ShoppingCartItem record = new ShoppingCartItem();

			this.Mapper.ShoppingCartItemMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ShoppingCartItem>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ShoppingCartItemMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int shoppingCartItemID,
			ApiShoppingCartItemModel model)
		{
			ShoppingCartItem record = await this.GetById(shoppingCartItemID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shoppingCartItemID}");
			}
			else
			{
				this.Mapper.ShoppingCartItemMapModelToEF(
					shoppingCartItemID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int shoppingCartItemID)
		{
			ShoppingCartItem record = await this.GetById(shoppingCartItemID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ShoppingCartItem>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ShoppingCartID == shoppingCartID && x.ProductID == productID);

			return records;
		}

		protected async Task<List<POCOShoppingCartItem>> Where(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShoppingCartItem> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOShoppingCartItem>> SearchLinqPOCO(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShoppingCartItem> response = new List<POCOShoppingCartItem>();
			List<ShoppingCartItem> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ShoppingCartItemMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ShoppingCartItem>> SearchLinqEF(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShoppingCartItem.ShoppingCartItemID)} ASC";
			}
			return await this.Context.Set<ShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ShoppingCartItem>();
		}

		private async Task<List<ShoppingCartItem>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShoppingCartItem.ShoppingCartItemID)} ASC";
			}

			return await this.Context.Set<ShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ShoppingCartItem>();
		}

		private async Task<ShoppingCartItem> GetById(int shoppingCartItemID)
		{
			List<ShoppingCartItem> records = await this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8706ff1ffc16b778a3ade7cb3aee0705</Hash>
</Codenesium>*/
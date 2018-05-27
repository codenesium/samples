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
		protected IDALShoppingCartItemMapper Mapper { get; }

		public AbstractShoppingCartItemRepository(
			IDALShoppingCartItemMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOShoppingCartItem>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOShoppingCartItem> Get(int shoppingCartItemID)
		{
			ShoppingCartItem record = await this.GetById(shoppingCartItemID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOShoppingCartItem> Create(
			DTOShoppingCartItem dto)
		{
			ShoppingCartItem record = new ShoppingCartItem();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ShoppingCartItem>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int shoppingCartItemID,
			DTOShoppingCartItem dto)
		{
			ShoppingCartItem record = await this.GetById(shoppingCartItemID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shoppingCartItemID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					shoppingCartItemID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<List<DTOShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID,int productID)
		{
			var records = await this.SearchLinqDTO(x => x.ShoppingCartID == shoppingCartID && x.ProductID == productID);

			return records;
		}

		protected async Task<List<DTOShoppingCartItem>> Where(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOShoppingCartItem> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOShoppingCartItem>> SearchLinqDTO(Expression<Func<ShoppingCartItem, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOShoppingCartItem> response = new List<DTOShoppingCartItem>();
			List<ShoppingCartItem> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>84a12e0aed4b56ecb413117e547c2eb8</Hash>
</Codenesium>*/
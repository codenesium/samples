using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractShoppingCartItemRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractShoppingCartItemRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ShoppingCartItem>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ShoppingCartItem> Get(int shoppingCartItemID)
                {
                        return await this.GetById(shoppingCartItemID);
                }

                public async virtual Task<ShoppingCartItem> Create(ShoppingCartItem item)
                {
                        this.Context.Set<ShoppingCartItem>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ShoppingCartItem item)
                {
                        var entity = this.Context.Set<ShoppingCartItem>().Local.FirstOrDefault(x => x.ShoppingCartItemID == item.ShoppingCartItemID);
                        if (entity == null)
                        {
                                this.Context.Set<ShoppingCartItem>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
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

                public async Task<List<ShoppingCartItem>> GetShoppingCartIDProductID(string shoppingCartID, int productID)
                {
                        var records = await this.SearchLinqEF(x => x.ShoppingCartID == shoppingCartID && x.ProductID == productID);

                        return records;
                }

                protected async Task<List<ShoppingCartItem>> Where(Expression<Func<ShoppingCartItem, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ShoppingCartItem> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ShoppingCartItem>> SearchLinqEF(Expression<Func<ShoppingCartItem, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ShoppingCartItem.ShoppingCartItemID)} ASC";
                        }

                        return await this.Context.Set<ShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ShoppingCartItem>();
                }

                private async Task<List<ShoppingCartItem>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ShoppingCartItem.ShoppingCartItemID)} ASC";
                        }

                        return await this.Context.Set<ShoppingCartItem>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ShoppingCartItem>();
                }

                private async Task<ShoppingCartItem> GetById(int shoppingCartItemID)
                {
                        List<ShoppingCartItem> records = await this.SearchLinqEF(x => x.ShoppingCartItemID == shoppingCartItemID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4692b8499ce42ba085b6b6751b099b44</Hash>
</Codenesium>*/
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
        public abstract class AbstractProductReviewRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductReviewRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductReview>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<ProductReview> Get(int productReviewID)
                {
                        return await this.GetById(productReviewID);
                }

                public async virtual Task<ProductReview> Create(ProductReview item)
                {
                        this.Context.Set<ProductReview>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductReview item)
                {
                        var entity = this.Context.Set<ProductReview>().Local.FirstOrDefault(x => x.ProductReviewID == item.ProductReviewID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductReview>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int productReviewID)
                {
                        ProductReview record = await this.GetById(productReviewID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductReview>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<ProductReview>> GetCommentsProductIDReviewerName(string comments, int productID, string reviewerName)
                {
                        var records = await this.SearchLinqEF(x => x.Comments == comments && x.ProductID == productID && x.ReviewerName == reviewerName);

                        return records;
                }

                protected async Task<List<ProductReview>> Where(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ProductReview> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ProductReview>> SearchLinqEF(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductReview.ProductReviewID)} ASC";
                        }

                        return await this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductReview>();
                }

                private async Task<List<ProductReview>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductReview.ProductReviewID)} ASC";
                        }

                        return await this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductReview>();
                }

                private async Task<ProductReview> GetById(int productReviewID)
                {
                        List<ProductReview> records = await this.SearchLinqEF(x => x.ProductReviewID == productReviewID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>67b53bb0298a3d88e5a7c2bc6f27ce60</Hash>
</Codenesium>*/
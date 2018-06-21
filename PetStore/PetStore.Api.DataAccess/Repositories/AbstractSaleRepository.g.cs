using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
{
        public abstract class AbstractSaleRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSaleRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Sale> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Sale> Create(Sale item)
                {
                        this.Context.Set<Sale>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Sale item)
                {
                        var entity = this.Context.Set<Sale>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Sale>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        Sale record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Sale>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<PaymentType> GetPaymentType(int paymentTypeId)
                {
                        return await this.Context.Set<PaymentType>().SingleOrDefaultAsync(x => x.Id == paymentTypeId);
                }

                public async virtual Task<Pet> GetPet(int petId)
                {
                        return await this.Context.Set<Pet>().SingleOrDefaultAsync(x => x.Id == petId);
                }

                protected async Task<List<Sale>> Where(
                        Expression<Func<Sale, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Sale, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
                        }
                        else
                        {
                                return await this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
                        }
                }

                private async Task<Sale> GetById(int id)
                {
                        List<Sale> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>6a993c1e7b5b2bf6c3cfc9e385406bf2</Hash>
</Codenesium>*/
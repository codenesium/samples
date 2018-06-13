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
        public abstract class AbstractAddressTypeRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractAddressTypeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<AddressType>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<AddressType> Get(int addressTypeID)
                {
                        return await this.GetById(addressTypeID);
                }

                public async virtual Task<AddressType> Create(AddressType item)
                {
                        this.Context.Set<AddressType>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(AddressType item)
                {
                        var entity = this.Context.Set<AddressType>().Local.FirstOrDefault(x => x.AddressTypeID == item.AddressTypeID);
                        if (entity == null)
                        {
                                this.Context.Set<AddressType>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int addressTypeID)
                {
                        AddressType record = await this.GetById(addressTypeID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<AddressType>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<AddressType> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<AddressType>> Where(Expression<Func<AddressType, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<AddressType> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<AddressType>> SearchLinqEF(Expression<Func<AddressType, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(AddressType.AddressTypeID)} ASC";
                        }

                        return await this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<AddressType>();
                }

                private async Task<List<AddressType>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(AddressType.AddressTypeID)} ASC";
                        }

                        return await this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<AddressType>();
                }

                private async Task<AddressType> GetById(int addressTypeID)
                {
                        List<AddressType> records = await this.SearchLinqEF(x => x.AddressTypeID == addressTypeID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int addressTypeID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<BusinessEntityAddress>().Where(x => x.AddressTypeID == addressTypeID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BusinessEntityAddress>();
                }
        }
}

/*<Codenesium>
    <Hash>288989058d25927c2ee860f10ab7f3ba</Hash>
</Codenesium>*/
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
        public abstract class AbstractAddressRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractAddressRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Address>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Address> Get(int addressID)
                {
                        return await this.GetById(addressID);
                }

                public async virtual Task<Address> Create(Address item)
                {
                        this.Context.Set<Address>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Address item)
                {
                        var entity = this.Context.Set<Address>().Local.FirstOrDefault(x => x.AddressID == item.AddressID);
                        if (entity == null)
                        {
                                this.Context.Set<Address>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int addressID)
                {
                        Address record = await this.GetById(addressID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Address>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Address> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
                {
                        var records = await this.SearchLinqEF(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.City == city && x.StateProvinceID == stateProvinceID && x.PostalCode == postalCode);

                        return records.FirstOrDefault();
                }
                public async Task<List<Address>> GetStateProvinceID(int stateProvinceID)
                {
                        var records = await this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID);

                        return records;
                }

                protected async Task<List<Address>> Where(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Address> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Address>> SearchLinqEF(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Address.AddressID)} ASC";
                        }

                        return await this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Address>();
                }

                private async Task<List<Address>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Address.AddressID)} ASC";
                        }

                        return await this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Address>();
                }

                private async Task<Address> GetById(int addressID)
                {
                        List<Address> records = await this.SearchLinqEF(x => x.AddressID == addressID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>4070292203bf47c8615c9180c84d26dd</Hash>
</Codenesium>*/
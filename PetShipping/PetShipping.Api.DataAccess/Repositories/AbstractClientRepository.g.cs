using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public abstract class AbstractClientRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractClientRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Client>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Client> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Client> Create(Client item)
                {
                        this.Context.Set<Client>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Client item)
                {
                        var entity = this.Context.Set<Client>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Client>().Attach(item);
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
                        Client record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Client>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Client>> Where(
                        Expression<Func<Client, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Client, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Client>();
                        }
                        else
                        {
                                return await this.Context.Set<Client>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Client>();
                        }
                }

                private async Task<Client> GetById(int id)
                {
                        List<Client> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<ClientCommunication>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ClientCommunication>().Where(x => x.ClientId == clientId).AsQueryable().Skip(offset).Take(limit).ToListAsync<ClientCommunication>();
                }
                public async virtual Task<List<Pet>> Pets(int clientId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Pet>().Where(x => x.ClientId == clientId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Pet>();
                }
                public async virtual Task<List<Sale>> Sales(int clientId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Sale>().Where(x => x.ClientId == clientId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Sale>();
                }
        }
}

/*<Codenesium>
    <Hash>ba9d1fcf9101d8fb406bb8d71b60b497</Hash>
</Codenesium>*/
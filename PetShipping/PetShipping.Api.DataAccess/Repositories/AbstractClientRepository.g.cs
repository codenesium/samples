using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
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

                public virtual Task<List<Client>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<Client>> Where(Expression<Func<Client, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Client> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Client>> SearchLinqEF(Expression<Func<Client, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Client.Id)} ASC";
                        }

                        return await this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Client>();
                }

                private async Task<List<Client>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Client.Id)} ASC";
                        }

                        return await this.Context.Set<Client>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Client>();
                }

                private async Task<Client> GetById(int id)
                {
                        List<Client> records = await this.SearchLinqEF(x => x.Id == id);

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
    <Hash>33ce1ab301ec94bbc66e7d22bc8b4550</Hash>
</Codenesium>*/
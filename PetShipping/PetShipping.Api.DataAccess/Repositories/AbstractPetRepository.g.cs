using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public abstract class AbstractPetRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractPetRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Pet>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Pet> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Pet> Create(Pet item)
                {
                        this.Context.Set<Pet>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Pet item)
                {
                        var entity = this.Context.Set<Pet>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Pet>().Attach(item);
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
                        Pet record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Pet>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<List<Sale>> Sales(int petId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<Sale>().Where(x => x.PetId == petId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Sale>();
                }

                public async virtual Task<Breed> GetBreed(int breedId)
                {
                        return await this.Context.Set<Breed>().SingleOrDefaultAsync(x => x.Id == breedId);
                }

                public async virtual Task<Client> GetClient(int clientId)
                {
                        return await this.Context.Set<Client>().SingleOrDefaultAsync(x => x.Id == clientId);
                }

                protected async Task<List<Pet>> Where(
                        Expression<Func<Pet, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Pet, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Pet>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Pet>();
                        }
                        else
                        {
                                return await this.Context.Set<Pet>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Pet>();
                        }
                }

                private async Task<Pet> GetById(int id)
                {
                        List<Pet> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>db639341192f6c52a1f2404e196b5411</Hash>
</Codenesium>*/
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

		public virtual Task<List<Pet>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BreedId == query.ToInt() ||
				                  x.ClientId == query.ToInt() ||
				                  x.Id == query.ToInt() ||
				                  x.Name.StartsWith(query) ||
				                  x.Weight == query.ToInt(),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table Sale via petId.
		public async virtual Task<List<Sale>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Sale>()
			       .Where(x => x.PetId == petId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		// Foreign key reference to table Breed via breedId.
		public async virtual Task<Breed> BreedByBreedId(int breedId)
		{
			return await this.Context.Set<Breed>()
			       .SingleOrDefaultAsync(x => x.Id == breedId);
		}

		protected async Task<List<Pet>> Where(
			Expression<Func<Pet, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Pet, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Pet>()
			       .Include(x => x.BreedIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Pet>();
		}

		private async Task<Pet> GetById(int id)
		{
			List<Pet> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9036fa6895bf0cbfd6990f20105b5ca4</Hash>
</Codenesium>*/
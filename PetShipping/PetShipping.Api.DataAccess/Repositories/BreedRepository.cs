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
	public class BreedRepository : AbstractRepository, IBreedRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public BreedRepository(
			ILogger<IBreedRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Breed>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  (x.SpeciesIdNavigation == null || x.SpeciesIdNavigation.Name == null?false : x.SpeciesIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Breed> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Breed> Create(Breed item)
		{
			this.Context.Set<Breed>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Breed item)
		{
			var entity = this.Context.Set<Breed>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Breed>().Attach(item);
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
			Breed record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Breed>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Pet via breedId.
		public async virtual Task<List<Pet>> PetsByBreedId(int breedId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Pet>()
			       .Include(x => x.BreedIdNavigation)

			       .Where(x => x.BreedId == breedId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Pet>();
		}

		// Foreign key reference to table Species via speciesId.
		public async virtual Task<Species> SpeciesBySpeciesId(int speciesId)
		{
			return await this.Context.Set<Species>()
			       .SingleOrDefaultAsync(x => x.Id == speciesId);
		}

		protected async Task<List<Breed>> Where(
			Expression<Func<Breed, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Breed, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Breed>()
			       .Include(x => x.SpeciesIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Breed>();
		}

		private async Task<Breed> GetById(int id)
		{
			List<Breed> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>358f301c080faec2304acfa068bbf93b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
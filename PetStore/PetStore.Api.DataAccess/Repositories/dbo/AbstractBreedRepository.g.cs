using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractBreedRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBreedRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOBreed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOBreed> Get(int id)
		{
			Breed record = await this.GetById(id);

			return this.Mapper.BreedMapEFToPOCO(record);
		}

		public async virtual Task<POCOBreed> Create(
			ApiBreedModel model)
		{
			Breed record = new Breed();

			this.Mapper.BreedMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Breed>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.BreedMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiBreedModel model)
		{
			Breed record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.BreedMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOBreed>> Where(Expression<Func<Breed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBreed> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOBreed>> SearchLinqPOCO(Expression<Func<Breed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBreed> response = new List<POCOBreed>();
			List<Breed> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.BreedMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Breed>> SearchLinqEF(Expression<Func<Breed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Breed.Id)} ASC";
			}
			return await this.Context.Set<Breed>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Breed>();
		}

		private async Task<List<Breed>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Breed.Id)} ASC";
			}

			return await this.Context.Set<Breed>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Breed>();
		}

		private async Task<Breed> GetById(int id)
		{
			List<Breed> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c1a014d7a5e07ca12e76e323a1edd281</Hash>
</Codenesium>*/
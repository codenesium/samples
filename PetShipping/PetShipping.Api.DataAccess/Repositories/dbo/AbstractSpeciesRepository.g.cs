using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractSpeciesRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpeciesRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSpecies>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSpecies> Get(int id)
		{
			Species record = await this.GetById(id);

			return this.Mapper.SpeciesMapEFToPOCO(record);
		}

		public async virtual Task<POCOSpecies> Create(
			ApiSpeciesModel model)
		{
			Species record = new Species();

			this.Mapper.SpeciesMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Species>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SpeciesMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiSpeciesModel model)
		{
			Species record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpeciesMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			Species record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Species>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSpecies>> Where(Expression<Func<Species, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecies> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSpecies>> SearchLinqPOCO(Expression<Func<Species, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecies> response = new List<POCOSpecies>();
			List<Species> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SpeciesMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Species>> SearchLinqEF(Expression<Func<Species, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Species.Id)} ASC";
			}
			return await this.Context.Set<Species>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Species>();
		}

		private async Task<List<Species>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Species.Id)} ASC";
			}

			return await this.Context.Set<Species>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Species>();
		}

		private async Task<Species> GetById(int id)
		{
			List<Species> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>231332a212a2dae9dcdd1d7fdf9eca2e</Hash>
</Codenesium>*/
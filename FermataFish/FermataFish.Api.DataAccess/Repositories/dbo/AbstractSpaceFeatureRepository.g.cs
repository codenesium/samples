using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractSpaceFeatureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSpaceFeature> Get(int id)
		{
			SpaceFeature record = await this.GetById(id);

			return this.Mapper.SpaceFeatureMapEFToPOCO(record);
		}

		public async virtual Task<POCOSpaceFeature> Create(
			ApiSpaceFeatureModel model)
		{
			SpaceFeature record = new SpaceFeature();

			this.Mapper.SpaceFeatureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpaceFeature>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SpaceFeatureMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiSpaceFeatureModel model)
		{
			SpaceFeature record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpaceFeatureMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			SpaceFeature record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceFeature>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSpaceFeature>> Where(Expression<Func<SpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpaceFeature> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSpaceFeature>> SearchLinqPOCO(Expression<Func<SpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpaceFeature> response = new List<POCOSpaceFeature>();
			List<SpaceFeature> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SpaceFeatureMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SpaceFeature>> SearchLinqEF(Expression<Func<SpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceFeature.Id)} ASC";
			}
			return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpaceFeature>();
		}

		private async Task<List<SpaceFeature>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceFeature.Id)} ASC";
			}

			return await this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpaceFeature>();
		}

		private async Task<SpaceFeature> GetById(int id)
		{
			List<SpaceFeature> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>af5be8a50e0e0f5787bdd92ee1722739</Hash>
</Codenesium>*/
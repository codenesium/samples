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
	public abstract class AbstractSpaceXSpaceFeatureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceXSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSpaceXSpaceFeature>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSpaceXSpaceFeature> Get(int id)
		{
			SpaceXSpaceFeature record = await this.GetById(id);

			return this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(record);
		}

		public async virtual Task<POCOSpaceXSpaceFeature> Create(
			ApiSpaceXSpaceFeatureModel model)
		{
			SpaceXSpaceFeature record = new SpaceXSpaceFeature();

			this.Mapper.SpaceXSpaceFeatureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpaceXSpaceFeature>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiSpaceXSpaceFeatureModel model)
		{
			SpaceXSpaceFeature record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpaceXSpaceFeatureMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			SpaceXSpaceFeature record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceXSpaceFeature>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSpaceXSpaceFeature>> Where(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpaceXSpaceFeature> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSpaceXSpaceFeature>> SearchLinqPOCO(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpaceXSpaceFeature> response = new List<POCOSpaceXSpaceFeature>();
			List<SpaceXSpaceFeature> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SpaceXSpaceFeature>> SearchLinqEF(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
			}
			return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpaceXSpaceFeature>();
		}

		private async Task<List<SpaceXSpaceFeature>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
			}

			return await this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpaceXSpaceFeature>();
		}

		private async Task<SpaceXSpaceFeature> GetById(int id)
		{
			List<SpaceXSpaceFeature> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>13c5a096d23a106b7d003a795b7df8aa</Hash>
</Codenesium>*/
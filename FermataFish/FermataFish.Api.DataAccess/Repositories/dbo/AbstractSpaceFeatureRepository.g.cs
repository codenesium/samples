using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractSpaceFeatureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSpaceFeature Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOSpaceFeature Create(
			ApiSpaceFeatureModel model)
		{
			SpaceFeature record = new SpaceFeature();

			this.Mapper.SpaceFeatureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpaceFeature>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SpaceFeatureMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiSpaceFeatureModel model)
		{
			SpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			SpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceFeature>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSpaceFeature> Where(Expression<Func<SpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSpaceFeature> SearchLinqPOCO(Expression<Func<SpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpaceFeature> response = new List<POCOSpaceFeature>();
			List<SpaceFeature> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SpaceFeatureMapEFToPOCO(x)));
			return response;
		}

		private List<SpaceFeature> SearchLinqEF(Expression<Func<SpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceFeature.Id)} ASC";
			}
			return this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpaceFeature>();
		}

		private List<SpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceFeature.Id)} ASC";
			}

			return this.Context.Set<SpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpaceFeature>();
		}
	}
}

/*<Codenesium>
    <Hash>915b658aec8afa6365c56661a31d8b51</Hash>
</Codenesium>*/
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
	public abstract class AbstractSpaceXSpaceFeatureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceXSpaceFeatureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSpaceXSpaceFeature Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOSpaceXSpaceFeature Create(
			SpaceXSpaceFeatureModel model)
		{
			SpaceXSpaceFeature record = new SpaceXSpaceFeature();

			this.Mapper.SpaceXSpaceFeatureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpaceXSpaceFeature>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			SpaceXSpaceFeatureModel model)
		{
			SpaceXSpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			SpaceXSpaceFeature record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpaceXSpaceFeature>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSpaceXSpaceFeature> Where(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSpaceXSpaceFeature> SearchLinqPOCO(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpaceXSpaceFeature> response = new List<POCOSpaceXSpaceFeature>();
			List<SpaceXSpaceFeature> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SpaceXSpaceFeatureMapEFToPOCO(x)));
			return response;
		}

		private List<SpaceXSpaceFeature> SearchLinqEF(Expression<Func<SpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
			}
			return this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpaceXSpaceFeature>();
		}

		private List<SpaceXSpaceFeature> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpaceXSpaceFeature.Id)} ASC";
			}

			return this.Context.Set<SpaceXSpaceFeature>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpaceXSpaceFeature>();
		}
	}
}

/*<Codenesium>
    <Hash>00e85600b335e9b0566e7f5133a4e187</Hash>
</Codenesium>*/
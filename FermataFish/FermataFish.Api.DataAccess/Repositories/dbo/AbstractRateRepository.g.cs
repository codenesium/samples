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
	public abstract class AbstractRateRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCORate Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCORate Create(
			ApiRateModel model)
		{
			Rate record = new Rate();

			this.Mapper.RateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Rate>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.RateMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiRateModel model)
		{
			Rate record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.RateMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Rate record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Rate>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCORate> Where(Expression<Func<Rate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCORate> SearchLinqPOCO(Expression<Func<Rate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCORate> response = new List<POCORate>();
			List<Rate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.RateMapEFToPOCO(x)));
			return response;
		}

		private List<Rate> SearchLinqEF(Expression<Func<Rate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Rate.Id)} ASC";
			}
			return this.Context.Set<Rate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Rate>();
		}

		private List<Rate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Rate.Id)} ASC";
			}

			return this.Context.Set<Rate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Rate>();
		}
	}
}

/*<Codenesium>
    <Hash>43be460fb58a26b202a6aaaa124932bb</Hash>
</Codenesium>*/
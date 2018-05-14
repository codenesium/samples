using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractScrapReasonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractScrapReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOScrapReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOScrapReason Get(short scrapReasonID)
		{
			return this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();
		}

		public virtual POCOScrapReason Create(
			ApiScrapReasonModel model)
		{
			ScrapReason record = new ScrapReason();

			this.Mapper.ScrapReasonMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<ScrapReason>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ScrapReasonMapEFToPOCO(record);
		}

		public virtual void Update(
			short scrapReasonID,
			ApiScrapReasonModel model)
		{
			ScrapReason record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{scrapReasonID}");
			}
			else
			{
				this.Mapper.ScrapReasonMapModelToEF(
					scrapReasonID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			short scrapReasonID)
		{
			ScrapReason record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ScrapReason>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOScrapReason GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOScrapReason> Where(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOScrapReason> SearchLinqPOCO(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOScrapReason> response = new List<POCOScrapReason>();
			List<ScrapReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ScrapReasonMapEFToPOCO(x)));
			return response;
		}

		private List<ScrapReason> SearchLinqEF(Expression<Func<ScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
			}
			return this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ScrapReason>();
		}

		private List<ScrapReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ScrapReason.ScrapReasonID)} ASC";
			}

			return this.Context.Set<ScrapReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ScrapReason>();
		}
	}
}

/*<Codenesium>
    <Hash>0dff2bce4f8b821c780e06c6e9512548</Hash>
</Codenesium>*/
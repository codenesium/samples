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
	public abstract class AbstractCultureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCulture Get(string cultureID)
		{
			return this.SearchLinqPOCO(x => x.CultureID == cultureID).FirstOrDefault();
		}

		public virtual POCOCulture Create(
			ApiCultureModel model)
		{
			Culture record = new Culture();

			this.Mapper.CultureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<Culture>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CultureMapEFToPOCO(record);
		}

		public virtual void Update(
			string cultureID,
			ApiCultureModel model)
		{
			Culture record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{cultureID}");
			}
			else
			{
				this.Mapper.CultureMapModelToEF(
					cultureID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string cultureID)
		{
			Culture record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Culture>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOCulture GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOCulture> Where(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCulture> SearchLinqPOCO(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCulture> response = new List<POCOCulture>();
			List<Culture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CultureMapEFToPOCO(x)));
			return response;
		}

		private List<Culture> SearchLinqEF(Expression<Func<Culture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}
			return this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Culture>();
		}

		private List<Culture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Culture.CultureID)} ASC";
			}

			return this.Context.Set<Culture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Culture>();
		}
	}
}

/*<Codenesium>
    <Hash>178c956b0b4ce164096223bed9bbefc5</Hash>
</Codenesium>*/
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

		public virtual string Create(
			CultureModel model)
		{
			EFCulture record = new EFCulture();

			this.Mapper.CultureMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<EFCulture>().Add(record);
			this.Context.SaveChanges();
			return record.CultureID;
		}

		public virtual void Update(
			string cultureID,
			CultureModel model)
		{
			EFCulture record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();
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
			EFCulture record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCulture>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOCulture Get(string cultureID)
		{
			return this.SearchLinqPOCO(x => x.CultureID == cultureID).FirstOrDefault();
		}

		public virtual List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOCulture> Where(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCulture> SearchLinqPOCO(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCulture> response = new List<POCOCulture>();
			List<EFCulture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CultureMapEFToPOCO(x)));
			return response;
		}

		private List<EFCulture> SearchLinqEF(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy("CultureID ASC").Skip(skip).Take(take).ToList<EFCulture>();
			}
			else
			{
				return this.Context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCulture>();
			}
		}

		private List<EFCulture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy("CultureID ASC").Skip(skip).Take(take).ToList<EFCulture>();
			}
			else
			{
				return this.Context.Set<EFCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCulture>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>55470d6a908857444e0a7143cc069b46</Hash>
</Codenesium>*/
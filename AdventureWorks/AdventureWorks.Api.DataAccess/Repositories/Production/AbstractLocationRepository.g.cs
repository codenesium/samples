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
	public abstract class AbstractLocationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLocationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual short Create(
			LocationModel model)
		{
			EFLocation record = new EFLocation();

			this.Mapper.LocationMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<EFLocation>().Add(record);
			this.Context.SaveChanges();
			return record.LocationID;
		}

		public virtual void Update(
			short locationID,
			LocationModel model)
		{
			EFLocation record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{locationID}");
			}
			else
			{
				this.Mapper.LocationMapModelToEF(
					locationID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			short locationID)
		{
			EFLocation record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFLocation>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOLocation Get(short locationID)
		{
			return this.SearchLinqPOCO(x => x.LocationID == locationID).FirstOrDefault();
		}

		public virtual List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOLocation> Where(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLocation> SearchLinqPOCO(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLocation> response = new List<POCOLocation>();
			List<EFLocation> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LocationMapEFToPOCO(x)));
			return response;
		}

		private List<EFLocation> SearchLinqEF(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("LocationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this.Context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}

		private List<EFLocation> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy("LocationID ASC").Skip(skip).Take(take).ToList<EFLocation>();
			}
			else
			{
				return this.Context.Set<EFLocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFLocation>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>df727c7b729b246af58767a30a80cf34</Hash>
</Codenesium>*/
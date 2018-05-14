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

		public virtual List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLocation Get(short locationID)
		{
			return this.SearchLinqPOCO(x => x.LocationID == locationID).FirstOrDefault();
		}

		public virtual POCOLocation Create(
			ApiLocationModel model)
		{
			Location record = new Location();

			this.Mapper.LocationMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<Location>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LocationMapEFToPOCO(record);
		}

		public virtual void Update(
			short locationID,
			ApiLocationModel model)
		{
			Location record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();
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
			Location record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Location>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOLocation GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOLocation> Where(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLocation> SearchLinqPOCO(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLocation> response = new List<POCOLocation>();
			List<Location> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LocationMapEFToPOCO(x)));
			return response;
		}

		private List<Location> SearchLinqEF(Expression<Func<Location, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Location.LocationID)} ASC";
			}
			return this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Location>();
		}

		private List<Location> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Location.LocationID)} ASC";
			}

			return this.Context.Set<Location>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Location>();
		}
	}
}

/*<Codenesium>
    <Hash>7e897146ca8394dcaba48eb5f048d2e7</Hash>
</Codenesium>*/
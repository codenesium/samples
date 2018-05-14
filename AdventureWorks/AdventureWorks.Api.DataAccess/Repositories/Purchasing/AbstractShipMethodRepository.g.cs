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
	public abstract class AbstractShipMethodRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractShipMethodRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOShipMethod> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOShipMethod Get(int shipMethodID)
		{
			return this.SearchLinqPOCO(x => x.ShipMethodID == shipMethodID).FirstOrDefault();
		}

		public virtual POCOShipMethod Create(
			ApiShipMethodModel model)
		{
			ShipMethod record = new ShipMethod();

			this.Mapper.ShipMethodMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ShipMethod>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ShipMethodMapEFToPOCO(record);
		}

		public virtual void Update(
			int shipMethodID,
			ApiShipMethodModel model)
		{
			ShipMethod record = this.SearchLinqEF(x => x.ShipMethodID == shipMethodID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shipMethodID}");
			}
			else
			{
				this.Mapper.ShipMethodMapModelToEF(
					shipMethodID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int shipMethodID)
		{
			ShipMethod record = this.SearchLinqEF(x => x.ShipMethodID == shipMethodID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ShipMethod>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOShipMethod GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOShipMethod> Where(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOShipMethod> SearchLinqPOCO(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShipMethod> response = new List<POCOShipMethod>();
			List<ShipMethod> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ShipMethodMapEFToPOCO(x)));
			return response;
		}

		private List<ShipMethod> SearchLinqEF(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
			}
			return this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ShipMethod>();
		}

		private List<ShipMethod> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
			}

			return this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ShipMethod>();
		}
	}
}

/*<Codenesium>
    <Hash>1e218360db0936bd4654cce5945ffb40</Hash>
</Codenesium>*/
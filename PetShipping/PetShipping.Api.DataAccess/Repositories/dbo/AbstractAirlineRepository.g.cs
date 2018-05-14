using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractAirlineRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAirlineRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOAirline Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOAirline Create(
			ApiAirlineModel model)
		{
			Airline record = new Airline();

			this.Mapper.AirlineMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Airline>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.AirlineMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiAirlineModel model)
		{
			Airline record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.AirlineMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Airline record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Airline>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOAirline> Where(Expression<Func<Airline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAirline> SearchLinqPOCO(Expression<Func<Airline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAirline> response = new List<POCOAirline>();
			List<Airline> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AirlineMapEFToPOCO(x)));
			return response;
		}

		private List<Airline> SearchLinqEF(Expression<Func<Airline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Airline.Id)} ASC";
			}
			return this.Context.Set<Airline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Airline>();
		}

		private List<Airline> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Airline.Id)} ASC";
			}

			return this.Context.Set<Airline>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Airline>();
		}
	}
}

/*<Codenesium>
    <Hash>18aa1d94de5bb3c67883f2f9a4adbf49</Hash>
</Codenesium>*/
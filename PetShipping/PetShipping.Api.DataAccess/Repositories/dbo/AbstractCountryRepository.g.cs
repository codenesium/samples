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
	public abstract class AbstractCountryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCountry Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOCountry Create(
			CountryModel model)
		{
			Country record = new Country();

			this.Mapper.CountryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Country>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CountryMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			CountryModel model)
		{
			Country record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.CountryMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Country record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Country>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOCountry> Where(Expression<Func<Country, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCountry> SearchLinqPOCO(Expression<Func<Country, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountry> response = new List<POCOCountry>();
			List<Country> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CountryMapEFToPOCO(x)));
			return response;
		}

		private List<Country> SearchLinqEF(Expression<Func<Country, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Country.Id)} ASC";
			}
			return this.Context.Set<Country>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Country>();
		}

		private List<Country> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Country.Id)} ASC";
			}

			return this.Context.Set<Country>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Country>();
		}
	}
}

/*<Codenesium>
    <Hash>1fb2e94f5092fb17c943606a2172695a</Hash>
</Codenesium>*/
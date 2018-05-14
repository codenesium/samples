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
	public abstract class AbstractCountryRequirementRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRequirementRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCountryRequirement Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOCountryRequirement Create(
			ApiCountryRequirementModel model)
		{
			CountryRequirement record = new CountryRequirement();

			this.Mapper.CountryRequirementMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<CountryRequirement>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CountryRequirementMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiCountryRequirementModel model)
		{
			CountryRequirement record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.CountryRequirementMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			CountryRequirement record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRequirement>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOCountryRequirement> Where(Expression<Func<CountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCountryRequirement> SearchLinqPOCO(Expression<Func<CountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRequirement> response = new List<POCOCountryRequirement>();
			List<CountryRequirement> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CountryRequirementMapEFToPOCO(x)));
			return response;
		}

		private List<CountryRequirement> SearchLinqEF(Expression<Func<CountryRequirement, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRequirement.Id)} ASC";
			}
			return this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CountryRequirement>();
		}

		private List<CountryRequirement> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRequirement.Id)} ASC";
			}

			return this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CountryRequirement>();
		}
	}
}

/*<Codenesium>
    <Hash>771949bcc7c7c0dc757d10d9c8f22227</Hash>
</Codenesium>*/
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
	public abstract class AbstractPersonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPersonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPerson Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOPerson Create(
			ApiPersonModel model)
		{
			Person record = new Person();

			this.Mapper.PersonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Person>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PersonMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiPersonModel model)
		{
			Person record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.PersonMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			Person record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Person>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOPerson> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			return this.SearchLinqPOCO(x => x.LastName == lastName && x.FirstName == firstName && x.MiddleName == middleName);
		}
		public List<POCOPerson> GetAdditionalContactInfo(string additionalContactInfo)
		{
			return this.SearchLinqPOCO(x => x.AdditionalContactInfo == additionalContactInfo);
		}
		public List<POCOPerson> GetDemographics(string demographics)
		{
			return this.SearchLinqPOCO(x => x.Demographics == demographics);
		}

		protected List<POCOPerson> Where(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPerson> SearchLinqPOCO(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPerson> response = new List<POCOPerson>();
			List<Person> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PersonMapEFToPOCO(x)));
			return response;
		}

		private List<Person> SearchLinqEF(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Person.BusinessEntityID)} ASC";
			}
			return this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Person>();
		}

		private List<Person> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Person.BusinessEntityID)} ASC";
			}

			return this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Person>();
		}
	}
}

/*<Codenesium>
    <Hash>afaaa1cd412d85b2340e09721a9aebb8</Hash>
</Codenesium>*/
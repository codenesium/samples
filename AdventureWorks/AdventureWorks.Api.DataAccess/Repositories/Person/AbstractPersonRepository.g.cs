using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractPersonRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPersonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPerson> Get(int businessEntityID)
		{
			Person record = await this.GetById(businessEntityID);

			return this.Mapper.PersonMapEFToPOCO(record);
		}

		public async virtual Task<POCOPerson> Create(
			ApiPersonModel model)
		{
			Person record = new Person();

			this.Mapper.PersonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Person>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PersonMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiPersonModel model)
		{
			Person record = await this.GetById(businessEntityID);

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

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			Person record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Person>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOPerson>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			var records = await this.SearchLinqPOCO(x => x.LastName == lastName && x.FirstName == firstName && x.MiddleName == middleName);

			return records;
		}
		public async Task<List<POCOPerson>> GetAdditionalContactInfo(string additionalContactInfo)
		{
			var records = await this.SearchLinqPOCO(x => x.AdditionalContactInfo == additionalContactInfo);

			return records;
		}
		public async Task<List<POCOPerson>> GetDemographics(string demographics)
		{
			var records = await this.SearchLinqPOCO(x => x.Demographics == demographics);

			return records;
		}

		protected async Task<List<POCOPerson>> Where(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPerson> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPerson>> SearchLinqPOCO(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPerson> response = new List<POCOPerson>();
			List<Person> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PersonMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Person>> SearchLinqEF(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Person.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Person>();
		}

		private async Task<List<Person>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Person.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<Person>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Person>();
		}

		private async Task<Person> GetById(int businessEntityID)
		{
			List<Person> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b4c4b6796578a7bb512cd6dd915ac35b</Hash>
</Codenesium>*/
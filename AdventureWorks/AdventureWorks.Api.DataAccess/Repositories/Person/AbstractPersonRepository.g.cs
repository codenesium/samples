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
		protected IDALPersonMapper Mapper { get; }

		public AbstractPersonRepository(
			IDALPersonMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOPerson> Get(int businessEntityID)
		{
			Person record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOPerson> Create(
			DTOPerson dto)
		{
			Person record = new Person();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Person>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOPerson dto)
		{
			Person record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					businessEntityID,
					dto,
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

		public async Task<List<DTOPerson>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName)
		{
			var records = await this.SearchLinqDTO(x => x.LastName == lastName && x.FirstName == firstName && x.MiddleName == middleName);

			return records;
		}
		public async Task<List<DTOPerson>> GetAdditionalContactInfo(string additionalContactInfo)
		{
			var records = await this.SearchLinqDTO(x => x.AdditionalContactInfo == additionalContactInfo);

			return records;
		}
		public async Task<List<DTOPerson>> GetDemographics(string demographics)
		{
			var records = await this.SearchLinqDTO(x => x.Demographics == demographics);

			return records;
		}

		protected async Task<List<DTOPerson>> Where(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPerson> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOPerson>> SearchLinqDTO(Expression<Func<Person, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPerson> response = new List<DTOPerson>();
			List<Person> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>84b4b52e1094b85628e06161f2cb9bc8</Hash>
</Codenesium>*/
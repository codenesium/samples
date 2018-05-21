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
	public abstract class AbstractPersonPhoneRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPersonPhoneRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPersonPhone> Get(int businessEntityID)
		{
			PersonPhone record = await this.GetById(businessEntityID);

			return this.Mapper.PersonPhoneMapEFToPOCO(record);
		}

		public async virtual Task<POCOPersonPhone> Create(
			ApiPersonPhoneModel model)
		{
			PersonPhone record = new PersonPhone();

			this.Mapper.PersonPhoneMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PersonPhone>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PersonPhoneMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiPersonPhoneModel model)
		{
			PersonPhone record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.PersonPhoneMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			PersonPhone record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonPhone>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOPersonPhone>> GetPhoneNumber(string phoneNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.PhoneNumber == phoneNumber);

			return records;
		}

		protected async Task<List<POCOPersonPhone>> Where(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPersonPhone> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPersonPhone>> SearchLinqPOCO(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPersonPhone> response = new List<POCOPersonPhone>();
			List<PersonPhone> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PersonPhoneMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PersonPhone>> SearchLinqEF(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonPhone>();
		}

		private async Task<List<PersonPhone>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonPhone>();
		}

		private async Task<PersonPhone> GetById(int businessEntityID)
		{
			List<PersonPhone> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f933b4f1609d553820600c5472b466b1</Hash>
</Codenesium>*/
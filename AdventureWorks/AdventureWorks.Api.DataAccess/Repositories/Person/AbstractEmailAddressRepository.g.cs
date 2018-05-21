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
	public abstract class AbstractEmailAddressRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmailAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOEmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOEmailAddress> Get(int businessEntityID)
		{
			EmailAddress record = await this.GetById(businessEntityID);

			return this.Mapper.EmailAddressMapEFToPOCO(record);
		}

		public async virtual Task<POCOEmailAddress> Create(
			ApiEmailAddressModel model)
		{
			EmailAddress record = new EmailAddress();

			this.Mapper.EmailAddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EmailAddress>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.EmailAddressMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiEmailAddressModel model)
		{
			EmailAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.EmailAddressMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			EmailAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmailAddress>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOEmailAddress>> GetEmailAddress(string emailAddress1)
		{
			var records = await this.SearchLinqPOCO(x => x.EmailAddress1 == emailAddress1);

			return records;
		}

		protected async Task<List<POCOEmailAddress>> Where(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmailAddress> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOEmailAddress>> SearchLinqPOCO(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmailAddress> response = new List<POCOEmailAddress>();
			List<EmailAddress> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.EmailAddressMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<EmailAddress>> SearchLinqEF(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmailAddress>();
		}

		private async Task<List<EmailAddress>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmailAddress>();
		}

		private async Task<EmailAddress> GetById(int businessEntityID)
		{
			List<EmailAddress> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>becce0ec80901e443838641e2d06562c</Hash>
</Codenesium>*/
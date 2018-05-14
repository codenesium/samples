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
	public abstract class AbstractEmailAddressRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmailAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOEmailAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOEmailAddress Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOEmailAddress Create(
			ApiEmailAddressModel model)
		{
			EmailAddress record = new EmailAddress();

			this.Mapper.EmailAddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EmailAddress>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.EmailAddressMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiEmailAddressModel model)
		{
			EmailAddress record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EmailAddress record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmailAddress>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOEmailAddress> GetEmailAddress(string emailAddress1)
		{
			return this.SearchLinqPOCO(x => x.EmailAddress1 == emailAddress1);
		}

		protected List<POCOEmailAddress> Where(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOEmailAddress> SearchLinqPOCO(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmailAddress> response = new List<POCOEmailAddress>();
			List<EmailAddress> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.EmailAddressMapEFToPOCO(x)));
			return response;
		}

		private List<EmailAddress> SearchLinqEF(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
			}
			return this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EmailAddress>();
		}

		private List<EmailAddress> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
			}

			return this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EmailAddress>();
		}
	}
}

/*<Codenesium>
    <Hash>874719bb0fed6d4ac958fea8b9626225</Hash>
</Codenesium>*/
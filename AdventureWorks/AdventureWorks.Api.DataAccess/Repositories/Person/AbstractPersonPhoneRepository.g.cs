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
	public abstract class AbstractPersonPhoneRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPersonPhoneRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPersonPhone> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPersonPhone Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOPersonPhone Create(
			ApiPersonPhoneModel model)
		{
			PersonPhone record = new PersonPhone();

			this.Mapper.PersonPhoneMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PersonPhone>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PersonPhoneMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiPersonPhoneModel model)
		{
			PersonPhone record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			PersonPhone record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonPhone>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOPersonPhone> GetPhoneNumber(string phoneNumber)
		{
			return this.SearchLinqPOCO(x => x.PhoneNumber == phoneNumber);
		}

		protected List<POCOPersonPhone> Where(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPersonPhone> SearchLinqPOCO(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPersonPhone> response = new List<POCOPersonPhone>();
			List<PersonPhone> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PersonPhoneMapEFToPOCO(x)));
			return response;
		}

		private List<PersonPhone> SearchLinqEF(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
			}
			return this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PersonPhone>();
		}

		private List<PersonPhone> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
			}

			return this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PersonPhone>();
		}
	}
}

/*<Codenesium>
    <Hash>5c1e5f6e49c1c0a263de0a489c1dd0d1</Hash>
</Codenesium>*/
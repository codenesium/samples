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
	public abstract class AbstractBusinessEntityContactRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityContactRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOBusinessEntityContact Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOBusinessEntityContact Create(
			ApiBusinessEntityContactModel model)
		{
			BusinessEntityContact record = new BusinessEntityContact();

			this.Mapper.BusinessEntityContactMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BusinessEntityContact>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.BusinessEntityContactMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiBusinessEntityContactModel model)
		{
			BusinessEntityContact record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityContactMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			BusinessEntityContact record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntityContact>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOBusinessEntityContact> GetContactTypeID(int contactTypeID)
		{
			return this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID);
		}
		public List<POCOBusinessEntityContact> GetPersonID(int personID)
		{
			return this.SearchLinqPOCO(x => x.PersonID == personID);
		}

		protected List<POCOBusinessEntityContact> Where(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBusinessEntityContact> SearchLinqPOCO(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntityContact> response = new List<POCOBusinessEntityContact>();
			List<BusinessEntityContact> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BusinessEntityContactMapEFToPOCO(x)));
			return response;
		}

		private List<BusinessEntityContact> SearchLinqEF(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityContact.BusinessEntityID)} ASC";
			}
			return this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BusinessEntityContact>();
		}

		private List<BusinessEntityContact> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityContact.BusinessEntityID)} ASC";
			}

			return this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BusinessEntityContact>();
		}
	}
}

/*<Codenesium>
    <Hash>2c209b831b34f36419d021a78910b15e</Hash>
</Codenesium>*/
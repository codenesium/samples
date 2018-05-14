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
	public abstract class AbstractContactTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractContactTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOContactType Get(int contactTypeID)
		{
			return this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID).FirstOrDefault();
		}

		public virtual POCOContactType Create(
			ApiContactTypeModel model)
		{
			ContactType record = new ContactType();

			this.Mapper.ContactTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ContactType>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ContactTypeMapEFToPOCO(record);
		}

		public virtual void Update(
			int contactTypeID,
			ApiContactTypeModel model)
		{
			ContactType record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{contactTypeID}");
			}
			else
			{
				this.Mapper.ContactTypeMapModelToEF(
					contactTypeID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int contactTypeID)
		{
			ContactType record = this.SearchLinqEF(x => x.ContactTypeID == contactTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ContactType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOContactType GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOContactType> Where(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOContactType> SearchLinqPOCO(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOContactType> response = new List<POCOContactType>();
			List<ContactType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ContactTypeMapEFToPOCO(x)));
			return response;
		}

		private List<ContactType> SearchLinqEF(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ContactType.ContactTypeID)} ASC";
			}
			return this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ContactType>();
		}

		private List<ContactType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ContactType.ContactTypeID)} ASC";
			}

			return this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ContactType>();
		}
	}
}

/*<Codenesium>
    <Hash>96a4c4982d0d409906db6330e0983195</Hash>
</Codenesium>*/
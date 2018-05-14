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
	public abstract class AbstractBusinessEntityAddressRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOBusinessEntityAddress Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOBusinessEntityAddress Create(
			ApiBusinessEntityAddressModel model)
		{
			BusinessEntityAddress record = new BusinessEntityAddress();

			this.Mapper.BusinessEntityAddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BusinessEntityAddress>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.BusinessEntityAddressMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiBusinessEntityAddressModel model)
		{
			BusinessEntityAddress record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityAddressMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			BusinessEntityAddress record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntityAddress>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOBusinessEntityAddress> GetAddressID(int addressID)
		{
			return this.SearchLinqPOCO(x => x.AddressID == addressID);
		}
		public List<POCOBusinessEntityAddress> GetAddressTypeID(int addressTypeID)
		{
			return this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID);
		}

		protected List<POCOBusinessEntityAddress> Where(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBusinessEntityAddress> SearchLinqPOCO(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntityAddress> response = new List<POCOBusinessEntityAddress>();
			List<BusinessEntityAddress> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BusinessEntityAddressMapEFToPOCO(x)));
			return response;
		}

		private List<BusinessEntityAddress> SearchLinqEF(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}
			return this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BusinessEntityAddress>();
		}

		private List<BusinessEntityAddress> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}

			return this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BusinessEntityAddress>();
		}
	}
}

/*<Codenesium>
    <Hash>c75e046f17ed3737c13508ad3a34937c</Hash>
</Codenesium>*/
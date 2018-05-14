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
	public abstract class AbstractVendorRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractVendorRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOVendor Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOVendor Create(
			ApiVendorModel model)
		{
			Vendor record = new Vendor();

			this.Mapper.VendorMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Vendor>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.VendorMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiVendorModel model)
		{
			Vendor record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.VendorMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			Vendor record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Vendor>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOVendor GetAccountNumber(string accountNumber)
		{
			return this.SearchLinqPOCO(x => x.AccountNumber == accountNumber).FirstOrDefault();
		}

		protected List<POCOVendor> Where(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOVendor> SearchLinqPOCO(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOVendor> response = new List<POCOVendor>();
			List<Vendor> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.VendorMapEFToPOCO(x)));
			return response;
		}

		private List<Vendor> SearchLinqEF(Expression<Func<Vendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Vendor.BusinessEntityID)} ASC";
			}
			return this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Vendor>();
		}

		private List<Vendor> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Vendor.BusinessEntityID)} ASC";
			}

			return this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Vendor>();
		}
	}
}

/*<Codenesium>
    <Hash>fd67ad74f3b5861a4454cfe5078a8019</Hash>
</Codenesium>*/
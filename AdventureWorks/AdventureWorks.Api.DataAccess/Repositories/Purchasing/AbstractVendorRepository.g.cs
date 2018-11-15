using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractVendorRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVendorRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Vendor>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Vendor> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<Vendor> Create(Vendor item)
		{
			this.Context.Set<Vendor>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Vendor item)
		{
			var entity = this.Context.Set<Vendor>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<Vendor>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			Vendor record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Vendor>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Vendor> ByAccountNumber(string accountNumber)
		{
			return await this.Context.Set<Vendor>().SingleOrDefaultAsync(x => x.AccountNumber == accountNumber);
		}

		public async virtual Task<List<PurchaseOrderHeader>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PurchaseOrderHeader>().Where(x => x.VendorID == vendorID).AsQueryable().Skip(offset).Take(limit).ToListAsync<PurchaseOrderHeader>();
		}

		protected async Task<List<Vendor>> Where(
			Expression<Func<Vendor, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Vendor, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<Vendor>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Vendor>();
		}

		private async Task<Vendor> GetById(int businessEntityID)
		{
			List<Vendor> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9039af93e1d3f40233ddac8b726d3387</Hash>
</Codenesium>*/
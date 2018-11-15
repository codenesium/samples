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
	public abstract class AbstractPurchaseOrderHeaderRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPurchaseOrderHeaderRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PurchaseOrderHeader>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PurchaseOrderHeader> Get(int purchaseOrderID)
		{
			return await this.GetById(purchaseOrderID);
		}

		public async virtual Task<PurchaseOrderHeader> Create(PurchaseOrderHeader item)
		{
			this.Context.Set<PurchaseOrderHeader>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PurchaseOrderHeader item)
		{
			var entity = this.Context.Set<PurchaseOrderHeader>().Local.FirstOrDefault(x => x.PurchaseOrderID == item.PurchaseOrderID);
			if (entity == null)
			{
				this.Context.Set<PurchaseOrderHeader>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int purchaseOrderID)
		{
			PurchaseOrderHeader record = await this.GetById(purchaseOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PurchaseOrderHeader>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<PurchaseOrderHeader>> ByEmployeeID(int employeeID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.EmployeeID == employeeID, limit, offset);
		}

		public async virtual Task<List<PurchaseOrderHeader>> ByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.VendorID == vendorID, limit, offset);
		}

		protected async Task<List<PurchaseOrderHeader>> Where(
			Expression<Func<PurchaseOrderHeader, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PurchaseOrderHeader, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.PurchaseOrderID;
			}

			return await this.Context.Set<PurchaseOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PurchaseOrderHeader>();
		}

		private async Task<PurchaseOrderHeader> GetById(int purchaseOrderID)
		{
			List<PurchaseOrderHeader> records = await this.Where(x => x.PurchaseOrderID == purchaseOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>845605ab4f5a2f9f856d8cf0c5b70bcb</Hash>
</Codenesium>*/
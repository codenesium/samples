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
	public abstract class AbstractSalesOrderDetailRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesOrderDetailRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesOrderDetail>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SalesOrderDetail> Get(int salesOrderID)
		{
			return await this.GetById(salesOrderID);
		}

		public async virtual Task<SalesOrderDetail> Create(SalesOrderDetail item)
		{
			this.Context.Set<SalesOrderDetail>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesOrderDetail item)
		{
			var entity = this.Context.Set<SalesOrderDetail>().Local.FirstOrDefault(x => x.SalesOrderID == item.SalesOrderID);
			if (entity == null)
			{
				this.Context.Set<SalesOrderDetail>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderDetail record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderDetail>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<SalesOrderDetail>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.ProductID == productID, limit, offset);

			return records;
		}

		public async virtual Task<SpecialOfferProduct> GetSpecialOfferProduct(int productID)
		{
			return await this.Context.Set<SpecialOfferProduct>().SingleOrDefaultAsync(x => x.SpecialOfferID == productID);
		}

		public async virtual Task<SalesOrderHeader> GetSalesOrderHeader(int salesOrderID)
		{
			return await this.Context.Set<SalesOrderHeader>().SingleOrDefaultAsync(x => x.SalesOrderID == salesOrderID);
		}

		protected async Task<List<SalesOrderDetail>> Where(
			Expression<Func<SalesOrderDetail, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesOrderDetail, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SalesOrderID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesOrderDetail>();
			}
			else
			{
				return await this.Context.Set<SalesOrderDetail>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SalesOrderDetail>();
			}
		}

		private async Task<SalesOrderDetail> GetById(int salesOrderID)
		{
			List<SalesOrderDetail> records = await this.Where(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>70c88789eaaf8ea2a29cd9c86012b092</Hash>
</Codenesium>*/
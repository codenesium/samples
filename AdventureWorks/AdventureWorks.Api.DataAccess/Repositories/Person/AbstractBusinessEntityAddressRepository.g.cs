using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractBusinessEntityAddressRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractBusinessEntityAddressRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<BusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<BusinessEntityAddress> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<BusinessEntityAddress> Create(BusinessEntityAddress item)
		{
			this.Context.Set<BusinessEntityAddress>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(BusinessEntityAddress item)
		{
			var entity = this.Context.Set<BusinessEntityAddress>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<BusinessEntityAddress>().Attach(item);
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
			BusinessEntityAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntityAddress>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<BusinessEntityAddress>> GetAddressID(int addressID)
		{
			var records = await this.SearchLinqEF(x => x.AddressID == addressID);

			return records;
		}
		public async Task<List<BusinessEntityAddress>> GetAddressTypeID(int addressTypeID)
		{
			var records = await this.SearchLinqEF(x => x.AddressTypeID == addressTypeID);

			return records;
		}

		protected async Task<List<BusinessEntityAddress>> Where(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<BusinessEntityAddress> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<BusinessEntityAddress>> SearchLinqEF(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityAddress>();
		}

		private async Task<List<BusinessEntityAddress>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityAddress>();
		}

		private async Task<BusinessEntityAddress> GetById(int businessEntityID)
		{
			List<BusinessEntityAddress> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e4f9cd2203d827a3de55311893214a43</Hash>
</Codenesium>*/
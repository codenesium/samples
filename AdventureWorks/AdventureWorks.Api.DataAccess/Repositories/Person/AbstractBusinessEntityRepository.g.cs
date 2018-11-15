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
	public abstract class AbstractBusinessEntityRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractBusinessEntityRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<BusinessEntity>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<BusinessEntity> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<BusinessEntity> Create(BusinessEntity item)
		{
			this.Context.Set<BusinessEntity>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(BusinessEntity item)
		{
			var entity = this.Context.Set<BusinessEntity>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<BusinessEntity>().Attach(item);
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
			BusinessEntity record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntity>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<BusinessEntity> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<BusinessEntity>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		public async virtual Task<List<Person>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Person>().Where(x => x.BusinessEntityID == businessEntityID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Person>();
		}

		protected async Task<List<BusinessEntity>> Where(
			Expression<Func<BusinessEntity, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<BusinessEntity, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<BusinessEntity>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<BusinessEntity>();
		}

		private async Task<BusinessEntity> GetById(int businessEntityID)
		{
			List<BusinessEntity> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>23e42562208cf3f0d3d913a745a9cc3f</Hash>
</Codenesium>*/
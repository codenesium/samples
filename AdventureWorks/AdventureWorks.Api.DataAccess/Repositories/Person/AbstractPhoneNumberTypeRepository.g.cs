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
	public abstract class AbstractPhoneNumberTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPhoneNumberTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PhoneNumberType>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PhoneNumberType> Get(int phoneNumberTypeID)
		{
			return await this.GetById(phoneNumberTypeID);
		}

		public async virtual Task<PhoneNumberType> Create(PhoneNumberType item)
		{
			this.Context.Set<PhoneNumberType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PhoneNumberType item)
		{
			var entity = this.Context.Set<PhoneNumberType>().Local.FirstOrDefault(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID);
			if (entity == null)
			{
				this.Context.Set<PhoneNumberType>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int phoneNumberTypeID)
		{
			PhoneNumberType record = await this.GetById(phoneNumberTypeID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PhoneNumberType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<PhoneNumberType>> Where(
			Expression<Func<PhoneNumberType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PhoneNumberType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.PhoneNumberTypeID;
			}

			return await this.Context.Set<PhoneNumberType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PhoneNumberType>();
		}

		private async Task<PhoneNumberType> GetById(int phoneNumberTypeID)
		{
			List<PhoneNumberType> records = await this.Where(x => x.PhoneNumberTypeID == phoneNumberTypeID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7efb2fc795c84daf7f2a2e41a1837a36</Hash>
</Codenesium>*/
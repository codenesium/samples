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

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractPaymentTypeRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPaymentTypeRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PaymentType>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PaymentType> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PaymentType> Create(PaymentType item)
		{
			this.Context.Set<PaymentType>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PaymentType item)
		{
			var entity = this.Context.Set<PaymentType>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PaymentType>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			PaymentType record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PaymentType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<Sale>> SalesByPaymentTypeId(int paymentTypeId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Sale>().Where(x => x.PaymentTypeId == paymentTypeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		protected async Task<List<PaymentType>> Where(
			Expression<Func<PaymentType, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PaymentType, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PaymentType>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PaymentType>();
		}

		private async Task<PaymentType> GetById(int id)
		{
			List<PaymentType> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>906da389d80d5044ec4a4952a1b28783</Hash>
</Codenesium>*/
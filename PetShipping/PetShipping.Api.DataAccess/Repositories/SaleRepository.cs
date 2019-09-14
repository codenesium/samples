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

namespace PetShippingNS.Api.DataAccess
{
	public class SaleRepository : AbstractRepository, ISaleRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SaleRepository(
			ILogger<ISaleRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Sale>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Amount.ToDecimal() == query.ToDecimal() ||
				                  x.CutomerId == query.ToInt() ||
				                  (x.Note == null?false : x.Note.StartsWith(query)) ||
				                  (x.PetIdNavigation == null || x.PetIdNavigation.Name == null?false : x.PetIdNavigation.Name.StartsWith(query)) ||
				                  x.SaleDate == query.ToDateTime() ||
				                  x.SalesPersonId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Sale> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Sale> Create(Sale item)
		{
			this.Context.Set<Sale>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Sale item)
		{
			var entity = this.Context.Set<Sale>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Sale>().Attach(item);
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
			Sale record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Sale>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Pet via petId.
		public async virtual Task<Pet> PetByPetId(int petId)
		{
			return await this.Context.Set<Pet>()
			       .SingleOrDefaultAsync(x => x.Id == petId);
		}

		protected async Task<List<Sale>> Where(
			Expression<Func<Sale, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Sale, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Sale>()
			       .Include(x => x.PetIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Sale>();
		}

		private async Task<Sale> GetById(int id)
		{
			List<Sale> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>806981b0c296c71ba11e3e45b8f82bad</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
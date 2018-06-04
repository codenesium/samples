using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStudentXFamilyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractStudentXFamilyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<StudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<StudentXFamily> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<StudentXFamily> Create(StudentXFamily item)
		{
			this.Context.Set<StudentXFamily>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(StudentXFamily item)
		{
			var entity = this.Context.Set<StudentXFamily>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<StudentXFamily>().Attach(item);
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
			StudentXFamily record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<StudentXFamily>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<StudentXFamily>> Where(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<StudentXFamily> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<StudentXFamily>> SearchLinqEF(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StudentXFamily.Id)} ASC";
			}
			return await this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StudentXFamily>();
		}

		private async Task<List<StudentXFamily>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StudentXFamily.Id)} ASC";
			}

			return await this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StudentXFamily>();
		}

		private async Task<StudentXFamily> GetById(int id)
		{
			List<StudentXFamily> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c0b9be6e85a08592ad2038e90d13dcd6</Hash>
</Codenesium>*/
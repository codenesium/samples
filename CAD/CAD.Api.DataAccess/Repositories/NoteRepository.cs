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

namespace CADNS.Api.DataAccess
{
	public class NoteRepository : AbstractRepository, INoteRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public NoteRepository(
			ILogger<INoteRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Note>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.CallIdNavigation == null || x.CallIdNavigation.Id == null?false : x.CallIdNavigation.Id == query.ToInt()) ||
				                  x.DateCreated == query.ToDateTime() ||
				                  (x.NoteText == null?false : x.NoteText.StartsWith(query)) ||
				                  (x.OfficerIdNavigation == null || x.OfficerIdNavigation.LastName == null?false : x.OfficerIdNavigation.LastName.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Note> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Note> Create(Note item)
		{
			this.Context.Set<Note>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Note item)
		{
			var entity = this.Context.Set<Note>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Note>().Attach(item);
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
			Note record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Note>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Call via callId.
		public async virtual Task<Call> CallByCallId(int callId)
		{
			return await this.Context.Set<Call>()
			       .SingleOrDefaultAsync(x => x.Id == callId);
		}

		// Foreign key reference to table Officer via officerId.
		public async virtual Task<Officer> OfficerByOfficerId(int officerId)
		{
			return await this.Context.Set<Officer>()
			       .SingleOrDefaultAsync(x => x.Id == officerId);
		}

		protected async Task<List<Note>> Where(
			Expression<Func<Note, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Note, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Note>()
			       .Include(x => x.CallIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Note>();
		}

		private async Task<Note> GetById(int id)
		{
			List<Note> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>62aa6066e43d3af6f5afe93eaba8cf7a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
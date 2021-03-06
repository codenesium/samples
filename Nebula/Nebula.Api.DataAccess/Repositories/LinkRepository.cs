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

namespace NebulaNS.Api.DataAccess
{
	public class LinkRepository : AbstractRepository, ILinkRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public LinkRepository(
			ILogger<ILinkRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Link>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.AssignedMachineIdNavigation == null || x.AssignedMachineIdNavigation.Name == null?false : x.AssignedMachineIdNavigation.Name.StartsWith(query)) ||
				                  (x.ChainIdNavigation == null || x.ChainIdNavigation.Name == null?false : x.ChainIdNavigation.Name.StartsWith(query)) ||
				                  x.DateCompleted == query.ToNullableDateTime() ||
				                  x.DateStarted == query.ToNullableDateTime() ||
				                  (x.DynamicParameters == null?false : x.DynamicParameters.StartsWith(query)) ||
				                  x.ExternalId == query.ToGuid() ||
				                  (x.LinkStatusIdNavigation == null || x.LinkStatusIdNavigation.Name == null?false : x.LinkStatusIdNavigation.Name.StartsWith(query)) ||
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  x.Order == query.ToInt() ||
				                  (x.Response == null?false : x.Response.StartsWith(query)) ||
				                  (x.StaticParameters == null?false : x.StaticParameters.StartsWith(query)) ||
				                  x.TimeoutInSeconds == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Link> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Link> Create(Link item)
		{
			this.Context.Set<Link>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Link item)
		{
			var entity = this.Context.Set<Link>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Link>().Attach(item);
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
			Link record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Link>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AX_Link_ExternalId.
		public async virtual Task<Link> ByExternalId(Guid externalId)
		{
			return await this.Context.Set<Link>()
			       .Include(x => x.AssignedMachineIdNavigation)
			       .Include(x => x.ChainIdNavigation)
			       .Include(x => x.LinkStatusIdNavigation)

			       .FirstOrDefaultAsync(x => x.ExternalId == externalId);
		}

		// Non-unique constraint AX_Link_ChainId.
		public async virtual Task<List<Link>> ByChainId(int chainId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.ChainId == chainId, limit, offset);
		}

		// Foreign key reference to this table LinkLog via linkId.
		public async virtual Task<List<LinkLog>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<LinkLog>()
			       .Include(x => x.LinkIdNavigation)

			       .Where(x => x.LinkId == linkId).AsQueryable().Skip(offset).Take(limit).ToListAsync<LinkLog>();
		}

		// Foreign key reference to table Machine via assignedMachineId.
		public async virtual Task<Machine> MachineByAssignedMachineId(int? assignedMachineId)
		{
			return await this.Context.Set<Machine>()
			       .SingleOrDefaultAsync(x => x.Id == assignedMachineId);
		}

		// Foreign key reference to table Chain via chainId.
		public async virtual Task<Chain> ChainByChainId(int chainId)
		{
			return await this.Context.Set<Chain>()
			       .SingleOrDefaultAsync(x => x.Id == chainId);
		}

		// Foreign key reference to table LinkStatus via linkStatusId.
		public async virtual Task<LinkStatus> LinkStatusByLinkStatusId(int linkStatusId)
		{
			return await this.Context.Set<LinkStatus>()
			       .SingleOrDefaultAsync(x => x.Id == linkStatusId);
		}

		protected async Task<List<Link>> Where(
			Expression<Func<Link, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Link, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Link>()
			       .Include(x => x.AssignedMachineIdNavigation)
			       .Include(x => x.ChainIdNavigation)
			       .Include(x => x.LinkStatusIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Link>();
		}

		private async Task<Link> GetById(int id)
		{
			List<Link> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9bee8ad6185e092c4f097c2826d6cea7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
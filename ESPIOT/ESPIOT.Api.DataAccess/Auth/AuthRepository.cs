using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess.Auth
{
    public class AuthRepository
    {
		private ApplicationDbContext context;

		private ILogger logger;

		public AuthRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.logger = logger;
			this.context = context;
		}

		public async virtual Task<AuthUser> Create(AuthUser item)
		{
			this.context.Set<AuthUser>().Add(item);
			await this.context.SaveChangesAsync();

			this.context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task<AuthUser> Get(int id)
		{
			return await this.context.AuthUsers.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async virtual Task<AuthUser> GetByEmail(string email)
		{
			return await this.context.AuthUsers.FirstOrDefaultAsync(x => x.Email == email);
		}

		public async virtual Task<AuthUser> GetByExternalId(Guid externalId)
		{
			return await this.context.AuthUsers.FirstOrDefaultAsync(x => x.ExternalId == externalId);
		}
	}
}

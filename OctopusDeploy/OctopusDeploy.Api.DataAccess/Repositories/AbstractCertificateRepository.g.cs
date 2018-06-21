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

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractCertificateRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCertificateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Certificate>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Certificate> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Certificate> Create(Certificate item)
                {
                        this.Context.Set<Certificate>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Certificate item)
                {
                        var entity = this.Context.Set<Certificate>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Certificate>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        Certificate record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Certificate>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<Certificate>> GetCreated(DateTimeOffset created)
                {
                        var records = await this.Where(x => x.Created == created);

                        return records;
                }

                public async Task<List<Certificate>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.Where(x => x.DataVersion == dataVersion);

                        return records;
                }

                public async Task<List<Certificate>> GetNotAfter(DateTimeOffset notAfter)
                {
                        var records = await this.Where(x => x.NotAfter == notAfter);

                        return records;
                }

                public async Task<List<Certificate>> GetThumbprint(string thumbprint)
                {
                        var records = await this.Where(x => x.Thumbprint == thumbprint);

                        return records;
                }

                protected async Task<List<Certificate>> Where(
                        Expression<Func<Certificate, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Certificate, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Certificate>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Certificate>();
                        }
                        else
                        {
                                return await this.Context.Set<Certificate>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Certificate>();
                        }
                }

                private async Task<Certificate> GetById(string id)
                {
                        List<Certificate> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>58e0f899c1524da970b0a2f4634f95d5</Hash>
</Codenesium>*/
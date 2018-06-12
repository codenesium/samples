using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractCertificateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractCertificateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Certificate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<Certificate>> GetCreated(DateTime created)
                {
                        var records = await this.SearchLinqEF(x => x.Created == created);

                        return records;
                }
                public async Task<List<Certificate>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.SearchLinqEF(x => x.DataVersion == dataVersion);

                        return records;
                }
                public async Task<List<Certificate>> GetNotAfter(DateTime notAfter)
                {
                        var records = await this.SearchLinqEF(x => x.NotAfter == notAfter);

                        return records;
                }
                public async Task<List<Certificate>> GetThumbprint(string thumbprint)
                {
                        var records = await this.SearchLinqEF(x => x.Thumbprint == thumbprint);

                        return records;
                }

                protected async Task<List<Certificate>> Where(Expression<Func<Certificate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Certificate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Certificate>> SearchLinqEF(Expression<Func<Certificate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Certificate.Id)} ASC";
                        }

                        return await this.Context.Set<Certificate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Certificate>();
                }

                private async Task<List<Certificate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Certificate.Id)} ASC";
                        }

                        return await this.Context.Set<Certificate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Certificate>();
                }

                private async Task<Certificate> GetById(string id)
                {
                        List<Certificate> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>e3c16760ec6a9792ce72c1fea467af5f</Hash>
</Codenesium>*/
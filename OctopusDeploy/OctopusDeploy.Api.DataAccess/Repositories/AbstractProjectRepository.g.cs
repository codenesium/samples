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
        public abstract class AbstractProjectRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProjectRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Project>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Project> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Project> Create(Project item)
                {
                        this.Context.Set<Project>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Project item)
                {
                        var entity = this.Context.Set<Project>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Project>().Attach(item);
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
                        Project record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Project>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Project> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<Project> GetSlug(string slug)
                {
                        var records = await this.SearchLinqEF(x => x.Slug == slug);

                        return records.FirstOrDefault();
                }
                public async Task<List<Project>> GetDataVersion(byte[] dataVersion)
                {
                        var records = await this.SearchLinqEF(x => x.DataVersion == dataVersion);

                        return records;
                }
                public async Task<List<Project>> GetDiscreteChannelReleaseId(bool discreteChannelRelease, string id)
                {
                        var records = await this.SearchLinqEF(x => x.DiscreteChannelRelease == discreteChannelRelease && x.Id == id);

                        return records;
                }

                protected async Task<List<Project>> Where(Expression<Func<Project, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Project> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Project>> SearchLinqEF(Expression<Func<Project, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Project.Id)} ASC";
                        }

                        return await this.Context.Set<Project>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Project>();
                }

                private async Task<List<Project>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Project.Id)} ASC";
                        }

                        return await this.Context.Set<Project>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Project>();
                }

                private async Task<Project> GetById(string id)
                {
                        List<Project> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>415f4c6ecbf7dc135d2974f2e944c04f</Hash>
</Codenesium>*/
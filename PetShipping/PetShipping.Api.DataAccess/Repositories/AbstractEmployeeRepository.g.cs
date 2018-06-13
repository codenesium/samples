using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public abstract class AbstractEmployeeRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractEmployeeRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Employee> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Employee> Create(Employee item)
                {
                        this.Context.Set<Employee>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Employee item)
                {
                        var entity = this.Context.Set<Employee>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Employee>().Attach(item);
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
                        Employee record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Employee>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Employee>> Where(Expression<Func<Employee, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Employee> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Employee>> SearchLinqEF(Expression<Func<Employee, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Employee.Id)} ASC";
                        }

                        return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Employee>();
                }

                private async Task<List<Employee>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Employee.Id)} ASC";
                        }

                        return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Employee>();
                }

                private async Task<Employee> GetById(int id)
                {
                        List<Employee> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<ClientCommunication>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ClientCommunication>().Where(x => x.EmployeeId == employeeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<ClientCommunication>();
                }
                public async virtual Task<List<PipelineStep>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PipelineStep>().Where(x => x.ShipperId == shipperId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStep>();
                }
                public async virtual Task<List<PipelineStepNote>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<PipelineStepNote>().Where(x => x.EmployeeId == employeeId).AsQueryable().Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
                }
        }
}

/*<Codenesium>
    <Hash>5dae26c385bfb26af450ebefc4220b45</Hash>
</Codenesium>*/
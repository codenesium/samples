using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractEmployeeRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmployeeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOEmployee> Get(int businessEntityID)
		{
			Employee record = await this.GetById(businessEntityID);

			return this.Mapper.EmployeeMapEFToPOCO(record);
		}

		public async virtual Task<POCOEmployee> Create(
			ApiEmployeeModel model)
		{
			Employee record = new Employee();

			this.Mapper.EmployeeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Employee>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.EmployeeMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiEmployeeModel model)
		{
			Employee record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.EmployeeMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			Employee record = await this.GetById(businessEntityID);

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

		public async Task<POCOEmployee> GetLoginID(string loginID)
		{
			var records = await this.SearchLinqPOCO(x => x.LoginID == loginID);

			return records.FirstOrDefault();
		}
		public async Task<POCOEmployee> GetNationalIDNumber(string nationalIDNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.NationalIDNumber == nationalIDNumber);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOEmployee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			var records = await this.SearchLinqPOCO(x => x.OrganizationLevel == organizationLevel && x.OrganizationNode == organizationNode);

			return records;
		}
		public async Task<List<POCOEmployee>> GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			var records = await this.SearchLinqPOCO(x => x.OrganizationNode == organizationNode);

			return records;
		}

		protected async Task<List<POCOEmployee>> Where(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployee> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOEmployee>> SearchLinqPOCO(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployee> response = new List<POCOEmployee>();
			List<Employee> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.EmployeeMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Employee>> SearchLinqEF(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Employee.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Employee>();
		}

		private async Task<List<Employee>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Employee.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<Employee>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Employee>();
		}

		private async Task<Employee> GetById(int businessEntityID)
		{
			List<Employee> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8fb2e259e4258ddbfe3880202ca2e874</Hash>
</Codenesium>*/
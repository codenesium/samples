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
		protected IDALEmployeeMapper Mapper { get; }

		public AbstractEmployeeRepository(
			IDALEmployeeMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOEmployee> Get(int businessEntityID)
		{
			Employee record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOEmployee> Create(
			DTOEmployee dto)
		{
			Employee record = new Employee();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Employee>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOEmployee dto)
		{
			Employee record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					businessEntityID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOEmployee> GetLoginID(string loginID)
		{
			var records = await this.SearchLinqDTO(x => x.LoginID == loginID);

			return records.FirstOrDefault();
		}
		public async Task<DTOEmployee> GetNationalIDNumber(string nationalIDNumber)
		{
			var records = await this.SearchLinqDTO(x => x.NationalIDNumber == nationalIDNumber);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOEmployee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			var records = await this.SearchLinqDTO(x => x.OrganizationLevel == organizationLevel && x.OrganizationNode == organizationNode);

			return records;
		}
		public async Task<List<DTOEmployee>> GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			var records = await this.SearchLinqDTO(x => x.OrganizationNode == organizationNode);

			return records;
		}

		protected async Task<List<DTOEmployee>> Where(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmployee> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOEmployee>> SearchLinqDTO(Expression<Func<Employee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmployee> response = new List<DTOEmployee>();
			List<Employee> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>97c593f9734868ef5509fb43685e82d4</Hash>
</Codenesium>*/
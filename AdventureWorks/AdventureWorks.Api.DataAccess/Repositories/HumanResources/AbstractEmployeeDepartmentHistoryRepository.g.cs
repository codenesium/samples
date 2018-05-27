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
	public abstract class AbstractEmployeeDepartmentHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALEmployeeDepartmentHistoryMapper Mapper { get; }

		public AbstractEmployeeDepartmentHistoryRepository(
			IDALEmployeeDepartmentHistoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOEmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOEmployeeDepartmentHistory> Get(int businessEntityID)
		{
			EmployeeDepartmentHistory record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOEmployeeDepartmentHistory> Create(
			DTOEmployeeDepartmentHistory dto)
		{
			EmployeeDepartmentHistory record = new EmployeeDepartmentHistory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<EmployeeDepartmentHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOEmployeeDepartmentHistory dto)
		{
			EmployeeDepartmentHistory record = await this.GetById(businessEntityID);

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
			EmployeeDepartmentHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmployeeDepartmentHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOEmployeeDepartmentHistory>> GetDepartmentID(short departmentID)
		{
			var records = await this.SearchLinqDTO(x => x.DepartmentID == departmentID);

			return records;
		}
		public async Task<List<DTOEmployeeDepartmentHistory>> GetShiftID(int shiftID)
		{
			var records = await this.SearchLinqDTO(x => x.ShiftID == shiftID);

			return records;
		}

		protected async Task<List<DTOEmployeeDepartmentHistory>> Where(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmployeeDepartmentHistory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOEmployeeDepartmentHistory>> SearchLinqDTO(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmployeeDepartmentHistory> response = new List<DTOEmployeeDepartmentHistory>();
			List<EmployeeDepartmentHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<EmployeeDepartmentHistory>> SearchLinqEF(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeeDepartmentHistory.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeeDepartmentHistory>();
		}

		private async Task<List<EmployeeDepartmentHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeeDepartmentHistory.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeeDepartmentHistory>();
		}

		private async Task<EmployeeDepartmentHistory> GetById(int businessEntityID)
		{
			List<EmployeeDepartmentHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>cd50f053c289ca0897a20e3eb1f4861b</Hash>
</Codenesium>*/
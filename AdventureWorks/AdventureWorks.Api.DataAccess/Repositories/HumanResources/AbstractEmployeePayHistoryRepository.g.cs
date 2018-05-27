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
	public abstract class AbstractEmployeePayHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALEmployeePayHistoryMapper Mapper { get; }

		public AbstractEmployeePayHistoryRepository(
			IDALEmployeePayHistoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOEmployeePayHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOEmployeePayHistory> Get(int businessEntityID)
		{
			EmployeePayHistory record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOEmployeePayHistory> Create(
			DTOEmployeePayHistory dto)
		{
			EmployeePayHistory record = new EmployeePayHistory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<EmployeePayHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOEmployeePayHistory dto)
		{
			EmployeePayHistory record = await this.GetById(businessEntityID);

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
			EmployeePayHistory record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmployeePayHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOEmployeePayHistory>> Where(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmployeePayHistory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOEmployeePayHistory>> SearchLinqDTO(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmployeePayHistory> response = new List<DTOEmployeePayHistory>();
			List<EmployeePayHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<EmployeePayHistory>> SearchLinqEF(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeePayHistory.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeePayHistory>();
		}

		private async Task<List<EmployeePayHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeePayHistory.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmployeePayHistory>();
		}

		private async Task<EmployeePayHistory> GetById(int businessEntityID)
		{
			List<EmployeePayHistory> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4d575e7ee38d033e49409667d92711b7</Hash>
</Codenesium>*/
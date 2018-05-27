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
	public abstract class AbstractSalesOrderHeaderRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALSalesOrderHeaderMapper Mapper { get; }

		public AbstractSalesOrderHeaderRepository(
			IDALSalesOrderHeaderMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOSalesOrderHeader>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOSalesOrderHeader> Get(int salesOrderID)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOSalesOrderHeader> Create(
			DTOSalesOrderHeader dto)
		{
			SalesOrderHeader record = new SalesOrderHeader();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<SalesOrderHeader>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int salesOrderID,
			DTOSalesOrderHeader dto)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					salesOrderID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeader>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOSalesOrderHeader> GetSalesOrderNumber(string salesOrderNumber)
		{
			var records = await this.SearchLinqDTO(x => x.SalesOrderNumber == salesOrderNumber);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOSalesOrderHeader>> GetCustomerID(int customerID)
		{
			var records = await this.SearchLinqDTO(x => x.CustomerID == customerID);

			return records;
		}
		public async Task<List<DTOSalesOrderHeader>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			var records = await this.SearchLinqDTO(x => x.SalesPersonID == salesPersonID);

			return records;
		}

		protected async Task<List<DTOSalesOrderHeader>> Where(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesOrderHeader> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOSalesOrderHeader>> SearchLinqDTO(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOSalesOrderHeader> response = new List<DTOSalesOrderHeader>();
			List<SalesOrderHeader> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<SalesOrderHeader>> SearchLinqEF(Expression<Func<SalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
			}
			return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeader>();
		}

		private async Task<List<SalesOrderHeader>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesOrderHeader.SalesOrderID)} ASC";
			}

			return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SalesOrderHeader>();
		}

		private async Task<SalesOrderHeader> GetById(int salesOrderID)
		{
			List<SalesOrderHeader> records = await this.SearchLinqEF(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>543df24c4a5daa5a7747791c018d10e2</Hash>
</Codenesium>*/
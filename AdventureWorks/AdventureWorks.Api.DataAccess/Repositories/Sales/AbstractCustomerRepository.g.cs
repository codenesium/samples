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
	public abstract class AbstractCustomerRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALCustomerMapper Mapper { get; }

		public AbstractCustomerRepository(
			IDALCustomerMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCustomer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCustomer> Get(int customerID)
		{
			Customer record = await this.GetById(customerID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCustomer> Create(
			DTOCustomer dto)
		{
			Customer record = new Customer();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Customer>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int customerID,
			DTOCustomer dto)
		{
			Customer record = await this.GetById(customerID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{customerID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					customerID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int customerID)
		{
			Customer record = await this.GetById(customerID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Customer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOCustomer> GetAccountNumber(string accountNumber)
		{
			var records = await this.SearchLinqDTO(x => x.AccountNumber == accountNumber);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOCustomer>> GetTerritoryID(Nullable<int> territoryID)
		{
			var records = await this.SearchLinqDTO(x => x.TerritoryID == territoryID);

			return records;
		}

		protected async Task<List<DTOCustomer>> Where(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCustomer> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCustomer>> SearchLinqDTO(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCustomer> response = new List<DTOCustomer>();
			List<Customer> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<Customer>> SearchLinqEF(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Customer.CustomerID)} ASC";
			}
			return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Customer>();
		}

		private async Task<List<Customer>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Customer.CustomerID)} ASC";
			}

			return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Customer>();
		}

		private async Task<Customer> GetById(int customerID)
		{
			List<Customer> records = await this.SearchLinqEF(x => x.CustomerID == customerID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>92a791cbd51eabb138dee439e72761e6</Hash>
</Codenesium>*/
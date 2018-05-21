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
	public abstract class AbstractAddressRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOAddress> Get(int addressID)
		{
			Address record = await this.GetById(addressID);

			return this.Mapper.AddressMapEFToPOCO(record);
		}

		public async virtual Task<POCOAddress> Create(
			ApiAddressModel model)
		{
			Address record = new Address();

			this.Mapper.AddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Address>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.AddressMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int addressID,
			ApiAddressModel model)
		{
			Address record = await this.GetById(addressID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressID}");
			}
			else
			{
				this.Mapper.AddressMapModelToEF(
					addressID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int addressID)
		{
			Address record = await this.GetById(addressID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Address>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOAddress> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			var records = await this.SearchLinqPOCO(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.City == city && x.StateProvinceID == stateProvinceID && x.PostalCode == postalCode);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOAddress>> GetStateProvinceID(int stateProvinceID)
		{
			var records = await this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID);

			return records;
		}

		protected async Task<List<POCOAddress>> Where(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddress> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOAddress>> SearchLinqPOCO(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddress> response = new List<POCOAddress>();
			List<Address> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.AddressMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Address>> SearchLinqEF(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Address.AddressID)} ASC";
			}
			return await this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Address>();
		}

		private async Task<List<Address>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Address.AddressID)} ASC";
			}

			return await this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Address>();
		}

		private async Task<Address> GetById(int addressID)
		{
			List<Address> records = await this.SearchLinqEF(x => x.AddressID == addressID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>36223d667a65fbdb1448fe280626b39c</Hash>
</Codenesium>*/
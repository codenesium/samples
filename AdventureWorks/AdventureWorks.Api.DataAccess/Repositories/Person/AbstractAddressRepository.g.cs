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
		protected IDALAddressMapper Mapper { get; }

		public AbstractAddressRepository(
			IDALAddressMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOAddress> Get(int addressID)
		{
			Address record = await this.GetById(addressID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOAddress> Create(
			DTOAddress dto)
		{
			Address record = new Address();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<Address>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int addressID,
			DTOAddress dto)
		{
			Address record = await this.GetById(addressID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					addressID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOAddress> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			var records = await this.SearchLinqDTO(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.City == city && x.StateProvinceID == stateProvinceID && x.PostalCode == postalCode);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOAddress>> GetStateProvinceID(int stateProvinceID)
		{
			var records = await this.SearchLinqDTO(x => x.StateProvinceID == stateProvinceID);

			return records;
		}

		protected async Task<List<DTOAddress>> Where(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAddress> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOAddress>> SearchLinqDTO(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAddress> response = new List<DTOAddress>();
			List<Address> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>4fc2a294d7f4e08a089f782e7d9fb1fc</Hash>
</Codenesium>*/
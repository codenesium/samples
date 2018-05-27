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
	public abstract class AbstractBusinessEntityAddressRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALBusinessEntityAddressMapper Mapper { get; }

		public AbstractBusinessEntityAddressRepository(
			IDALBusinessEntityAddressMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOBusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOBusinessEntityAddress> Get(int businessEntityID)
		{
			BusinessEntityAddress record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOBusinessEntityAddress> Create(
			DTOBusinessEntityAddress dto)
		{
			BusinessEntityAddress record = new BusinessEntityAddress();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<BusinessEntityAddress>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOBusinessEntityAddress dto)
		{
			BusinessEntityAddress record = await this.GetById(businessEntityID);

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
			BusinessEntityAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntityAddress>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOBusinessEntityAddress>> GetAddressID(int addressID)
		{
			var records = await this.SearchLinqDTO(x => x.AddressID == addressID);

			return records;
		}
		public async Task<List<DTOBusinessEntityAddress>> GetAddressTypeID(int addressTypeID)
		{
			var records = await this.SearchLinqDTO(x => x.AddressTypeID == addressTypeID);

			return records;
		}

		protected async Task<List<DTOBusinessEntityAddress>> Where(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBusinessEntityAddress> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOBusinessEntityAddress>> SearchLinqDTO(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBusinessEntityAddress> response = new List<DTOBusinessEntityAddress>();
			List<BusinessEntityAddress> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<BusinessEntityAddress>> SearchLinqEF(Expression<Func<BusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityAddress>();
		}

		private async Task<List<BusinessEntityAddress>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityAddress.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<BusinessEntityAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityAddress>();
		}

		private async Task<BusinessEntityAddress> GetById(int businessEntityID)
		{
			List<BusinessEntityAddress> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9211930bb0ad31612dac02e803437d8b</Hash>
</Codenesium>*/
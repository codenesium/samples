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
	public abstract class AbstractAddressTypeRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALAddressTypeMapper Mapper { get; }

		public AbstractAddressTypeRepository(
			IDALAddressTypeMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOAddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOAddressType> Get(int addressTypeID)
		{
			AddressType record = await this.GetById(addressTypeID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOAddressType> Create(
			DTOAddressType dto)
		{
			AddressType record = new AddressType();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<AddressType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int addressTypeID,
			DTOAddressType dto)
		{
			AddressType record = await this.GetById(addressTypeID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressTypeID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					addressTypeID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int addressTypeID)
		{
			AddressType record = await this.GetById(addressTypeID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<AddressType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOAddressType> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOAddressType>> Where(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAddressType> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOAddressType>> SearchLinqDTO(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOAddressType> response = new List<DTOAddressType>();
			List<AddressType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<AddressType>> SearchLinqEF(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AddressType.AddressTypeID)} ASC";
			}
			return await this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AddressType>();
		}

		private async Task<List<AddressType>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(AddressType.AddressTypeID)} ASC";
			}

			return await this.Context.Set<AddressType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<AddressType>();
		}

		private async Task<AddressType> GetById(int addressTypeID)
		{
			List<AddressType> records = await this.SearchLinqEF(x => x.AddressTypeID == addressTypeID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>89b1f027c01ba88f5beb691ad875e996</Hash>
</Codenesium>*/
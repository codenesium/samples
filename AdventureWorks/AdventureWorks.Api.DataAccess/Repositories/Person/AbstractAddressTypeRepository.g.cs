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
		protected IObjectMapper Mapper { get; }

		public AbstractAddressTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOAddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOAddressType> Get(int addressTypeID)
		{
			AddressType record = await this.GetById(addressTypeID);

			return this.Mapper.AddressTypeMapEFToPOCO(record);
		}

		public async virtual Task<POCOAddressType> Create(
			ApiAddressTypeModel model)
		{
			AddressType record = new AddressType();

			this.Mapper.AddressTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<AddressType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.AddressTypeMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int addressTypeID,
			ApiAddressTypeModel model)
		{
			AddressType record = await this.GetById(addressTypeID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressTypeID}");
			}
			else
			{
				this.Mapper.AddressTypeMapModelToEF(
					addressTypeID,
					model,
					record);
				this.Context.SaveChangesAsync();
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

		public async Task<POCOAddressType> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOAddressType>> Where(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddressType> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOAddressType>> SearchLinqPOCO(Expression<Func<AddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddressType> response = new List<POCOAddressType>();
			List<AddressType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.AddressTypeMapEFToPOCO(x)));
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
    <Hash>ee36a9b7e1c6883bb85b44edc11aa0d2</Hash>
</Codenesium>*/
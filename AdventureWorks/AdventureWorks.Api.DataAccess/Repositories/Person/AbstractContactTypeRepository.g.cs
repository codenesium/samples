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
	public abstract class AbstractContactTypeRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractContactTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOContactType> Get(int contactTypeID)
		{
			ContactType record = await this.GetById(contactTypeID);

			return this.Mapper.ContactTypeMapEFToPOCO(record);
		}

		public async virtual Task<POCOContactType> Create(
			ApiContactTypeModel model)
		{
			ContactType record = new ContactType();

			this.Mapper.ContactTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ContactType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ContactTypeMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int contactTypeID,
			ApiContactTypeModel model)
		{
			ContactType record = await this.GetById(contactTypeID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{contactTypeID}");
			}
			else
			{
				this.Mapper.ContactTypeMapModelToEF(
					contactTypeID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int contactTypeID)
		{
			ContactType record = await this.GetById(contactTypeID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ContactType>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOContactType> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOContactType>> Where(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOContactType> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOContactType>> SearchLinqPOCO(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOContactType> response = new List<POCOContactType>();
			List<ContactType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ContactTypeMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ContactType>> SearchLinqEF(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ContactType.ContactTypeID)} ASC";
			}
			return await this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ContactType>();
		}

		private async Task<List<ContactType>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ContactType.ContactTypeID)} ASC";
			}

			return await this.Context.Set<ContactType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ContactType>();
		}

		private async Task<ContactType> GetById(int contactTypeID)
		{
			List<ContactType> records = await this.SearchLinqEF(x => x.ContactTypeID == contactTypeID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>aacceab9f6cd32766072a9bb7f24f174</Hash>
</Codenesium>*/
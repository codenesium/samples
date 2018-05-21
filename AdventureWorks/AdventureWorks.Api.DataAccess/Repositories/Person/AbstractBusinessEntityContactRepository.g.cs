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
	public abstract class AbstractBusinessEntityContactRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityContactRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOBusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOBusinessEntityContact> Get(int businessEntityID)
		{
			BusinessEntityContact record = await this.GetById(businessEntityID);

			return this.Mapper.BusinessEntityContactMapEFToPOCO(record);
		}

		public async virtual Task<POCOBusinessEntityContact> Create(
			ApiBusinessEntityContactModel model)
		{
			BusinessEntityContact record = new BusinessEntityContact();

			this.Mapper.BusinessEntityContactMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BusinessEntityContact>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.BusinessEntityContactMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiBusinessEntityContactModel model)
		{
			BusinessEntityContact record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityContactMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			BusinessEntityContact record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BusinessEntityContact>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOBusinessEntityContact>> GetContactTypeID(int contactTypeID)
		{
			var records = await this.SearchLinqPOCO(x => x.ContactTypeID == contactTypeID);

			return records;
		}
		public async Task<List<POCOBusinessEntityContact>> GetPersonID(int personID)
		{
			var records = await this.SearchLinqPOCO(x => x.PersonID == personID);

			return records;
		}

		protected async Task<List<POCOBusinessEntityContact>> Where(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntityContact> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOBusinessEntityContact>> SearchLinqPOCO(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBusinessEntityContact> response = new List<POCOBusinessEntityContact>();
			List<BusinessEntityContact> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.BusinessEntityContactMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<BusinessEntityContact>> SearchLinqEF(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityContact.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityContact>();
		}

		private async Task<List<BusinessEntityContact>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BusinessEntityContact.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<BusinessEntityContact>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BusinessEntityContact>();
		}

		private async Task<BusinessEntityContact> GetById(int businessEntityID)
		{
			List<BusinessEntityContact> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6af14a702c844fd8fb4aca690c282f87</Hash>
</Codenesium>*/
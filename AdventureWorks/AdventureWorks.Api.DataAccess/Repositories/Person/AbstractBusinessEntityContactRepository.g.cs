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
		protected IDALBusinessEntityContactMapper Mapper { get; }

		public AbstractBusinessEntityContactRepository(
			IDALBusinessEntityContactMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOBusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOBusinessEntityContact> Get(int businessEntityID)
		{
			BusinessEntityContact record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOBusinessEntityContact> Create(
			DTOBusinessEntityContact dto)
		{
			BusinessEntityContact record = new BusinessEntityContact();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<BusinessEntityContact>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOBusinessEntityContact dto)
		{
			BusinessEntityContact record = await this.GetById(businessEntityID);

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

		public async Task<List<DTOBusinessEntityContact>> GetContactTypeID(int contactTypeID)
		{
			var records = await this.SearchLinqDTO(x => x.ContactTypeID == contactTypeID);

			return records;
		}
		public async Task<List<DTOBusinessEntityContact>> GetPersonID(int personID)
		{
			var records = await this.SearchLinqDTO(x => x.PersonID == personID);

			return records;
		}

		protected async Task<List<DTOBusinessEntityContact>> Where(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBusinessEntityContact> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOBusinessEntityContact>> SearchLinqDTO(Expression<Func<BusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBusinessEntityContact> response = new List<DTOBusinessEntityContact>();
			List<BusinessEntityContact> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>659ac99e7750a029cdce0cc57eaca0e6</Hash>
</Codenesium>*/
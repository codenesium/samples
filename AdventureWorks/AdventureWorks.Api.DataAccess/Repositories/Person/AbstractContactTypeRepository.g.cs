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
		protected IDALContactTypeMapper Mapper { get; }

		public AbstractContactTypeRepository(
			IDALContactTypeMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOContactType> Get(int contactTypeID)
		{
			ContactType record = await this.GetById(contactTypeID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOContactType> Create(
			DTOContactType dto)
		{
			ContactType record = new ContactType();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ContactType>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int contactTypeID,
			DTOContactType dto)
		{
			ContactType record = await this.GetById(contactTypeID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{contactTypeID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					contactTypeID,
					dto,
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

		public async Task<DTOContactType> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOContactType>> Where(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOContactType> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOContactType>> SearchLinqDTO(Expression<Func<ContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOContactType> response = new List<DTOContactType>();
			List<ContactType> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>5edcb305dfa75bdef7a5cbe7a5b115ae</Hash>
</Codenesium>*/
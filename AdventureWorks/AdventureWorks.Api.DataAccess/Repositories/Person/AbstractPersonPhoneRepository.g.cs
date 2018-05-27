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
	public abstract class AbstractPersonPhoneRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALPersonPhoneMapper Mapper { get; }

		public AbstractPersonPhoneRepository(
			IDALPersonPhoneMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOPersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOPersonPhone> Get(int businessEntityID)
		{
			PersonPhone record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOPersonPhone> Create(
			DTOPersonPhone dto)
		{
			PersonPhone record = new PersonPhone();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<PersonPhone>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOPersonPhone dto)
		{
			PersonPhone record = await this.GetById(businessEntityID);

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
			PersonPhone record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonPhone>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOPersonPhone>> GetPhoneNumber(string phoneNumber)
		{
			var records = await this.SearchLinqDTO(x => x.PhoneNumber == phoneNumber);

			return records;
		}

		protected async Task<List<DTOPersonPhone>> Where(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPersonPhone> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOPersonPhone>> SearchLinqDTO(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPersonPhone> response = new List<DTOPersonPhone>();
			List<PersonPhone> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<PersonPhone>> SearchLinqEF(Expression<Func<PersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonPhone>();
		}

		private async Task<List<PersonPhone>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonPhone.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<PersonPhone>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonPhone>();
		}

		private async Task<PersonPhone> GetById(int businessEntityID)
		{
			List<PersonPhone> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>da8dbea9677960a799d8d9444280c6c3</Hash>
</Codenesium>*/
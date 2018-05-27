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
	public abstract class AbstractEmailAddressRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALEmailAddressMapper Mapper { get; }

		public AbstractEmailAddressRepository(
			IDALEmailAddressMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOEmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOEmailAddress> Get(int businessEntityID)
		{
			EmailAddress record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOEmailAddress> Create(
			DTOEmailAddress dto)
		{
			EmailAddress record = new EmailAddress();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<EmailAddress>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOEmailAddress dto)
		{
			EmailAddress record = await this.GetById(businessEntityID);

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
			EmailAddress record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmailAddress>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOEmailAddress>> GetEmailAddress(string emailAddress1)
		{
			var records = await this.SearchLinqDTO(x => x.EmailAddress1 == emailAddress1);

			return records;
		}

		protected async Task<List<DTOEmailAddress>> Where(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmailAddress> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOEmailAddress>> SearchLinqDTO(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOEmailAddress> response = new List<DTOEmailAddress>();
			List<EmailAddress> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<EmailAddress>> SearchLinqEF(Expression<Func<EmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmailAddress>();
		}

		private async Task<List<EmailAddress>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmailAddress.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<EmailAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<EmailAddress>();
		}

		private async Task<EmailAddress> GetById(int businessEntityID)
		{
			List<EmailAddress> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>43df613b9df50ba2d021c26b331cf6b0</Hash>
</Codenesium>*/
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
	public abstract class AbstractPasswordRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPasswordRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPassword>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPassword> Get(int businessEntityID)
		{
			Password record = await this.GetById(businessEntityID);

			return this.Mapper.PasswordMapEFToPOCO(record);
		}

		public async virtual Task<POCOPassword> Create(
			ApiPasswordModel model)
		{
			Password record = new Password();

			this.Mapper.PasswordMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Password>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PasswordMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiPasswordModel model)
		{
			Password record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.PasswordMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			Password record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Password>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPassword>> Where(Expression<Func<Password, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPassword> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPassword>> SearchLinqPOCO(Expression<Func<Password, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPassword> response = new List<POCOPassword>();
			List<Password> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PasswordMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Password>> SearchLinqEF(Expression<Func<Password, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Password.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<Password>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Password>();
		}

		private async Task<List<Password>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Password.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<Password>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Password>();
		}

		private async Task<Password> GetById(int businessEntityID)
		{
			List<Password> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0cab518a9a947e02e380e0df56dbb7bc</Hash>
</Codenesium>*/
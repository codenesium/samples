using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractPasswordRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPasswordRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPassword> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPassword Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOPassword Create(
			ApiPasswordModel model)
		{
			Password record = new Password();

			this.Mapper.PasswordMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Password>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PasswordMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiPasswordModel model)
		{
			Password record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			Password record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Password>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPassword> Where(Expression<Func<Password, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPassword> SearchLinqPOCO(Expression<Func<Password, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPassword> response = new List<POCOPassword>();
			List<Password> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PasswordMapEFToPOCO(x)));
			return response;
		}

		private List<Password> SearchLinqEF(Expression<Func<Password, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Password.BusinessEntityID)} ASC";
			}
			return this.Context.Set<Password>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Password>();
		}

		private List<Password> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Password.BusinessEntityID)} ASC";
			}

			return this.Context.Set<Password>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Password>();
		}
	}
}

/*<Codenesium>
    <Hash>25843d71e325b03bf6cab8b6a3560bd7</Hash>
</Codenesium>*/
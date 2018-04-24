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

		public virtual int Create(
			PasswordModel model)
		{
			EFPassword record = new EFPassword();

			this.Mapper.PasswordMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFPassword>().Add(record);
			this.Context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			PasswordModel model)
		{
			EFPassword record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
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
			EFPassword record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFPassword>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}

		public virtual POCOPassword GetByIdDirect(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).Passwords.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPassword> GetWhereDirect(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Passwords;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFPassword> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.PasswordMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFPassword> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.PasswordMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFPassword> SearchLinqEF(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPassword> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>3fe87ea4593cff89f597216016c714e6</Hash>
</Codenesium>*/
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
	public abstract class AbstractBusinessEntityContactRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityContactRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			BusinessEntityContactModel model)
		{
			EFBusinessEntityContact record = new EFBusinessEntityContact();

			this.Mapper.BusinessEntityContactMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFBusinessEntityContact>().Add(record);
			this.Context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			BusinessEntityContactModel model)
		{
			EFBusinessEntityContact record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EFBusinessEntityContact record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFBusinessEntityContact>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}

		public virtual POCOBusinessEntityContact GetByIdDirect(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).BusinessEntityContacts.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBusinessEntityContact> GetWhereDirect(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).BusinessEntityContacts;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFBusinessEntityContact> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.BusinessEntityContactMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFBusinessEntityContact> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.BusinessEntityContactMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFBusinessEntityContact> SearchLinqEF(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBusinessEntityContact> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>d7cb1d9780f5c54d83f2cd1219974bfd</Hash>
</Codenesium>*/
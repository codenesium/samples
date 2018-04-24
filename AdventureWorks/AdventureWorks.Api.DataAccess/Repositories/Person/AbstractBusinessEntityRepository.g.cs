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
	public abstract class AbstractBusinessEntityRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBusinessEntityRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			BusinessEntityModel model)
		{
			EFBusinessEntity record = new EFBusinessEntity();

			this.Mapper.BusinessEntityMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFBusinessEntity>().Add(record);
			this.Context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			BusinessEntityModel model)
		{
			EFBusinessEntity record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.BusinessEntityMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EFBusinessEntity record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFBusinessEntity>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}

		public virtual POCOBusinessEntity GetByIdDirect(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).BusinessEntities.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBusinessEntity> GetWhereDirect(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).BusinessEntities;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFBusinessEntity> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.BusinessEntityMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFBusinessEntity> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.BusinessEntityMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFBusinessEntity> SearchLinqEF(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBusinessEntity> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>d914f5072b47c003ac6e6367246b64bf</Hash>
</Codenesium>*/
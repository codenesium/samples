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
	public abstract class AbstractProductDescriptionRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductDescriptionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductDescriptionModel model)
		{
			EFProductDescription record = new EFProductDescription();

			this.Mapper.ProductDescriptionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductDescription>().Add(record);
			this.Context.SaveChanges();
			return record.ProductDescriptionID;
		}

		public virtual void Update(
			int productDescriptionID,
			ProductDescriptionModel model)
		{
			EFProductDescription record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productDescriptionID}");
			}
			else
			{
				this.Mapper.ProductDescriptionMapModelToEF(
					productDescriptionID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productDescriptionID)
		{
			EFProductDescription record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductDescription>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productDescriptionID)
		{
			return this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID);
		}

		public virtual POCOProductDescription GetByIdDirect(int productDescriptionID)
		{
			return this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID).ProductDescriptions.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductDescriptions;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductDescription> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductDescriptionMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductDescription> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductDescriptionMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductDescription> SearchLinqEF(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductDescription> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>b82ac0c9ccf39069d5be7202d23fd55c</Hash>
</Codenesium>*/
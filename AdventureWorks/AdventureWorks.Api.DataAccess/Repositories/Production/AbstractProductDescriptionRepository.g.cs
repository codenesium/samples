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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductDescriptionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductDescriptionModel model)
		{
			var record = new EFProductDescription();

			this.mapper.ProductDescriptionMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductDescription>().Add(record);
			this.context.SaveChanges();
			return record.ProductDescriptionID;
		}

		public virtual void Update(
			int productDescriptionID,
			ProductDescriptionModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productDescriptionID}");
			}
			else
			{
				this.mapper.ProductDescriptionMapModelToEF(
					productDescriptionID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productDescriptionID)
		{
			var record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductDescription>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productDescriptionID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID, response);
			return response;
		}

		public virtual POCOProductDescription GetByIdDirect(int productDescriptionID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID, response);
			return response.ProductDescriptions.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductDescriptions;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductDescription, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductDescription> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductDescriptionMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductDescription> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductDescriptionMapEFToPOCO(x, response));
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
    <Hash>caeb77795714a0f1eec696e5b1626b7a</Hash>
</Codenesium>*/
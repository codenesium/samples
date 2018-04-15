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
	public abstract class AbstractProductInventoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductInventoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductInventoryModel model)
		{
			var record = new EFProductInventory();

			this.mapper.ProductInventoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductInventory>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductInventoryModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productID}");
			}
			else
			{
				this.mapper.ProductInventoryMapModelToEF(
					productID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductInventory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response;
		}

		public virtual POCOProductInventory GetByIdDirect(int productID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response.ProductInventories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductInventories;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductInventory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductInventory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductInventoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductInventory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductInventoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductInventory> SearchLinqEF(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductInventory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>5ced2382d1bde26e6a128477c519bd12</Hash>
</Codenesium>*/
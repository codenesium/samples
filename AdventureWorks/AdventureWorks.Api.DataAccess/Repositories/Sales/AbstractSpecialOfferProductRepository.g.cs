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
	public abstract class AbstractSpecialOfferProductRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSpecialOfferProductRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SpecialOfferProductModel model)
		{
			var record = new EFSpecialOfferProduct();

			this.mapper.SpecialOfferProductMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSpecialOfferProduct>().Add(record);
			this.context.SaveChanges();
			return record.SpecialOfferID;
		}

		public virtual void Update(
			int specialOfferID,
			SpecialOfferProductModel model)
		{
			var record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.mapper.SpecialOfferProductMapModelToEF(
					specialOfferID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int specialOfferID)
		{
			var record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSpecialOfferProduct>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int specialOfferID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID, response);
			return response;
		}

		public virtual POCOSpecialOfferProduct GetByIdDirect(int specialOfferID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID, response);
			return response.SpecialOfferProducts.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSpecialOfferProduct> GetWhereDirect(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SpecialOfferProducts;
		}

		private void SearchLinqPOCO(Expression<Func<EFSpecialOfferProduct, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSpecialOfferProduct> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SpecialOfferProductMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSpecialOfferProduct> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SpecialOfferProductMapEFToPOCO(x, response));
		}

		protected virtual List<EFSpecialOfferProduct> SearchLinqEF(Expression<Func<EFSpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpecialOfferProduct> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>0fdf1c4fe5b28223bc914a1b592a1863</Hash>
</Codenesium>*/
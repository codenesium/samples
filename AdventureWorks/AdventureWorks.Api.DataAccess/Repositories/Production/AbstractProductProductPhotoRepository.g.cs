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
	public abstract class AbstractProductProductPhotoRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductProductPhotoModel model)
		{
			EFProductProductPhoto record = new EFProductProductPhoto();

			this.Mapper.ProductProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductProductPhoto>().Add(record);
			this.Context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductProductPhotoModel model)
		{
			EFProductProductPhoto record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductProductPhotoMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			EFProductProductPhoto record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductProductPhoto>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		public virtual POCOProductProductPhoto GetByIdDirect(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).ProductProductPhotoes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductProductPhoto> GetWhereDirect(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductProductPhotoes;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductProductPhotoMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductProductPhoto> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductProductPhotoMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductProductPhoto> SearchLinqEF(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>675cad628a443d255adba90133400387</Hash>
</Codenesium>*/
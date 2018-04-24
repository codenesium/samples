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
	public abstract class AbstractProductPhotoRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductPhotoModel model)
		{
			EFProductPhoto record = new EFProductPhoto();

			this.Mapper.ProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductPhoto>().Add(record);
			this.Context.SaveChanges();
			return record.ProductPhotoID;
		}

		public virtual void Update(
			int productPhotoID,
			ProductPhotoModel model)
		{
			EFProductPhoto record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productPhotoID}");
			}
			else
			{
				this.Mapper.ProductPhotoMapModelToEF(
					productPhotoID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productPhotoID)
		{
			EFProductPhoto record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductPhoto>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productPhotoID)
		{
			return this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID);
		}

		public virtual POCOProductPhoto GetByIdDirect(int productPhotoID)
		{
			return this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID).ProductPhotoes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductPhotoes;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductPhotoMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductPhoto> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductPhotoMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>4f6963540a4f6bd690a23e3a89cf2c07</Hash>
</Codenesium>*/
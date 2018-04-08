using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractFileTypeRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractFileTypeRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name)
		{
			var record = new EFFileType ();

			MapPOCOToEF(0, name, record);

			this.context.Set<EFFileType>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, string name)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFFileType>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFFileType> SearchLinqEF(Expression<Func<EFFileType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFFileType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFFileType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOFileType> GetWhereDirect(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.FileTypes;
		}
		public virtual POCOFileType GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.FileTypes.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFFileType, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFFileType> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFFileType> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name, EFFileType   efFileType)
		{
			efFileType.Id = id;
			efFileType.Name = name;
		}

		public static void MapEFToPOCO(EFFileType efFileType,Response response)
		{
			if(efFileType == null)
			{
				return;
			}
			response.AddFileType(new POCOFileType()
			{
				Id = efFileType.Id.ToInt(),
				Name = efFileType.Name,
			});
		}
	}
}

/*<Codenesium>
    <Hash>f3495e447e2a149a46335e88f0e75dc4</Hash>
</Codenesium>*/
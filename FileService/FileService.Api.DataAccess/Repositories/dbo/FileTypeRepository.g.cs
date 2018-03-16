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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractFileTypeRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name)
		{
			var record = new FileType ();

			MapPOCOToEF(0, name, record);

			this._context.Set<FileType>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, string name)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<FileType>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<FileType> SearchLinqEF(Expression<Func<FileType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<FileType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<FileType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<FileType, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<FileType> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<FileType> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name, FileType   efFileType)
		{
			efFileType.id = id;
			efFileType.name = name;
		}

		public static void MapEFToPOCO(FileType efFileType,Response response)
		{
			if(efFileType == null)
			{
				return;
			}
			response.AddFileType(new POCOFileType()
			{
				Id = efFileType.id.ToInt(),
				Name = efFileType.name,
			});
		}
	}
}

/*<Codenesium>
    <Hash>9ec42248ba42e70dc01d645e0ef3b8b1</Hash>
</Codenesium>*/
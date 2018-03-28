using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractLinkLogRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractLinkLogRepository(ILogger logger,
		                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int linkId,
		                          string log,
		                          DateTime dateEntered)
		{
			var record = new EFLinkLog ();

			MapPOCOToEF(0, linkId,
			            log,
			            dateEntered, record);

			this._context.Set<EFLinkLog>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, int linkId,
		                           string log,
		                           DateTime dateEntered)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  linkId,
				            log,
				            dateEntered, record);
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
				this._context.Set<EFLinkLog>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<EFLinkLog> SearchLinqEF(Expression<Func<EFLinkLog, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLinkLog> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFLinkLog, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFLinkLog, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFLinkLog> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFLinkLog> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, int linkId,
		                               string log,
		                               DateTime dateEntered, EFLinkLog   efLinkLog)
		{
			efLinkLog.id = id;
			efLinkLog.linkId = linkId;
			efLinkLog.log = log;
			efLinkLog.dateEntered = dateEntered;
		}

		public static void MapEFToPOCO(EFLinkLog efLinkLog,Response response)
		{
			if(efLinkLog == null)
			{
				return;
			}
			response.AddLinkLog(new POCOLinkLog()
			{
				Id = efLinkLog.id.ToInt(),
				Log = efLinkLog.log,
				DateEntered = efLinkLog.dateEntered.ToDateTime(),

				LinkId = new ReferenceEntity<int>(efLinkLog.linkId,
				                                  "Links"),
			});

			LinkRepository.MapEFToPOCO(efLinkLog.LinkRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>d7e7c5e41be596b2e95c9d33d7a2959f</Hash>
</Codenesium>*/
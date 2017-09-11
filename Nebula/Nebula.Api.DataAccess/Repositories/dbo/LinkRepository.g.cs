using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractLinkRepository
	{
		protected DbContext _context;
		protected ILogger _logger;

		public AbstractLinkRepository(ILogger logger,
		                              DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Nullable<int> assignedMachineId,
		                          int chainId,
		                          Nullable<DateTime> dateCompleted,
		                          Nullable<DateTime> dateStarted,
		                          string dynamicParameters,
		                          Guid externalId,
		                          int id,
		                          int linkStatusId,
		                          string name,
		                          int order,
		                          string response,
		                          string staticParameters)
		{
			var record = new Link ();

			MapPOCOToEF(assignedMachineId,
			            chainId,
			            dateCompleted,
			            dateStarted,
			            dynamicParameters,
			            externalId,
			            id,
			            linkStatusId,
			            name,
			            order,
			            response,
			            staticParameters, record);

			this._context.Set<Link>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(Nullable<int> assignedMachineId,
		                           int chainId,
		                           Nullable<DateTime> dateCompleted,
		                           Nullable<DateTime> dateStarted,
		                           string dynamicParameters,
		                           Guid externalId,
		                           int id,
		                           int linkStatusId,
		                           string name,
		                           int order,
		                           string response,
		                           string staticParameters)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(assignedMachineId,
				            chainId,
				            dateCompleted,
				            dateStarted,
				            dynamicParameters,
				            externalId,
				            id,
				            linkStatusId,
				            name,
				            order,
				            response,
				            staticParameters, record);
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
				this._context.Set<Link>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Link> SearchLinqEF(Expression<Func<Link, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Link> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Link, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Link, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Link> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Link> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(Nullable<int> assignedMachineId,
		                               int chainId,
		                               Nullable<DateTime> dateCompleted,
		                               Nullable<DateTime> dateStarted,
		                               string dynamicParameters,
		                               Guid externalId,
		                               int id,
		                               int linkStatusId,
		                               string name,
		                               int order,
		                               string response,
		                               string staticParameters, Link   efLink)
		{
			efLink.assignedMachineId = assignedMachineId;
			efLink.chainId = chainId;
			efLink.dateCompleted = dateCompleted;
			efLink.dateStarted = dateStarted;
			efLink.dynamicParameters = dynamicParameters;
			efLink.externalId = externalId;
			efLink.id = id;
			efLink.linkStatusId = linkStatusId;
			efLink.name = name;
			efLink.order = order;
			efLink.response = response;
			efLink.staticParameters = staticParameters;
		}

		public static void MapEFToPOCO(Link efLink,Response response)
		{
			if(efLink == null)
			{
				return;
			}
			response.AddLink(new POCOLink()
			{
				DateCompleted = efLink.dateCompleted.ToNullableDateTime(),
				DateStarted = efLink.dateStarted.ToNullableDateTime(),
				DynamicParameters = efLink.dynamicParameters,
				ExternalId = efLink.externalId,
				Id = efLink.id.ToInt(),
				Name = efLink.name,
				Order = efLink.order.ToInt(),
				Response = efLink.response,
				StaticParameters = efLink.staticParameters,

				AssignedMachineId = new ReferenceEntity<Nullable<int>>(efLink.assignedMachineId,
				                                                       "Machine"),
				ChainId = new ReferenceEntity<int>(efLink.chainId,
				                                   "Chain"),
				LinkStatusId = new ReferenceEntity<int>(efLink.linkStatusId,
				                                        "LinkStatus"),
			});

			MachineRepository.MapEFToPOCO(efLink.MachineRef, response);

			ChainRepository.MapEFToPOCO(efLink.ChainRef, response);

			LinkStatusRepository.MapEFToPOCO(efLink.LinkStatusRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>e78af2b9e02232d6185a065268bf02a0</Hash>
</Codenesium>*/
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractSpaceXSpaceFeatureMapper
        {
                public virtual SpaceXSpaceFeature MapBOToEF(
                        BOSpaceXSpaceFeature bo)
                {
                        SpaceXSpaceFeature efSpaceXSpaceFeature = new SpaceXSpaceFeature();

                        efSpaceXSpaceFeature.SetProperties(
                                bo.Id,
                                bo.SpaceFeatureId,
                                bo.SpaceId);
                        return efSpaceXSpaceFeature;
                }

                public virtual BOSpaceXSpaceFeature MapEFToBO(
                        SpaceXSpaceFeature ef)
                {
                        var bo = new BOSpaceXSpaceFeature();

                        bo.SetProperties(
                                ef.Id,
                                ef.SpaceFeatureId,
                                ef.SpaceId);
                        return bo;
                }

                public virtual List<BOSpaceXSpaceFeature> MapEFToBO(
                        List<SpaceXSpaceFeature> records)
                {
                        List<BOSpaceXSpaceFeature> response = new List<BOSpaceXSpaceFeature>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4ac3eaa6df43c6327b3753fc5a41a2e3</Hash>
</Codenesium>*/
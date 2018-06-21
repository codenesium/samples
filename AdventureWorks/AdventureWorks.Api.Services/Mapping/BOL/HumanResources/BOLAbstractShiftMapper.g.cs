using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractShiftMapper
        {
                public virtual BOShift MapModelToBO(
                        int shiftID,
                        ApiShiftRequestModel model
                        )
                {
                        BOShift boShift = new BOShift();
                        boShift.SetProperties(
                                shiftID,
                                model.EndTime,
                                model.ModifiedDate,
                                model.Name,
                                model.StartTime);
                        return boShift;
                }

                public virtual ApiShiftResponseModel MapBOToModel(
                        BOShift boShift)
                {
                        var model = new ApiShiftResponseModel();

                        model.SetProperties(boShift.EndTime, boShift.ModifiedDate, boShift.Name, boShift.ShiftID, boShift.StartTime);

                        return model;
                }

                public virtual List<ApiShiftResponseModel> MapBOToModel(
                        List<BOShift> items)
                {
                        List<ApiShiftResponseModel> response = new List<ApiShiftResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a91fe8d7f6399c5a6f2d9a7317f2306c</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import WorkOrderMapper from './workOrderMapper';
import WorkOrderViewModel from './workOrderViewModel';

interface Props {
  model?: WorkOrderViewModel;
}

const WorkOrderDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="dueDate" className={'col-sm-2 col-form-label'}>
          DueDate
        </label>
        <div className="col-sm-12">{String(model.model!.dueDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="endDate" className={'col-sm-2 col-form-label'}>
          EndDate
        </label>
        <div className="col-sm-12">{String(model.model!.endDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="orderQty" className={'col-sm-2 col-form-label'}>
          OrderQty
        </label>
        <div className="col-sm-12">{String(model.model!.orderQty)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="productID" className={'col-sm-2 col-form-label'}>
          ProductID
        </label>
        <div className="col-sm-12">{String(model.model!.productID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="scrappedQty" className={'col-sm-2 col-form-label'}>
          ScrappedQty
        </label>
        <div className="col-sm-12">{String(model.model!.scrappedQty)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="scrapReasonID" className={'col-sm-2 col-form-label'}>
          ScrapReasonID
        </label>
        <div className="col-sm-12">{String(model.model!.scrapReasonID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="startDate" className={'col-sm-2 col-form-label'}>
          StartDate
        </label>
        <div className="col-sm-12">{String(model.model!.startDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="stockedQty" className={'col-sm-2 col-form-label'}>
          StockedQty
        </label>
        <div className="col-sm-12">{String(model.model!.stockedQty)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="workOrderID" className={'col-sm-2 col-form-label'}>
          WorkOrderID
        </label>
        <div className="col-sm-12">{String(model.model!.workOrderID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  workOrderID: number;
}

interface IMatch {
  params: IParams;
}

interface WorkOrderDetailComponentProps {
  match: IMatch;
}

interface WorkOrderDetailComponentState {
  model?: WorkOrderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class WorkOrderDetailComponent extends React.Component<
  WorkOrderDetailComponentProps,
  WorkOrderDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiUrl + 'workorders/' + this.props.match.params.workOrderID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.WorkOrderClientResponseModel;

          let mapper = new WorkOrderMapper();

          console.log(response);

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <WorkOrderDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>8f34a067e8b986a1fad0ee41f82dcdfd</Hash>
</Codenesium>*/
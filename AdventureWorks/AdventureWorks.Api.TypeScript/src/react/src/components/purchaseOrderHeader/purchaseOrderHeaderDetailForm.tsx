import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import PurchaseOrderHeaderMapper from './purchaseOrderHeaderMapper';
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';

interface Props {
  model?: PurchaseOrderHeaderViewModel;
}

const PurchaseOrderHeaderDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="employeeID" className={'col-sm-2 col-form-label'}>
          EmployeeID
        </label>
        <div className="col-sm-12">{String(model.model!.employeeID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="freight" className={'col-sm-2 col-form-label'}>
          Freight
        </label>
        <div className="col-sm-12">{String(model.model!.freight)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="orderDate" className={'col-sm-2 col-form-label'}>
          OrderDate
        </label>
        <div className="col-sm-12">{String(model.model!.orderDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="purchaseOrderID" className={'col-sm-2 col-form-label'}>
          PurchaseOrderID
        </label>
        <div className="col-sm-12">{String(model.model!.purchaseOrderID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="revisionNumber" className={'col-sm-2 col-form-label'}>
          RevisionNumber
        </label>
        <div className="col-sm-12">{String(model.model!.revisionNumber)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="shipDate" className={'col-sm-2 col-form-label'}>
          ShipDate
        </label>
        <div className="col-sm-12">{String(model.model!.shipDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="shipMethodID" className={'col-sm-2 col-form-label'}>
          ShipMethodID
        </label>
        <div className="col-sm-12">{String(model.model!.shipMethodID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="status" className={'col-sm-2 col-form-label'}>
          Status
        </label>
        <div className="col-sm-12">{String(model.model!.status)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="subTotal" className={'col-sm-2 col-form-label'}>
          SubTotal
        </label>
        <div className="col-sm-12">{String(model.model!.subTotal)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="taxAmt" className={'col-sm-2 col-form-label'}>
          TaxAmt
        </label>
        <div className="col-sm-12">{String(model.model!.taxAmt)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="totalDue" className={'col-sm-2 col-form-label'}>
          TotalDue
        </label>
        <div className="col-sm-12">{String(model.model!.totalDue)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="vendorID" className={'col-sm-2 col-form-label'}>
          VendorID
        </label>
        <div className="col-sm-12">{String(model.model!.vendorID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  purchaseOrderID: number;
}

interface IMatch {
  params: IParams;
}

interface PurchaseOrderHeaderDetailComponentProps {
  match: IMatch;
}

interface PurchaseOrderHeaderDetailComponentState {
  model?: PurchaseOrderHeaderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PurchaseOrderHeaderDetailComponent extends React.Component<
  PurchaseOrderHeaderDetailComponentProps,
  PurchaseOrderHeaderDetailComponentState
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
        Constants.ApiUrl +
          'purchaseorderheaders/' +
          this.props.match.params.purchaseOrderID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PurchaseOrderHeaderClientResponseModel;

          let mapper = new PurchaseOrderHeaderMapper();

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
      return <PurchaseOrderHeaderDetailDisplay model={this.state.model} />;
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
    <Hash>5be4b723c13ccf1810c94f0e42edf4c1</Hash>
</Codenesium>*/
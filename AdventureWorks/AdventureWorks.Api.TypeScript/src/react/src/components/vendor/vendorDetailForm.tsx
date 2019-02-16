import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import VendorMapper from './vendorMapper';
import VendorViewModel from './vendorViewModel';

interface Props {
  model?: VendorViewModel;
}

const VendorDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="accountNumber" className={'col-sm-2 col-form-label'}>
          AccountNumber
        </label>
        <div className="col-sm-12">{String(model.model!.accountNumber)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="activeFlag" className={'col-sm-2 col-form-label'}>
          ActiveFlag
        </label>
        <div className="col-sm-12">{String(model.model!.activeFlag)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="creditRating" className={'col-sm-2 col-form-label'}>
          CreditRating
        </label>
        <div className="col-sm-12">{String(model.model!.creditRating)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="preferredVendorStatu"
          className={'col-sm-2 col-form-label'}
        >
          PreferredVendorStatus
        </label>
        <div className="col-sm-12">
          {String(model.model!.preferredVendorStatu)}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="purchasingWebServiceURL"
          className={'col-sm-2 col-form-label'}
        >
          PurchasingWebServiceURL
        </label>
        <div className="col-sm-12">
          {String(model.model!.purchasingWebServiceURL)}
        </div>
      </div>
    </form>
  );
};

interface IParams {
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface VendorDetailComponentProps {
  match: IMatch;
}

interface VendorDetailComponentState {
  model?: VendorViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class VendorDetailComponent extends React.Component<
  VendorDetailComponentProps,
  VendorDetailComponentState
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
          'vendors/' +
          this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.VendorClientResponseModel;

          let mapper = new VendorMapper();

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
      return <VendorDetailDisplay model={this.state.model} />;
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
    <Hash>7fdb932b270d510a272a69f6ad1b2f0e</Hash>
</Codenesium>*/
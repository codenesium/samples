import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import CustomerMapper from './customerMapper';
import CustomerViewModel from './customerViewModel';

interface Props {
  model?: CustomerViewModel;
}

const CustomerDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="accountNumber" className={'col-sm-2 col-form-label'}>
          AccountNumber
        </label>
        <div className="col-sm-12">{String(model.model!.accountNumber)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="customerID" className={'col-sm-2 col-form-label'}>
          CustomerID
        </label>
        <div className="col-sm-12">{String(model.model!.customerID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="personID" className={'col-sm-2 col-form-label'}>
          PersonID
        </label>
        <div className="col-sm-12">{String(model.model!.personID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="storeID" className={'col-sm-2 col-form-label'}>
          StoreID
        </label>
        <div className="col-sm-12">{String(model.model!.storeID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="territoryID" className={'col-sm-2 col-form-label'}>
          TerritoryID
        </label>
        <div className="col-sm-12">{String(model.model!.territoryID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  customerID: number;
}

interface IMatch {
  params: IParams;
}

interface CustomerDetailComponentProps {
  match: IMatch;
}

interface CustomerDetailComponentState {
  model?: CustomerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CustomerDetailComponent extends React.Component<
  CustomerDetailComponentProps,
  CustomerDetailComponentState
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
        Constants.ApiUrl + 'customers/' + this.props.match.params.customerID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CustomerClientResponseModel;

          let mapper = new CustomerMapper();

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
      return <CustomerDetailDisplay model={this.state.model} />;
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
    <Hash>21fab1567a70df565d2c5a4bc17b3d91</Hash>
</Codenesium>*/
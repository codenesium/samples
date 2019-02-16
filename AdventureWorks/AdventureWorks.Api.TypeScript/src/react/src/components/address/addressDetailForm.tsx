import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import AddressMapper from './addressMapper';
import AddressViewModel from './addressViewModel';

interface Props {
  model?: AddressViewModel;
}

const AddressDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="addressID" className={'col-sm-2 col-form-label'}>
          AddressID
        </label>
        <div className="col-sm-12">{String(model.model!.addressID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="addressLine1" className={'col-sm-2 col-form-label'}>
          AddressLine1
        </label>
        <div className="col-sm-12">{String(model.model!.addressLine1)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="addressLine2" className={'col-sm-2 col-form-label'}>
          AddressLine2
        </label>
        <div className="col-sm-12">{String(model.model!.addressLine2)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="city" className={'col-sm-2 col-form-label'}>
          City
        </label>
        <div className="col-sm-12">{String(model.model!.city)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="postalCode" className={'col-sm-2 col-form-label'}>
          PostalCode
        </label>
        <div className="col-sm-12">{String(model.model!.postalCode)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="stateProvinceID" className={'col-sm-2 col-form-label'}>
          StateProvinceID
        </label>
        <div className="col-sm-12">{String(model.model!.stateProvinceID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  addressID: number;
}

interface IMatch {
  params: IParams;
}

interface AddressDetailComponentProps {
  match: IMatch;
}

interface AddressDetailComponentState {
  model?: AddressViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class AddressDetailComponent extends React.Component<
  AddressDetailComponentProps,
  AddressDetailComponentState
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
        Constants.ApiUrl + 'addresses/' + this.props.match.params.addressID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AddressClientResponseModel;

          let mapper = new AddressMapper();

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
      return <AddressDetailDisplay model={this.state.model} />;
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
    <Hash>e5e231e25d9f12b11eaa41aefdf4361b</Hash>
</Codenesium>*/
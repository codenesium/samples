import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import StateProvinceMapper from './stateProvinceMapper';
import StateProvinceViewModel from './stateProvinceViewModel';

interface Props {
  model?: StateProvinceViewModel;
}

const StateProvinceDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label
          htmlFor="countryRegionCode"
          className={'col-sm-2 col-form-label'}
        >
          CountryRegionCode
        </label>
        <div className="col-sm-12">
          {String(model.model!.countryRegionCode)}
        </div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="isOnlyStateProvinceFlag"
          className={'col-sm-2 col-form-label'}
        >
          IsOnlyStateProvinceFlag
        </label>
        <div className="col-sm-12">
          {String(model.model!.isOnlyStateProvinceFlag)}
        </div>
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
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="stateProvinceCode"
          className={'col-sm-2 col-form-label'}
        >
          StateProvinceCode
        </label>
        <div className="col-sm-12">
          {String(model.model!.stateProvinceCode)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="stateProvinceID" className={'col-sm-2 col-form-label'}>
          StateProvinceID
        </label>
        <div className="col-sm-12">{String(model.model!.stateProvinceID)}</div>
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
  stateProvinceID: number;
}

interface IMatch {
  params: IParams;
}

interface StateProvinceDetailComponentProps {
  match: IMatch;
}

interface StateProvinceDetailComponentState {
  model?: StateProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StateProvinceDetailComponent extends React.Component<
  StateProvinceDetailComponentProps,
  StateProvinceDetailComponentState
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
          'stateprovinces/' +
          this.props.match.params.stateProvinceID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.StateProvinceClientResponseModel;

          let mapper = new StateProvinceMapper();

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
      return <StateProvinceDetailDisplay model={this.state.model} />;
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
    <Hash>021946d3c7ecddcd7039c21a1a8189e4</Hash>
</Codenesium>*/
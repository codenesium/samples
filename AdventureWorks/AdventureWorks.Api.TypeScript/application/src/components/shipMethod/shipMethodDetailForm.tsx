import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ShipMethodMapper from './shipMethodMapper';
import ShipMethodViewModel from './shipMethodViewModel';

interface Props {
  model?: ShipMethodViewModel;
}

const ShipMethodDetailDisplay = (model: Props) => {
  return (
    <form role="form">
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
        <label htmlFor="shipBase" className={'col-sm-2 col-form-label'}>
          ShipBase
        </label>
        <div className="col-sm-12">{String(model.model!.shipBase)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="shipMethodID" className={'col-sm-2 col-form-label'}>
          ShipMethodID
        </label>
        <div className="col-sm-12">{String(model.model!.shipMethodID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="shipRate" className={'col-sm-2 col-form-label'}>
          ShipRate
        </label>
        <div className="col-sm-12">{String(model.model!.shipRate)}</div>
      </div>
    </form>
  );
};

interface IParams {
  shipMethodID: number;
}

interface IMatch {
  params: IParams;
}

interface ShipMethodDetailComponentProps {
  match: IMatch;
}

interface ShipMethodDetailComponentState {
  model?: ShipMethodViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ShipMethodDetailComponent extends React.Component<
  ShipMethodDetailComponentProps,
  ShipMethodDetailComponentState
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
          'shipmethods/' +
          this.props.match.params.shipMethodID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ShipMethodClientResponseModel;

          let mapper = new ShipMethodMapper();

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
      return <ShipMethodDetailDisplay model={this.state.model} />;
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
    <Hash>264d817eeda28167e3479e70af59a523</Hash>
</Codenesium>*/
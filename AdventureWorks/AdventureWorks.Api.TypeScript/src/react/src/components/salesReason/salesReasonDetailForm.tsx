import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SalesReasonMapper from './salesReasonMapper';
import SalesReasonViewModel from './salesReasonViewModel';

interface Props {
  model?: SalesReasonViewModel;
}

const SalesReasonDetailDisplay = (model: Props) => {
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
        <label htmlFor="reasonType" className={'col-sm-2 col-form-label'}>
          ReasonType
        </label>
        <div className="col-sm-12">{String(model.model!.reasonType)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="salesReasonID" className={'col-sm-2 col-form-label'}>
          SalesReasonID
        </label>
        <div className="col-sm-12">{String(model.model!.salesReasonID)}</div>
      </div>
    </form>
  );
};

interface IParams {
  salesReasonID: number;
}

interface IMatch {
  params: IParams;
}

interface SalesReasonDetailComponentProps {
  match: IMatch;
}

interface SalesReasonDetailComponentState {
  model?: SalesReasonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SalesReasonDetailComponent extends React.Component<
  SalesReasonDetailComponentProps,
  SalesReasonDetailComponentState
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
          'salesreasons/' +
          this.props.match.params.salesReasonID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SalesReasonClientResponseModel;

          let mapper = new SalesReasonMapper();

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
      return <SalesReasonDetailDisplay model={this.state.model} />;
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
    <Hash>7fddc0ff7206a41a9a0ab5cca35b536d</Hash>
</Codenesium>*/
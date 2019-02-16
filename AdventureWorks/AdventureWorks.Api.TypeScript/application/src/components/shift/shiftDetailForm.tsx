import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import ShiftMapper from './shiftMapper';
import ShiftViewModel from './shiftViewModel';

interface Props {
  model?: ShiftViewModel;
}

const ShiftDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="endTime" className={'col-sm-2 col-form-label'}>
          EndTime
        </label>
        <div className="col-sm-12">{String(model.model!.endTime)}</div>
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
        <label htmlFor="shiftID" className={'col-sm-2 col-form-label'}>
          ShiftID
        </label>
        <div className="col-sm-12">{String(model.model!.shiftID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="startTime" className={'col-sm-2 col-form-label'}>
          StartTime
        </label>
        <div className="col-sm-12">{String(model.model!.startTime)}</div>
      </div>
    </form>
  );
};

interface IParams {
  shiftID: number;
}

interface IMatch {
  params: IParams;
}

interface ShiftDetailComponentProps {
  match: IMatch;
}

interface ShiftDetailComponentState {
  model?: ShiftViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ShiftDetailComponent extends React.Component<
  ShiftDetailComponentProps,
  ShiftDetailComponentState
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
      .get(Constants.ApiUrl + 'shifts/' + this.props.match.params.shiftID, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.ShiftClientResponseModel;

          let mapper = new ShiftMapper();

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
      return <ShiftDetailDisplay model={this.state.model} />;
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
    <Hash>2bc2d5746fd93b705609c9bb81f597fb</Hash>
</Codenesium>*/
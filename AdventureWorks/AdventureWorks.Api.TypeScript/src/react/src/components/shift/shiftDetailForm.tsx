import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ShiftMapper from './shiftMapper';
import ShiftViewModel from './shiftViewModel';

interface Props {
  history: any;
  model?: ShiftViewModel;
}

const ShiftDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Shifts + '/edit/' + model.model!.shiftID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
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
  history: any;
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Shifts +
          '/' +
          this.props.match.params.shiftID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
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
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <ShiftDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>91b8333ece1422c50fc848ea4a86ca6a</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import DeviceMapper from './deviceMapper';
import DeviceViewModel from './deviceViewModel';

interface Props {
  history: any;
  model?: DeviceViewModel;
}

const DeviceDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Devices + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="dateOfLastPing" className={'col-sm-2 col-form-label'}>
          DateOfLastPing
        </label>
        <div className="col-sm-12">{String(model.model!.dateOfLastPing)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="isActive" className={'col-sm-2 col-form-label'}>
          IsActive
        </label>
        <div className="col-sm-12">{String(model.model!.isActive)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="publicId" className={'col-sm-2 col-form-label'}>
          PublicId
        </label>
        <div className="col-sm-12">{String(model.model!.publicId)}</div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface DeviceDetailComponentProps {
  match: IMatch;
  history: any;
}

interface DeviceDetailComponentState {
  model?: DeviceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DeviceDetailComponent extends React.Component<
  DeviceDetailComponentProps,
  DeviceDetailComponentState
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
          ApiRoutes.Devices +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DeviceClientResponseModel;

          let mapper = new DeviceMapper();

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
        <DeviceDetailDisplay
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
    <Hash>5e2af423e2d16017d253c6c3987cff23</Hash>
</Codenesium>*/
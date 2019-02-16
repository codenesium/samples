import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import MachineMapper from './machineMapper';
import MachineViewModel from './machineViewModel';

interface Props {
  history: any;
  model?: MachineViewModel;
}

const MachineDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Machines + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="description" className={'col-sm-2 col-form-label'}>
          Description
        </label>
        <div className="col-sm-12">{String(model.model!.description)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="jwtKey" className={'col-sm-2 col-form-label'}>
          JwtKey
        </label>
        <div className="col-sm-12">{String(model.model!.jwtKey)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="lastIpAddress" className={'col-sm-2 col-form-label'}>
          LastIpAddress
        </label>
        <div className="col-sm-12">{String(model.model!.lastIpAddress)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="machineGuid" className={'col-sm-2 col-form-label'}>
          MachineGuid
        </label>
        <div className="col-sm-12">{String(model.model!.machineGuid)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
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

interface MachineDetailComponentProps {
  match: IMatch;
  history: any;
}

interface MachineDetailComponentState {
  model?: MachineViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class MachineDetailComponent extends React.Component<
  MachineDetailComponentProps,
  MachineDetailComponentState
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
          ApiRoutes.Machines +
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
          let response = resp.data as Api.MachineClientResponseModel;

          let mapper = new MachineMapper();

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
        <MachineDetailDisplay
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
    <Hash>f0102138f4a9e777078809813cbad93c</Hash>
</Codenesium>*/
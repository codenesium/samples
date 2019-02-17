import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import AirTransportMapper from './airTransportMapper';
import AirTransportViewModel from './airTransportViewModel';

interface Props {
  history: any;
  model?: AirTransportViewModel;
}

const AirTransportDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.AirTransports + '/edit/' + model.model!.airlineId
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="airlineId" className={'col-sm-2 col-form-label'}>
          AirlineId
        </label>
        <div className="col-sm-12">{String(model.model!.airlineId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="flightNumber" className={'col-sm-2 col-form-label'}>
          FlightNumber
        </label>
        <div className="col-sm-12">{String(model.model!.flightNumber)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="handlerId" className={'col-sm-2 col-form-label'}>
          HandlerId
        </label>
        <div className="col-sm-12">
          {model.model!.handlerIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="landDate" className={'col-sm-2 col-form-label'}>
          LandDate
        </label>
        <div className="col-sm-12">{String(model.model!.landDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="pipelineStepId" className={'col-sm-2 col-form-label'}>
          PipelineStepId
        </label>
        <div className="col-sm-12">{String(model.model!.pipelineStepId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="takeoffDate" className={'col-sm-2 col-form-label'}>
          TakeoffDate
        </label>
        <div className="col-sm-12">{String(model.model!.takeoffDate)}</div>
      </div>
    </form>
  );
};

interface IParams {
  airlineId: number;
}

interface IMatch {
  params: IParams;
}

interface AirTransportDetailComponentProps {
  match: IMatch;
  history: any;
}

interface AirTransportDetailComponentState {
  model?: AirTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class AirTransportDetailComponent extends React.Component<
  AirTransportDetailComponentProps,
  AirTransportDetailComponentState
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
          ApiRoutes.AirTransports +
          '/' +
          this.props.match.params.airlineId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AirTransportClientResponseModel;

          let mapper = new AirTransportMapper();

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
        <AirTransportDetailDisplay
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
    <Hash>8c139f519757a452ce1dbdc21869d105</Hash>
</Codenesium>*/
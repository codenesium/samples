import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import EventMapper from './eventMapper';
import EventViewModel from './eventViewModel';

interface Props {
  history: any;
  model?: EventViewModel;
}

const EventDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Events + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="address1" className={'col-sm-2 col-form-label'}>
          Address1
        </label>
        <div className="col-sm-12">{String(model.model!.address1)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="address2" className={'col-sm-2 col-form-label'}>
          Address2
        </label>
        <div className="col-sm-12">{String(model.model!.address2)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="cityId" className={'col-sm-2 col-form-label'}>
          CityId
        </label>
        <div className="col-sm-12">
          {model.model!.cityIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="date" className={'col-sm-2 col-form-label'}>
          Date
        </label>
        <div className="col-sm-12">{String(model.model!.date)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="description" className={'col-sm-2 col-form-label'}>
          Description
        </label>
        <div className="col-sm-12">{String(model.model!.description)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="endDate" className={'col-sm-2 col-form-label'}>
          EndDate
        </label>
        <div className="col-sm-12">{String(model.model!.endDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="facebook" className={'col-sm-2 col-form-label'}>
          Facebook
        </label>
        <div className="col-sm-12">{String(model.model!.facebook)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="startDate" className={'col-sm-2 col-form-label'}>
          StartDate
        </label>
        <div className="col-sm-12">{String(model.model!.startDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="website" className={'col-sm-2 col-form-label'}>
          Website
        </label>
        <div className="col-sm-12">{String(model.model!.website)}</div>
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

interface EventDetailComponentProps {
  match: IMatch;
  history: any;
}

interface EventDetailComponentState {
  model?: EventViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EventDetailComponent extends React.Component<
  EventDetailComponentProps,
  EventDetailComponentState
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
          ApiRoutes.Events +
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
          let response = resp.data as Api.EventClientResponseModel;

          let mapper = new EventMapper();

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
        <EventDetailDisplay
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
    <Hash>ab86cb6be326b71f63c85f73996eb98f</Hash>
</Codenesium>*/
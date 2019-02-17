import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
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
        <label htmlFor="actualEndDate" className={'col-sm-2 col-form-label'}>
          ActualEndDate
        </label>
        <div className="col-sm-12">{String(model.model!.actualEndDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="actualStartDate" className={'col-sm-2 col-form-label'}>
          ActualStartDate
        </label>
        <div className="col-sm-12">{String(model.model!.actualStartDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="billAmount" className={'col-sm-2 col-form-label'}>
          BillAmount
        </label>
        <div className="col-sm-12">{String(model.model!.billAmount)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="eventStatusId" className={'col-sm-2 col-form-label'}>
          EventStatusId
        </label>
        <div className="col-sm-12">
          {model.model!.eventStatusIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="scheduledEndDate" className={'col-sm-2 col-form-label'}>
          ScheduledEndDate
        </label>
        <div className="col-sm-12">{String(model.model!.scheduledEndDate)}</div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="scheduledStartDate"
          className={'col-sm-2 col-form-label'}
        >
          ScheduledStartDate
        </label>
        <div className="col-sm-12">
          {String(model.model!.scheduledStartDate)}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="studentNote" className={'col-sm-2 col-form-label'}>
          StudentNotes
        </label>
        <div className="col-sm-12">{String(model.model!.studentNote)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="teacherNote" className={'col-sm-2 col-form-label'}>
          TeacherNotes
        </label>
        <div className="col-sm-12">{String(model.model!.teacherNote)}</div>
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
    <Hash>abbca3ef5bdd77cace6d67f61ddb625a</Hash>
</Codenesium>*/